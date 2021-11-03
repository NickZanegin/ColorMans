using UnityEngine;
using DG.Tweening;

public class SelectActive : MonoBehaviour
{
    [SerializeField] private RayComand command;
    [SerializeField] private MoveStickmans moveStickmans;
    [SerializeField] GameObject mesh;
    Vector3 scale;
    Tween scaler;
    GameObject selectStickman;
    bool select = false;
    private void Start()
    {
        scale = new Vector3(54, 54, 126.41f);
        command.selectEvent += StartSelect;
        command.UnSelectEvent += StopSelect;
        moveStickmans.Unselect += StopSelect;
    }
    public void StartSelect(GameObject stickman)
    {
        mesh.SetActive(true);
        scaler = mesh.transform.DOScale(scale, 1).SetLoops(-1, LoopType.Yoyo);
        selectStickman = stickman;
        select = true;
    }
    public void StopSelect()
    {
        mesh.SetActive(false);
        scaler.SetLoops(0);
        scaler.Complete();
        scaler.Kill();
        selectStickman = null;
    }
    private void Update()
    {
        if (selectStickman != null)
        {
            mesh.transform.position = selectStickman.transform.position;
        }
        else if(select)
        {
            StopSelect();
            select = false;
        }
    }
}
