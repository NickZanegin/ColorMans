using UnityEngine;

public class HandWatcing : MonoBehaviour
{
    Camera camera;
    Vector3 point;
    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        point = Input.mousePosition;
        point.x += 6;
        point.y -= 30;
        Ray mouse = camera.ScreenPointToRay(point);
        transform.position = mouse.GetPoint(20);
    }
}
