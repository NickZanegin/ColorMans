using UnityEngine;

public class CollisionStickman : MonoBehaviour
{
    GameObject lastStickman;

    public void Update()
    {
        if (Vector3.Distance(gameObject.transform.position,lastStickman.transform.position) < 1)
        {
            Destroy(lastStickman);
            Destroy(gameObject);
        }
    }
    public void addTarget(GameObject stickman)
    {
        lastStickman = stickman;
    }
}
