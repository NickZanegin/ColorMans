using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private bool access = false;
    [SerializeField] public int line;
    [SerializeField] public int column;
    [SerializeField] public bool up;
    [SerializeField] public bool right;
    [SerializeField] public bool down;
    [SerializeField] public bool left;
    public bool GetAccess()
    {
        return access;
    }
    public void Open()
    {
        access = true;
    }
    public void Close()
    {
        access = false;
    }
}
