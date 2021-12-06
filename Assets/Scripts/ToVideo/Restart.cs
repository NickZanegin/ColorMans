using UnityEngine;

public class Restart : MonoBehaviour
{
    public LvlManager lvlManager;
    [SerializeField] Attempt attempt;
    private void Awake()
    {
        attempt.GetRestart(this);
    }
    public void RestartLvl()
    {
        lvlManager.Restart();
    }
    public void NewLink(LvlManager lvl)
    {
        lvlManager = lvl;
    }
}
