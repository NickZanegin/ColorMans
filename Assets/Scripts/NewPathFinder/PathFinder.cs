using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private PointsArray pointsArray;
    public List<Point> way;
    public List<Point> deadEnds;
    public bool FindePath(Point start, Point finish)
    {
        var step = start;
        Point lastPoint = null;
        for (int i = 0; i < 48; i++)
        {
            var briges = CheckBrige(step, lastPoint,finish);
            if (briges.Count == 0 && step != start)
            {
                deadEnds.Add(step);
                step.Close();
                way.Clear();
                step = start;
                lastPoint = null;
                i = -1;
                continue;
            }
            if (briges.Count == 0)
            {
                OpenDeadEnds();
                return false;
            }
            PointSelection(briges, finish);
            lastPoint = step;
            step = way[i];
            if (step.transform == finish.transform)
            {
                OpenDeadEnds();
                return true;
            }
        }
        OpenDeadEnds();
        return false;
    }
    private void OpenDeadEnds()
    {
        for (int i = 0; i < deadEnds.Count; i++)
        {
            deadEnds[i].Open();
        }
        deadEnds.Clear();
    }
    private void PointSelection(List<Point> points,Point finish)
    {
        Point selectPoint = points[0];
        float curentDistance;
        float newDistande;
        for (int i = 1; i < points.Count; i++)
        {
            curentDistance = Vector3.Distance(selectPoint.transform.localPosition, finish.transform.localPosition);
            newDistande = Vector3.Distance(points[i].transform.localPosition, finish.transform.localPosition);
            if (newDistande < curentDistance)
            {
                selectPoint = points[i];
            }
        }
        way.Add(selectPoint);
    }
    private List<Point> CheckBrige(Point point, Point lastPoint, Point finishPoint)
    {
        var up = point.line - 1;
        var left = point.column - 1;
        var down = point.line + 1;
        var right = point.column + 1;
        List<Point> neihboringPoints = new List<Point> 
        {
        pointsArray.GetNeihboring(up, point.column, point.up),
        pointsArray.GetNeihboring(point.line, right, point.right),
        pointsArray.GetNeihboring(down, point.column, point.down),
        pointsArray.GetNeihboring(point.line, left, point.left),
        };
        int y = 0;
        for (int i = 0; i < 4; i++)
        {
            if(neihboringPoints[y] == null)
            {
                neihboringPoints.RemoveAt(y);
                continue;
            }
            if (neihboringPoints[y] == finishPoint)
            {
                return neihboringPoints;
            }
            if (neihboringPoints[y].GetAccess() == false || neihboringPoints[y] == lastPoint)
            {
                neihboringPoints.RemoveAt(y);
            }
            else
            {
                y++;
            }
        }
        return neihboringPoints;
    }
}
