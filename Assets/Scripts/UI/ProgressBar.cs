using UnityEngine;
using TMPro;

namespace Ui
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] BarAnim anim;
        [SerializeField] TextMeshProUGUI pastlvl;
        [SerializeField] TextMeshProUGUI centerlvl;
        [SerializeField] TextMeshProUGUI nextlvl;
        public static ProgressBar bar;
        int curentLvl = 1;
        private void Awake()
        {
            bar = this;
        }
        public static int BarUpdate() => bar.UpdateBar();
        public static void CurentLvlUpdate(int lvl) => bar.UpdateCurentLvl(lvl);
        public static void CurentLvlAdd() => bar.AddCurentLvl();
        private void UpdateCurentLvl(int lvl)
        {
            curentLvl = lvl;
        }
        private void AddCurentLvl()
        {
            curentLvl++;
            Save.Save.SaveUiLvl(curentLvl);
        }
        private int UpdateBar()
        {
            pastlvl.text = $"{curentLvl}";
            centerlvl.text = $"{curentLvl + 1}";
            nextlvl.text = $"{curentLvl + 2}";
            Save.Save.SaveUiLvl(curentLvl);
            return curentLvl;
        }
    }
}
