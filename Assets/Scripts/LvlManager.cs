using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private List<string> lvls;
    static LvlManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public static void CheckLvl()
    {
        Instance.strtRoutine();
    }
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
            var lvl = Resources.Load($"Prefab/{lvls[0]}");
            var nextlvl = Instantiate(lvl, Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
