using UnityEngine;

[CreateAssetMenu(fileName = "AttemptScore") ]
public class Attempt : ScriptableObject
{
    public int attemptNumber = 1;
    public Next_Button next_;
    public Restart restart;
    public void GetRestart(Restart rest)
    {
        restart = rest;
    }
    public void GetNext(Next_Button next)
    {
        next_ = next;
    }
    public int GetAttempt()
    {
        return attemptNumber;
    }
    public void AddAttempt()
    {
        attemptNumber++;
    }
    public void RemoveAttempt()
    {
        attemptNumber = 1;
    }
}
