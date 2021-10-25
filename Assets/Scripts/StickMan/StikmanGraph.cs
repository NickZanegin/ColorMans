using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StikmanGraph : MonoBehaviour
{
    public GameObject gw { get; }

    public GwWaypoint GetPoint()
    {
        return gw.GetComponent<GwWaypoint>();
    }
}
