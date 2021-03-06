using UnityEngine;

public class Blue : MonoBehaviour, IColor
{
    [SerializeField] private ParticleSystem explosion;
    public int line;
    public int column;
    public Gradient lineColor;
    public int ColorIndex()
    {
        return 1;
    }
    public int GetLine()
    {
        return line;
    }
    public int GetColumn()
    {
        return column;
    }
    public ParticleSystem GetParticle()
    {
        return explosion;
    }
    public Gradient GetLineColor()
    {
        return lineColor;
    }
}
