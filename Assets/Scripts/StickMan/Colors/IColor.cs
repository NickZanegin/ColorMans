using UnityEngine;
public interface IColor
{
    public int ColorIndex();
    public int GetLine();
    public int GetColumn();
    public ParticleSystem GetParticle();
    public Gradient GetLineColor();
}
