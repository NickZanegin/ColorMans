using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class MoveStickmans : MonoBehaviour
    {
        static MoveStickmans moveStickmans;
        [SerializeField] PathWay.PathFinder pathFinder;
        [SerializeField] PathWay.PointsArray pointsArray;
        [SerializeField] PathWay.DrowPath drow;
        [SerializeField] SelectActive select;

        GameObject fertsStickman;
        [SerializeField] List<Point> waipoint;
        //List<Point> reverswaipoint;
        Point start;

        public Action<GameObject> PathFail;
        public Action Unselect;
        private void Awake()
        {
            moveStickmans = this;
            //reverswaipoint = new List<Point>();
        }
        public static void LinksNew() => moveStickmans.NewLicks();
        private void NewLicks()
        {
            pathFinder = FindObjectOfType<PathWay.PathFinder>();
            pointsArray = FindObjectOfType<PathWay.PointsArray>();
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
            start = pointsArray.FindPoint(ID.GetLine(), ID.GetColumn());
            ID = stickman.GetComponent<IColor>();
            var finish = pointsArray.FindPoint(ID.GetLine(), ID.GetColumn());
            start.Open();
            finish.Open();
            if (pathFinder.FindePath(start, finish))
            {
                waipoint = pathFinder.way;
                GoToPosition(stickman);
            }
            else
            {
                start.Close();
                finish.Close();
                waipoint.Clear();
                PathFail?.Invoke(fertsStickman);
                Unselect?.Invoke();
                RayComand.EnableController();
            }
        }
        private void GoToPosition(GameObject stickman)
        {
            //drow.Drow(waipoint);
            fertsStickman.AddComponent<Move>().StartMove(waipoint);
            //stickman.AddComponent<Move>().StartMove(ReversWay());
            fertsStickman.AddComponent<Collisions.CollisionStickman>().addLinks(stickman, select);
            fertsStickman.GetComponent<CapsuleCollider>().enabled = true;
            stickman.GetComponent<CapsuleCollider>().enabled = true;
        }
        //private List<Point> ReversWay()
        //{
        //    if (reverswaipoint.Count > 1)
        //    {
        //        reverswaipoint.Clear();
        //    }
        //    int end = waipoint.Count - 1;
        //    for (int i = 0; i < waipoint.Count; i++)
        //    {
        //        reverswaipoint.Add(waipoint[end]);
        //        end--;
        //    }
        //    reverswaipoint.Add(start);
        //    return reverswaipoint;
        //}
    }
}
