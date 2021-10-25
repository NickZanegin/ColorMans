using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWay : MonoBehaviour
{
    List<Graphway> waipoint;
    GwWaypoint startNode;
    private void Start()
    {
        waipoint = new List<Graphway>();
    }
    public void addStart(GwWaypoint start)
    {
        startNode = start;
    }
    public void Disable(GwWaypoint point)
    {
        //var 
        //waipoint.Add(point);


    }
}
