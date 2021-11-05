using UnityEngine;

public class Restart : MonoBehaviour
{
    public LvlManager lvlManager;
    public void RestartLvl()
    {
        lvlManager.Restart();
    }
    public void NewLink(LvlManager lvl)
    {
        lvlManager = lvl;
    }
}
