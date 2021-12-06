using System.Collections;
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

    Sequence anim;
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
        anim = DOTween.Sequence();
        anim.Append(text.DOFade(1, 1));
        anim.Append(stars[0].DOFade(1, 0.5f));
        anim.Append(stars[1].DOFade(1, 0.5f));
        anim.Append(stars[2].DOFade(1, 0.5f));
        anim.AppendCallback(() => StartCoroutine(WaitToNext()));
    }
    IEnumerator WaitToNext()
    {
        yield return new WaitForSecondsRealtime(3);
        if (next.gameObject.activeInHierarchy)
        {
            next.gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
    public void TextHide()
    {
        DOTween.KillAll();
        anim.Kill();
        Hide();

    }
    private void Hide()
    {
        text.color = hide;
        stars[0].color = hide;
        stars[1].color = hide;
        stars[2].color = hide;
    }
}
