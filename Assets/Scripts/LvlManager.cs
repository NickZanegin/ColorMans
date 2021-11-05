using System.Collections;
using UnityEngine;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private string lvls;
    [SerializeField] private string thisLvls;
    static LvlManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //FindObjectOfType<Restart>().NewLink(this);
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
            var lvl = Resources.Load($"Prefab/{lvls}");
            var nextlvl = Instantiate(lvl, Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
            //ChangeBG.NextBG();
        }
    }
    public void Restart()
    {
        var lvl = Resources.Load($"Prefab/{thisLvls}");
        var nextlvl = Instantiate(lvl, Vector3.zero, Quaternion.identity);
        Destroy(gameObject);
    }
}
