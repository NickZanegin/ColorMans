using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStickmans : MonoBehaviour
{
    [SerializeField] CashAccess cash;

    GameObject fertsStickman;
    GwWaypoint[] waipoint;

    public Action<GameObject,GameObject> PathFail;
    public Action Unselect;
    public void Action(GameObject stickman)
    {
        StartCoroutine(FindPathRoutine(stickman));
        //TODO: Добавить перепроверку на случай нескольких вариантов путей.
    }
    public void addFerstStik(GameObject ferst)
    {
        fertsStickman = ferst;
    }
    private void FindFidback(GwWaypoint[] path)
    {
        waipoint = path;
    }
    private IEnumerator FindPathRoutine(GameObject stickman)
    {
        FindWay(stickman);
        yield return null;
        if (TryToAccessPath.TryAcccess(waipoint))
        {
            GoToPosition(stickman);
        }
        else
        {
            fertsStickman.GetComponent<ConectionList>().CloseAllGraph();
            Unselect?.Invoke();
            PathFail?.Invoke(fertsStickman, stickman);
        }
    }
    public void FindWay(GameObject stickman)
    {
        Graphway.FindPath(fertsStickman.transform.position, stickman.transform.position, FindFidback, true, false);
    }
    private void GoToPosition(GameObject stickman)
    {
        fertsStickman.AddComponent<Move>().StartMove(waipoint);
        fertsStickman.AddComponent<CollisionStickman>().addTarget(stickman);
        fertsStickman.GetComponent<CapsuleCollider>().enabled = true;
        stickman.GetComponent<CapsuleCollider>().enabled = true;
        cash.AddPoints(waipoint[0]);
        cash.AddPoints(waipoint[waipoint.Length - 1]);
    }
}
