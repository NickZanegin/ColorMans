using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] PathFinder pathFinder;
    public Point start;
    public Point finish;

    public void testway()
    {
        bool way = pathFinder.FindePath(start, finish);
        Debug.Log(way);
    }
}
