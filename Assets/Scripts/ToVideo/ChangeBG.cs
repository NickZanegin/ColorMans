using UnityEngine;

public class ChangeBG : MonoBehaviour
{
    [SerializeField] private GameObject[] BG;
    static ChangeBG bG;
    private int index = 0;
    private void Start()
    {
        bG = this;
    }
    public static void NextBG() => bG.Checge();
    private void Checge()
    {
        BG[index].SetActive(false);
        index++;
        if(index >= BG.Length)
        {
            index = 0;
        }
        BG[index].SetActive(true);
    }
}
