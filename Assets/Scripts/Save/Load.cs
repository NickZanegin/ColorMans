using UnityEngine;

namespace Save
{
    public class Load : MonoBehaviour
    {
        private void Start()
        {
            string LoadLvl;
            if (!PlayerPrefs.HasKey("lvl"))
            {
                LoadLvl = "1lvl";
            }
            else
            {
                LoadLvl = PlayerPrefs.GetString("lvl");
            }
            var lvl = Resources.Load($"Prefab/{LoadLvl}");
            Instantiate(lvl, Vector3.zero, Quaternion.identity);
        }
    }
}
