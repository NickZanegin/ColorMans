using UnityEngine;

public class SelectParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particles;
    public void Select(Vector3 stickman, int index)
    {
        ParticleSystem particleSelect;
        if (index == 1)
        {
            particleSelect = particles[0];
        }
        else if(index == 2)
        {
            particleSelect = particles[1];
        }
        else
        {
            particleSelect = particles[2];
        }
        particleSelect.transform.position = stickman;
        particleSelect.Play();
    }
}
