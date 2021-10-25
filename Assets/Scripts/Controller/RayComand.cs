using System;
using UnityEngine;

public class RayComand : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] SelectStickman select;
    [SerializeField] MoveStickmans move;
    int fertsStickmanColor;
    int lastStickmanColor;
    GameObject ferstStik;
    GameObject lastStik;

    public Action<GameObject> selectEvent;
    public Action UnSelectEvent;
    private void Start()
    {
        controller.tap += FerstClick;
    }
    public void FerstClick(GameObject stickman)
    {
        fertsStickmanColor = select.Action(stickman);
        stickman.GetComponent<Animator>().SetBool("Select", true);
        ferstStik = stickman;
        move.addFerstStik(stickman);
        selectEvent?.Invoke(stickman);
        controller.tap -= FerstClick;
        controller.tap += LastClick;
    }
    public void LastClick(GameObject stickman)
    {
        lastStickmanColor = select.Action(stickman);
        lastStik = stickman;
        if (lastStickmanColor == fertsStickmanColor)
        {
            move.Action(stickman);
            fertsStickmanColor = -1;
            lastStickmanColor = -1;
        }
        else
        {
            select.FailConect(ferstStik, lastStik);
            UnSelectEvent?.Invoke();
        }
        controller.tap -= LastClick;
        controller.tap += FerstClick;

    }
}
