using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStickmans : MonoBehaviour
{
    static MoveStickmans moveStickmans;
    [SerializeField] PathFinder pathFinder;
    [SerializeField] PointsArray pointsArray;

    GameObject fertsStickman;
    [SerializeField] List<Point> waipoint;
    List<Point> Reverswaipoint;

    public Action<GameObject> PathFail;
    public Action Unselect;
    private void Awake()
    {
        moveStickmans = this;
    }
    public static void LinksNew() => moveStickmans.NewLicks();
    private void NewLicks()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        pointsArray = FindObjectOfType<PointsArray>();
    }
    public void Action(GameObject stickman)
    {
        FindWay(stickman);
    }
    public void addFerstStik(GameObject ferst)
    {
        fertsStickman = ferst;
    }
    public void FindWay(GameObject stickman)
    {
        var ID = fertsStickman.GetComponent<IColor>();
        var start = pointsArray.FindPoint(ID.GetLine(), ID.GetColumn());
        ID = stickman.GetComponent<IColor>();
        var finish = pointsArray.FindPoint(ID.GetLine(), ID.GetColumn());
        start.Open();
        finish.Open();
        bool way = pathFinder.FindePath(start, finish);
        if (way)
        {
            waipoint = pathFinder.way;
            GoToPosition(stickman);
        }
        else
        {
            start.Close();
            finish.Close();
            waipoint.Clear();
            PathFail?.Invoke(stickman);
        }
    }
    private void GoToPosition(GameObject stickman)
    {
        fertsStickman.AddComponent<Move>().StartMove(waipoint);
        //stickman.AddComponent<Move>().StartMove(Reverswaipoint);
        fertsStickman.AddComponent<CollisionStickman>().addLinks(stickman);
        fertsStickman.GetComponent<CapsuleCollider>().enabled = true;
        stickman.GetComponent<CapsuleCollider>().enabled = true;
    }
}
