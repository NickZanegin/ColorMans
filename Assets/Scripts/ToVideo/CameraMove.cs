using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Camera camera;
    [SerializeField] float time;
    [SerializeField] GameObject lvl;
    bool start = true;
    float startSize;
    Quaternion startRotation;
    [SerializeField] float rotateAngule;
    static CameraMove cameraMove;
    private void Awake()
    {
        cameraMove = this;
        startRotation = transform.rotation;
        camera = Camera.main;
        startSize = camera.orthographicSize;
    }
    private void Update()
    {
        if (start)
        {
            camera.orthographicSize = Mathf.MoveTowards(camera.orthographicSize, 22, Time.deltaTime * time);
            //transform.RotateAround(lvl.transform.position, Vector3.up, rotateAngule * Time.deltaTime);
            if (camera.orthographicSize <= 22.1)
            {
                camera.orthographicSize = 22;
                start = false;
            }
        }
    }
    public static void RestartCamera() => cameraMove.Restart();
    private void Restart()
    {
        camera.orthographicSize = startSize;
        start = true;
        lvl = FindObjectOfType<LvlManager>().gameObject;
        transform.rotation = startRotation;
    }
}
