using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashScreen : MonoBehaviour
{
    [SerializeField] float waitTime = 0.15f;
    [SerializeField] private Image image;
    WaitForSeconds wait;
    static FlashScreen flash;
    void Awake()
    {
        flash = this;
        wait = new WaitForSeconds(waitTime);
    }
    public static void StartFlash() => flash.ScreenFlash();
    private void ScreenFlash()
    {
        //StartCoroutine(Flash());
    }
    IEnumerator Flash()
    {
        image.enabled = true;
        yield return wait;
        image.enabled = false;
    }
}
