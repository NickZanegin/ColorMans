using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathWay
{
    public class DrowPath : MonoBehaviour
    {
        [SerializeField] LineRenderer line;
        GameObject stickman;
        [SerializeField] List<Point> points;
        private void Start()
        {
            points = new List<Point>();
        }
        public void Drow(GameObject start, List<Point> way)
        {
            line.positionCount = way.Count+1;
            stickman = start;
            points = way;
            DrowLine();
            StartCoroutine(LineMoving());
        }
        private void DrowLine()
        {
            for (int i = 0; i < points.Count; i++)
            {
                line.SetPosition(i + 1, points[i].transform.position);
            }
        }
        IEnumerator LineMoving()
        {
            var finish = false;
            int count = points.Count;
            while (!finish)
            {
                line.SetPosition(0, stickman.transform.position);
                if(points.Count != count)
                {
                    count--;
                    DrowLine();
                }
                if(count == 1)
                {
                    finish = true;
                    line.positionCount = 0;
                    break;
                }
                line.SetPosition(0, stickman.transform.position);
                yield return null;
            }
        }
    }
}
