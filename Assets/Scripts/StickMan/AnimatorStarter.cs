using System.Collections;
using UnityEngine;

public class AnimatorStarter : MonoBehaviour
{
    [SerializeField] Animator anim;
    int time;
    private void Start()
    {
        time = Random.Range(1, 3);
        StartCoroutine(WaitDance());
    }

    IEnumerator WaitDance()
    {
        anim.SetBool("Select", true);
        yield return new WaitForSeconds(time);
        anim.SetBool("Select",false);
    }
}
