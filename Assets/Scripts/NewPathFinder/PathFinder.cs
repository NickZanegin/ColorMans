using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private PointsArray pointsArray;
    public List<Point> way;
    public bool FindePath(Point start, Point finish)
    {
        var step = start;
        Point lastPoint = null; 
        for (int i = 0; i < 48; i++)
        {
            var briges = CheckBrige(step, lastPoint);
            if (briges.Count == 0)
            {
                return false;
            }
            PointSelection(briges, finish);
            lastPoint = step;
            step = way[i];
            if (step.transform == finish.transform)
            {
                return true;
            }
        }
        return false;
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
    private List<Point> CheckBrige(Point point, Point lastPoint)
    {
        var up = point.line + 1;
        var left = point.column - 1;
        var down = point.line - 1;
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
            if(neihboringPoints[y] == lastPoint)
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
