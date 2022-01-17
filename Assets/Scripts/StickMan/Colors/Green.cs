using UnityEngine;

public class Green : MonoBehaviour, IColor
{
    [SerializeField] private ParticleSystem explosion;
    public int line;
    public int column;
    public Gradient lineColor;
    public int ColorIndex()
    {
        return 2;
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
