using System;
using UnityEngine;

public class RayComand : MonoBehaviour
{
    [SerializeField] Controller controller;
    static RayComand comand;
    [SerializeField] SelectStickman select;
    [SerializeField] MoveStickmans move;
    [SerializeField] SelectParticle particle;
    int fertsStickmanColor;
    int lastStickmanColor;
    GameObject ferstStik;

    public Action<GameObject> selectEvent;
    public Action UnSelectEvent;
    private void Start()
    {
        controller.tap += FerstClick;
        comand = this;
    }
    public void FerstClick(GameObject stickman)
    {
        fertsStickmanColor = select.Action(stickman);
        var anim = stickman.GetComponent<Animator>();
        anim.SetBool("Select", true);
        anim.SetBool("NoWay", false);
        ferstStik = stickman;
        move.addFerstStik(stickman);
        particle.Select(stickman.transform.position, fertsStickmanColor);
        selectEvent?.Invoke(stickman);
        controller.tap -= FerstClick;
        controller.tap += LastClick;
    }
    public void LastClick(GameObject stickman)
    {
        lastStickmanColor = select.Action(stickman);
        particle.Select(stickman.transform.position, lastStickmanColor);
        if (lastStickmanColor == fertsStickmanColor && ferstStik != stickman)
        {
            controller.Disable();
            var anim = stickman.GetComponent<Animator>();
            anim.SetBool("Select", true);
            anim.SetBool("NoWay", false);
            move.Action(stickman);
            fertsStickmanColor = -1;
            lastStickmanColor = -1;
        }
        else if(ferstStik == stickman)
        {
            ferstStik.GetComponent<Animator>().SetBool("Select", false);
            UnSelectEvent?.Invoke();
        }
        else
        {
            select.FailConect(ferstStik);
            UnSelectEvent?.Invoke();

        }
        controller.tap -= LastClick;
        controller.tap += FerstClick;
    }
    public static void EnableController() => comand.EnableControll();

    private void EnableControll()
    {
        controller.enabled = true;
    }
}
