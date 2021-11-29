using UnityEngine;
using TMPro;

namespace Ui
{
    public class LvlText : MonoBehaviour
    {
        [SerializeField] CameraMove camera;
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] TextMeshProUGUI finishText;
        private void Start()
        {
            camera.eventCameraReady += HideText;
        }
        public void NewLvlText(int lvl)
        {
            text.text = $"LEVEL {lvl}";
        }
        private void HideText()
        {
            gameObject.SetActive(false);
        }
    }
}
