using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Camera camera;
    [SerializeField] float time;
    bool start = true;
    float startSize;
    static CameraMove cameraMove;

    public Action eventCameraReady;
    private void Awake()
    {
        cameraMove = this;
        camera = Camera.main;
        startSize = camera.fieldOfView;
    }
    private void Update()
    {
        if (start)
        {
            camera.fieldOfView = Mathf.MoveTowards(camera.fieldOfView, 88, Time.deltaTime * time);
            if (camera.fieldOfView <= 89)
            {
                camera.fieldOfView = 88;
                start = false;
                eventCameraReady?.Invoke();
            }
        }
    }
    public static void RestartCamera() => cameraMove.Restart();
    private void Restart()
    {
        camera.fieldOfView = startSize;
        start = true;
    }
}
