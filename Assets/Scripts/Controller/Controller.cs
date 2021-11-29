using System;
using UnityEngine;
namespace Controller
{

    public class Controller : MonoBehaviour
    {
        Camera mainCamera;
        public Action<GameObject> tap;
        void Start()
        {
            mainCamera = Camera.main;
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    var stickman = hit.collider.gameObject;
                    tap?.Invoke(stickman);
                }
            }
        }
        public void Disable()
        {
            this.enabled = false;
        }
    }
}
