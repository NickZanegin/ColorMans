using Ui;
using UnityEngine;

public class Next_Button : MonoBehaviour
{
    [SerializeField] GameObject restart;
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
        YsoCorp.GameUtils.YCManager.instance.adsManager.ShowInterstitial(() =>
        {
            manager.LoadNextLvl();
            restart.SetActive(true);
            ProgressBar.CurentLvlAdd();
        });
    }
}
