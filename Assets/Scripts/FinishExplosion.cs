using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishExplosion : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particles;
    List<Point> points;
    Point lastPoint;
    //private void Start()
    //{
    //    points = new List<Point>();
    //    Points();
    //}
    private void Points()
    {
        var point = GetComponentInChildren<PathWay.PointsArray>().GetPoints();
        for (int i = 0; i < 4; i++)
        {
            for (int y = 0; y < 4; y++)
            {
                if(point[i,y] != null)
                {
                    points.Add(point[i, y]);
                }
            }
        }
    }
    public void StartExplosion()
    {
        StartCoroutine(Explosion());
    }
    IEnumerator Explosion()
    {
        var wait = new WaitForSeconds(0.8f);
        for (int i = 0; i < 5; i++)
        {
            var explosion = particles[Random.Range(0, particles.Length)];
            var Point = points[Random.Range(0, points.Count)];
            explosion.transform.position = Point.transform.position;
            explosion.Play();
            points.Remove(Point);
            yield return wait;
        }
    }
}
