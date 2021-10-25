using System.Collections.Generic;
using UnityEngine;

public class CashAccess : MonoBehaviour
{
    public static CashAccess instance;
    private List<Vector3> OpenPoints;
    private void Start()
    {
        OpenPoints = new List<Vector3>();
        instance = this;
    }
    public void AddPoints(GwWaypoint points)
    {
        OpenPoints.Add(points.position);
    }
    public static void CheckAccess(GwWaypoint waipoint)
    {
        instance.RetyrnCash(waipoint);
    }
    public void RetyrnCash(GwWaypoint waipoint)
    {
        foreach (var item in OpenPoints)
        {
            if(waipoint.position == item)
            {
                //waipoint.access = true;
                break;
            }
        }
    }
}
