using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Ui
{
    public class BarAnim : MonoBehaviour
    {
        [SerializeField] Image progress;
        [SerializeField] TextMeshProUGUI left;
        [SerializeField] TextMeshProUGUI center;
        [SerializeField] TextMeshProUGUI right;
        Color green;
        static BarAnim bar;
        bool Start = true;
        int lvl = -1;
        private void Awake()
        {
            var proc = 1 / 255f;
            green = new Color(proc * 127f, proc * 221f, proc * 70f);
            bar = this;
        }
        public static bool Progress(int lvl) => bar.UpdateProgress(lvl);
        private bool UpdateProgress(int lvl)
        {
            if(lvl == this.lvl)
            {
                return false;
            }
            else
            {
                this.lvl = lvl;
            }
            if (Start)
            {
                Start = false;
                return true;
            }
            var amount = progress.fillAmount;
            switch (amount)
            {
                case 0.159f:
                    left.color = Color.white;
                    center.color = Color.white;
                    right.color = green;
                    progress.fillAmount = 0.58f;
                    break;
                case 0.58f:
                    left.color = Color.white;
                    center.color = Color.white;
                    right.color = Color.white;
                    progress.fillAmount = 1;
                    break;
                case 1:
                    left.color = Color.white;
                    center.color = green;
                    right.color = green;
                    progress.fillAmount = 0.159f;
                    return true;
            }
            return false;
        }
    }
}
