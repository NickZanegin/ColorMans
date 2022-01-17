using System.Collections;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using Ui;
using UnityEngine.UI;

public class FinishLvl : MonoBehaviour
{
    [SerializeField] Next_Button next;
    [SerializeField] GameObject finish;
    [SerializeField] GameObject restart;
    [SerializeField] Transform text;
    [SerializeField] Image[] stars;
    [SerializeField] private Confetty confetty;
    static FinishLvl instance;
    Vector3 hide;
    public int speed = 5;
    private float startPointText;
    private float finishPointText;

    Sequence anim;
    private void Start()
    {
        hide = stars[0].transform.localScale;
        instance = this;
        startPointText = text.localPosition.x;
        finishPointText = -startPointText;
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
        StartCoroutine(FinishTextAnim());
    }

    IEnumerator FinishTextAnim()
    {
        confetty.PlayeConfety();
        yield return StartCoroutine(TextMove(0));
        anim = DOTween.Sequence();
        anim.Append(stars[0].transform.DOScale(1.4f, 0.4f));
        anim.AppendCallback(() => Vibration());
        anim.Append(stars[1].transform.DOScale(1.4f, 0.4f));
        anim.AppendCallback(() => Vibration());
        anim.Append(stars[2].transform.DOScale(1.4f, 0.4f));
        anim.AppendCallback(() => Vibration());
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(TextMove(finishPointText,5));
        ButtonInvoke();
    }
    private IEnumerator TextMove(float pointX, float controlDistance = 2f)
    {
        Vector2 movePoint = new Vector2(pointX, text.localPosition.y);
        while (Vector2.Distance(text.localPosition,movePoint) > controlDistance)
        {
            text.localPosition = Vector2.MoveTowards
                (text.localPosition, 
                    movePoint, 
                    speed * Time.deltaTime);
            yield return null;
        }
    }

    private void ButtonInvoke()
    {
        text.localPosition = new Vector2(startPointText, text.localPosition.y);
        TextHide();
        next.gameObject.GetComponent<Button>().onClick.Invoke();
    }

    private void TextHide()
    {
        DOTween.KillAll();
        anim.Kill();
        Hide();

    }
    private void Hide()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].transform.localScale = hide;
        }
    }
    private void Vibration()
    {
        MMVibrationManager.Haptic(HapticTypes.MediumImpact, false, true, this);
    }
}
