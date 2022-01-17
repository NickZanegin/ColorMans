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
        public static void BarUpdate() => bar.UpdateBar();
        public static void CurentLvlUpdate(int lvl) => bar.UpdateCurentLvl(lvl);
        public static void CurentLvlAdd() => bar.AddCurentLvl();
        private void UpdateCurentLvl(int lvl)
        {
            curentLvl = lvl;
        }
        private void AddCurentLvl()
        {
            curentLvl++;
            BarAnim.Progress(curentLvl);
            Save.Save.SaveUiLvl(curentLvl);
        }
        private void UpdateBar()
        {
            int lvl = curentLvl;
            pastlvl.text = $"{lvl}";
            centerlvl.text = $"{lvl + 1}";
            nextlvl.text = $"{lvl + 2}";
        }
    }
}
