using UnityEngine;

public class Next_Button : MonoBehaviour
{
    LvlManager manager;
    public void ManagerLink(LvlManager manager)
    {
        this.manager = manager;
    }
    public void NextLvl()
    {
        manager.LoadNextLvl();
    }
}
