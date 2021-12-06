using UnityEngine;
namespace Save
{
    public class Save : MonoBehaviour
    {
        static Save instance;
        private void Awake()
        {
            instance = this;
        }
        public static void SaveLvl(string lvl) => instance.LvlSave(lvl);
        public static void SaveUiLvl(int lvl) => instance.LvlUiSave(lvl);

        private void LvlSave(string lvl)
        {
            PlayerPrefs.SetString("lvl", lvl);
        }
        private void LvlUiSave(int lvl)
        {
            PlayerPrefs.SetInt("lvlUi", lvl);
        }
    }
}
