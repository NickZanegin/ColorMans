using UnityEngine;

public class CollisionStickman : MonoBehaviour
{
    GameObject lastStickman;
    ParticleSystem explosion;

    public void Update()
    {
        if (Vector3.Distance(gameObject.transform.position,lastStickman.transform.position) < 1)
        {
            explosion = GetComponent<IColor>().GetParticle();
            explosion.transform.position = transform.position;
            explosion.Play();
            GetComponent<Move>().waypoints.Clear();
            Destroy(lastStickman);
            Destroy(gameObject);
            CameraShake.Shake();
            LvlManager.CheckLvl();
        }
    }
    public void addLinks(GameObject stickman)
    {
        lastStickman = stickman;
    }
    
}
