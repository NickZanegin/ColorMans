using System.Collections;
using UnityEngine;
//using GameAnalyticsSDK;
using LionStudios.Suite.Analytics;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private string lvls;
    [SerializeField] private string thisLvls;
    [SerializeField] private int lvl;
    [SerializeField] Attempt attmptScore;
    Next_Button next;
    static LvlManager Instance;
    int attemptNum = 1;
    int curentLvl;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        attemptNum = attmptScore.GetAttempt();
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "World_01", thisLvls, "Level_Progress");
        next = attmptScore.next_;
        next.ManagerLink(this);
        next.gameObject.SetActive(false);
        attmptScore.restart.NewLink(this);
        Controller.MoveStickmans.LinksNew();
        CameraMove.RestartCamera();
        if (Ui.BarAnim.Progress(lvl))
        {
            curentLvl = Ui.ProgressBar.BarUpdate();
        }
        else
        {
            curentLvl = PlayerPrefs.GetInt("lvlUi");
        }
        attmptScore.lvlText.NewLvlText(curentLvl);
        Save.Save.SaveLvl(thisLvls);
        LionAnalytics.LevelStart(lvl, attemptNum, null);
    }
    public static void CheckLvl() => Instance.strtRoutine();
    public void strtRoutine()
    {
        StartCoroutine(LvlCheck());
    }
    IEnumerator LvlCheck()
    {
        yield return null;
        var haveStickman = GetComponentInChildren<IColor>();
        if(haveStickman == null)
        {
            FinishLvl.Finish();
            LionAnalytics.LevelComplete(lvl, attemptNum, null,null);
            attmptScore.RemoveAttempt();
            //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "World_01", thisLvls, "Level_Progress");
            StartCoroutine(waitExplosion());
        }
    }
    IEnumerator waitExplosion()
    {
        yield return new WaitForSeconds(1);
        GetComponent<FinishExplosion>().StartExplosion();
    }
    public void LoadNextLvl()
    {
        Instantiate(Resources.Load($"Prefab/{lvls}"), Vector3.zero, Quaternion.identity);
        ChangeBG.NextBG();
        Destroy(gameObject);
    }
    public void Restart()
    {
        Instantiate
            (Resources.Load($"Prefab/{thisLvls}"), 
            Vector3.zero, 
            Quaternion.identity);
        next.gameObject.SetActive(true);
        attmptScore.AddAttempt();
        Destroy(gameObject);
        LionAnalytics.LevelFail(this.lvl, attemptNum, null);
        LionAnalytics.LevelRestart(this.lvl, attemptNum, null);
    }
}
