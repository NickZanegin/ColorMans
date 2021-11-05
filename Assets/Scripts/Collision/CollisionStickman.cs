using UnityEngine;

public class CollisionStickman : MonoBehaviour
{
    GameObject lastStickman;
    ParticleSystem explosion;
    SelectActive select;

    public void Update()
    {
        if (Vector3.Distance(gameObject.transform.position,lastStickman.transform.position) < 1)
        {
            explosion = GetComponent<IColor>().GetParticle();
            explosion.transform.position = transform.position;
            explosion.Play();
            GetComponent<Move>().waypoints.Clear();
            Destroy(lastStickman);
            CameraShake.Shake();
            LvlManager.CheckLvl();
            select.StopSelect();
            Destroy(gameObject);
            RayComand.EnableController();
        }
    }
    public void addLinks(GameObject stickman, SelectActive select)
    {
        lastStickman = stickman;
        this.select = select; 
    }
    
}
