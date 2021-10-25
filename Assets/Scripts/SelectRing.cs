using UnityEngine;

public class SelectRing : MonoBehaviour
{
    [SerializeField] private RayComand command;
    [SerializeField] private MoveStickmans moveStickmans;
    ParticleSystem ring;
    GameObject selectStickman;
    private void Start()
    {
        command.selectEvent += StartParticle;
        command.UnSelectEvent += StopParticle;
        moveStickmans.Unselect += StopParticle;
        ring = GetComponent<ParticleSystem>();
    }
    private void StartParticle(GameObject stickman)
    {
        selectStickman = stickman;
        ring.Play();
    }
    private void StopParticle()
    {
        ring.Stop();
    }

    private void Update()
    {
        if(selectStickman != null)
        {
            transform.position = selectStickman.transform.position;

        }
        else
        {
            StopParticle();
        }
    }
}
