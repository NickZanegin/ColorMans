using System.Collections;
using UnityEngine;

public class Prompt : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(PromptRoutine());
    }
    IEnumerator PromptRoutine()
    {
        var wait = new WaitForSecondsRealtime(5);
        yield return wait;
        GetComponent<Animator>().SetBool("Help", true);
        yield return wait;
        GetComponent<Animator>().SetBool("Help", false);
    }
}
