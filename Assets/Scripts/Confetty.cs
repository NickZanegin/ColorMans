using System.Collections;
using UnityEngine;

public class Confetty : MonoBehaviour
{
    public int counfettyCount = 6;
    [SerializeField] private ParticleSystem[] confetty;
    private int index = 0;

    public void PlayeConfety()
    {
        StartCoroutine(StartConfetty());
    }
    private IEnumerator StartConfetty()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);
        for (int i = 0; i < counfettyCount; i++)
        {
            PlayConfetty();
            yield return wait;
        }
    }

    private void PlayConfetty()
    {
        ChangeConvetiPosition();
        confetty[index].Play();
        index++;
        if (index == 6) index = 0;
    }

    private void ChangeConvetiPosition()
    {
        float x = Random.Range(-711, 720);
        float y = Random.Range(-1100, 1350);
        confetty[index].transform.localPosition = new Vector3(x, y, 0);
    }
}