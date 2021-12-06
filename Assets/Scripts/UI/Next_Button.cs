using UnityEngine;

public class Next_Button : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] GameObject finisText;
    [SerializeField] GameObject restart;
    [SerializeField] FinishLvl finish;
    [SerializeField] Attempt attempt;
    LvlManager manager;
    private void Awake()
    {
        attempt.GetNext(this);
    }
    public void ManagerLink(LvlManager manager)
    {
        this.manager = manager;
    }
    public void NextLvl()
    {
        finisText.SetActive(false);
        finish.TextHide();
        text.SetActive(true);
        manager.LoadNextLvl();
        restart.SetActive(true);
    }
}
