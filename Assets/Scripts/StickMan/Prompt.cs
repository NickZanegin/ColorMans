using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompt : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(PromptRoutine());
    }
    IEnumerator PromptRoutine()
    {
        yield return new WaitForSecondsRealtime(10);
        GetComponent<Animator>().SetBool("Help", true);
        yield return new WaitForSecondsRealtime(10);
        GetComponent<Animator>().SetBool("Help", false);
    }
}
