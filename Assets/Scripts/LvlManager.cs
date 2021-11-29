using System.Collections;
using UnityEngine;
using GameAnalyticsSDK;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private string lvls;
    [SerializeField] private string thisLvls;
    [SerializeField] private int lvl; 
    Next_Button next;
    static LvlManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "World_01", thisLvls, "Level_Progress");
        next = FindObjectOfType<Next_Button>();
        next.ManagerLink(this);
        next.gameObject.SetActive(false);
        FindObjectOfType<Restart>().NewLink(this);
        Controller.MoveStickmans.LinksNew();
        CameraMove.RestartCamera();
        if (Ui.BarAnim.Progress(lvl))
        {
            Ui.ProgressBar.BarUpdate(lvl);
        }
        FindObjectOfType<Ui.LvlText>().NewLvlText(lvl);
        Save.Save.SaveLvl(thisLvls);
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
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "World_01", thisLvls, "Level_Progress");
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
        var lvl = Resources.Load($"Prefab/{lvls}");
        Instantiate(lvl, Vector3.zero, Quaternion.identity);
        ChangeBG.NextBG();
        Destroy(gameObject);
    }
    public void Restart()
    {
        var lvl = Resources.Load($"Prefab/{thisLvls}");
        Instantiate(lvl, Vector3.zero, Quaternion.identity);
        next.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
