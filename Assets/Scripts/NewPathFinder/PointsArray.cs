using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsArray : MonoBehaviour
{
    private Point[,] points;
    [SerializeField] private Point[] ferstLine;
    [SerializeField] private Point[] secondLine;
    [SerializeField] private Point[] thirdLine;
    [SerializeField] private Point[] fourthLine;
    [SerializeField] private Point emptyPoint;

    private void Awake()
    {
        points = new Point[4, 4];
        int line = 0;
        AddedArrey(ferstLine, line);
        line++;
        AddedArrey(secondLine, line);
        line++;
        AddedArrey(thirdLine, line);
        line++;
        AddedArrey(fourthLine, line);
    }
    private void AddedArrey(Point[] lineArray, int line)
    {
        for (int i = 0; i < lineArray.Length; i++)
        {
            points[line, i] = lineArray[i];
        }
    }
    public Point FindPoint(int line, int column)
    {
        return points[line, column];
    }
    public Point GetNeihboring(int line,int column, bool brige)
    {
        if (line > 3 || line < 0)
        {
            return emptyPoint;
        }
        if(column > 3 || column < 0)
        {
            return emptyPoint;
        }
        if(brige && points[line,column] != null)
        {
            return points[line, column];
        }
        else
        {
            return emptyPoint;
        }
    }
}
