using System.Collections;
using UnityEngine;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private string lvls;
    [SerializeField] private string thisLvls;
    [SerializeField] private int lvl;
    [SerializeField] Attempt attmptScore;
    Next_Button next;
    static LvlManager Instance;
    public float speed = 15;
    private Vector3 spawnPoint;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        spawnPoint = new Vector3(30, 0, 0);
        StartCoroutine(MovePlatform());
        next = attmptScore.next_;
        next.ManagerLink(this);
        next.gameObject.SetActive(false);
        attmptScore.restart.NewLink(this);
        Controller.MoveStickmans.LinksNew();
        StartCoroutine(MovePlatform());
        Save.Save.SaveLvl(thisLvls);
        YsoCorp.GameUtils.YCManager.instance.OnGameStarted(lvl);
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
            StartCoroutine(MovePlatform(-30));
            FinishLvl.Finish();
            attmptScore.RemoveAttempt();
            YsoCorp.GameUtils.YCManager.instance.OnGameFinished(true);
        }
    }
    public void LoadNextLvl()
    {
        Instantiate(Resources.Load($"Prefab/{lvls}"), spawnPoint, Quaternion.identity);
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
        YsoCorp.GameUtils.YCManager.instance.OnGameFinished(false);
    }
    IEnumerator MovePlatform(int pointX = 0)
    {
        Vector3 movePoint = new Vector3(pointX, 0, 0);
        while (transform.localPosition.x >= pointX)
        {
            transform.localPosition = Vector3.MoveTowards(
                transform.localPosition, 
                movePoint, 
                speed * Time.deltaTime);
            yield return null;
        }
    }
}
