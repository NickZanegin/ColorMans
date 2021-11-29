using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FinishLvl : MonoBehaviour
{
    [SerializeField] Next_Button next;
    [SerializeField] GameObject finish;
    [SerializeField] GameObject restart;
    [SerializeField] Image text;
    [SerializeField] Image[] stars;
    static FinishLvl instance;
    Color hide;
    int nextlvl = 0;
    private void Start()
    {
        instance = this;
        hide = new Color(1, 1, 1, 0);
    }
    public static void Finish() => instance.ActiveteFinish();
    public void ActiveteFinish()
    {
        next.gameObject.SetActive(true);
        TextAnim();
        finish.gameObject.SetActive(true);
        restart.SetActive(false);
    }
    private void TextAnim()
    {
        var anim = DOTween.Sequence();
        anim.Append(text.DOFade(1, 1));
        anim.Append(stars[0].DOFade(1, 0.5f));
        anim.Append(stars[1].DOFade(1, 0.5f));
        anim.Append(stars[2].DOFade(1, 0.5f));
        anim.AppendCallback(() => IfNextLvl());
    }
    private void IfNextLvl()
    {
        if (nextlvl == 1)
        {
            Hide();
        }
        nextlvl = 0;
    }
    public void TextHide()
    {
        if(nextlvl == 0)
        {
            Hide();
        }
        nextlvl = 1;

    }
    private void Hide()
    {
        text.color = hide;
        stars[0].color = hide;
        stars[1].color = hide;
        stars[2].color = hide;
    }
}
