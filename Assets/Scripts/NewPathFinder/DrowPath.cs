using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathWay
{
    public class DrowPath : MonoBehaviour
    {
        [SerializeField] LineRenderer line;

        public void Drow(List<Point> way)
        {
            StartCoroutine(DrowLine(way));
        }
        IEnumerator DrowLine(List<Point> way)
        {
            var wait = new WaitForSeconds(1);
            line.positionCount = way.Count;
            for (int i = 0; i < way.Count; i++)
            {
                line.SetPosition(i, way[i].transform.position);
                yield return wait;
            }
        }
    }
}
