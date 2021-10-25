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
        stickman.GetComponent<CapsuleCollider>().enabled = false;
        return stickman.GetComponent<IColor>().ColorIndex();
    }
    public void FailConect(GameObject ferstStik, GameObject lastStik)
    {
        ferstStik.GetComponent<CapsuleCollider>().enabled = true;
        lastStik.GetComponent<CapsuleCollider>().enabled = true;
    }
}
