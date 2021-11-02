using UnityEngine;

public class SelectStickman : MonoBehaviour
{
    [SerializeField] MoveStickmans moveStickmans;
    private void Start()
    {
        moveStickmans.PathFail += FailConect;
    }
    public int Action(GameObject stickman)
    {
        return stickman.GetComponent<IColor>().ColorIndex();
    }
    public void FailConect(GameObject ferstStik)
    {
        var anim = ferstStik.GetComponent<Animator>();
        anim.SetBool("NoWay", true);
        anim.SetBool("Select", false);
    }
}
