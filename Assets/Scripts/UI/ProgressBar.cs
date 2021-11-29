using UnityEngine;
using TMPro;

namespace Ui
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] BarAnim anim;
        [SerializeField] TextMeshProUGUI pastlvl;
        [SerializeField] TextMeshProUGUI curentlvl;
        [SerializeField] TextMeshProUGUI nextlvl;
        public static ProgressBar bar;
        private void Awake()
        {
            bar = this;
        }
        public static void BarUpdate(int lvl) => bar.UpdateBar(lvl);
        private void UpdateBar(int lvl)
        {
            pastlvl.text = $"{lvl}";
            curentlvl.text = $"{lvl+1}";
            nextlvl.text = $"{lvl + 2}";
        }
    }
}
