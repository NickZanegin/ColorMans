using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WrongScreen : MonoBehaviour
{
    private static WrongScreen screen;
    WaitForSeconds wait;
    [SerializeField] float waitTime = 0.15f; 
    [SerializeField] private Image image;
    [SerializeField] private Image fail;

    private void Awake()
    {
        screen = this;
        wait = new WaitForSeconds(waitTime);
    }
    public static void Wrong() => screen.ScreenWrong();

    private void ScreenWrong()
    {
        StartCoroutine(Flash());
    }
    IEnumerator Flash()
    {
        image.enabled = true;
        fail.enabled = true;
        yield return wait;
        image.enabled = false;
        fail.enabled = false;
    }
}
