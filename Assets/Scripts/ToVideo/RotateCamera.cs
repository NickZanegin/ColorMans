using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float rotate;
    private float rotatePoint;
    private void Start()
    {
        //transform.rotation = new Quaternion(0, rotate, 0, 0);
        transform.DORotate(Vector3.zero, time);
    }

    //void Update()
    //{
    //    rotatePoint = Mathf.Lerp(transform.rotation.y, 0, Time.deltaTime * time);
    //    transform.rotation = new Quaternion(0, rotatePoint, 0, 0);
    //    if (transform.rotation.y <= 2)
    //    {
    //        transform.rotation = new Quaternion(0, 0, 0, 0);
    //        Destroy(this);
    //    }
    //}
}
