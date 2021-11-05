using UnityEngine;

public class AnimatorStarter : MonoBehaviour
{
    [SerializeField] Animator anim;
    float time;
    private void Start()
    {
        time = Random.Range(0, 50f);
        anim.ForceStateNormalizedTime(time);
    }
}
