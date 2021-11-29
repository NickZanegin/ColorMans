using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] PathWay.PathFinder pathFinder;
    public Point start;
    public Point finish;

    public void testway()
    {
        bool way = pathFinder.FindePath(start, finish);
        Debug.Log(way);
    }
}
