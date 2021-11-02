using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public static CameraShake shake;
    private void Start()
    {
        shake = this;
    }
    public static void Shake() => shake.DoShake();

    public void DoShake()
    {
        var anim = DOTween.Sequence();
        var speed = 0.055f;
        var shake1 = new Vector3(4, 29.95f, -29.5f);
        var shake2 = new Vector3(2, 29.95f, -30.5f);
        var shake3 = new Vector3(4, 29.95f, -30.23f);
        var shake4 = new Vector3(2, 29.95f, -29.5f);
        var shake5 = new Vector3(4, 29.95f, -30.23f);
        var stop = new Vector3(3.32f, 29.95f, -30.23f);
        anim.Append(transform.DOMove(shake2, speed));
        anim.Append(transform.DOMove(shake3, speed));
        anim.Append(transform.DOMove(shake1, speed));
        anim.Append(transform.DOMove(shake4, speed));
        anim.Append(transform.DOMove(shake5, speed));
        anim.Append(transform.DOMove(stop, 0.1f));
    }
}
