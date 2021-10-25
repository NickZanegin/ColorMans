using UnityEngine;

public class CollisionStickman : MonoBehaviour
{
    GameObject lastStickman;
    ParticleSystem explosion;

    public void Update()
    {
        if (Vector3.Distance(gameObject.transform.position,lastStickman.transform.position) < 1)
        {
            explosion.transform.position = transform.position;
            explosion.Play();
            Destroy(lastStickman);
            Destroy(gameObject);
            LvlManager.CheckLvl();
        }
    }
    public void addLinks(GameObject stickman, ParticleSystem explosion)
    {
        lastStickman = stickman;
        this.explosion = explosion;
    }
    
}
