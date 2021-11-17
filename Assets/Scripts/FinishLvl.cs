using UnityEngine;

public class FinishLvl : MonoBehaviour
{
    [SerializeField] Next_Button next;
    [SerializeField] ParticleSystem stars;
    static FinishLvl instance;
    private void Start()
    {
        instance = this;
    }
    public static void Finish() => instance.ActiveteFinish();
    public void ActiveteFinish()
    {
        next.gameObject.SetActive(true);
        stars.Play();
    }
}
