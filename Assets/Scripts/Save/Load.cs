using UnityEngine;

namespace Save
{
    public class Load : MonoBehaviour
    {
        private void Start()
        {
            if (PlayerPrefs.HasKey("lvlUi"))
            {
                Ui.ProgressBar.CurentLvlUpdate(PlayerPrefs.GetInt("lvlUi"));
            }
            string LoadLvl;
            if (!PlayerPrefs.HasKey("lvl"))
            {
                LoadLvl = "1lvl";
            }
            else
            {
                LoadLvl = PlayerPrefs.GetString("lvl");
            }
            Instantiate
                (Resources.Load($"Prefab/{LoadLvl}"), 
                Vector3.zero, 
                Quaternion.identity);
        }
    }
}
