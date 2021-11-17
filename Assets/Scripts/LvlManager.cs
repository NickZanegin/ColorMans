using System.Collections;
using UnityEngine;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private string lvls;
    [SerializeField] private string thisLvls;
    Next_Button next;
    static LvlManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        next = FindObjectOfType<Next_Button>();
        next.ManagerLink(this);
        next.gameObject.SetActive(false);
        FindObjectOfType<Restart>().NewLink(this);
        MoveStickmans.LinksNew();
        CameraMove.RestartCamera();
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
        }
    }
    public void LoadNextLvl()
    {
        var lvl = Resources.Load($"Prefab/{lvls}");
        Instantiate(lvl, Vector3.zero, Quaternion.identity);
        Destroy(gameObject);
        //ChangeBG.NextBG();
    }
    public void Restart()
    {
        var lvl = Resources.Load($"Prefab/{thisLvls}");
        Instantiate(lvl, Vector3.zero, Quaternion.identity);
        next.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
