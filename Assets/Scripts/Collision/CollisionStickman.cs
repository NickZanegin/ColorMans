using System;
using UnityEngine;
using MoreMountains.NiceVibrations;

namespace Collisions
{
    public class CollisionStickman : MonoBehaviour
    {
        GameObject lastStickman;
        ParticleSystem explosion;
        SelectActive select;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == lastStickman)
            {
                explosion = GetComponent<IColor>().GetParticle();
                explosion.transform.position = transform.position;
                explosion.Play();
                GetComponent<Move>().waypoints.Clear();
                Destroy(lastStickman);
                LvlManager.CheckLvl();
                select.StopSelect();
                MMVibrationManager.Haptic(HapticTypes.MediumImpact, false, true, this);
                Destroy(gameObject);
                Controller.RayComand.EnableController();
            }
        }

        /*public void Update()
        {
            if (Vector3.Distance(gameObject.transform.position, lastStickman.transform.position) < 1)
            {
                explosion = GetComponent<IColor>().GetParticle();
                explosion.transform.position = transform.position;
                explosion.Play();
                GetComponent<Move>().waypoints.Clear();
                Destroy(lastStickman);
                LvlManager.CheckLvl();
                select.StopSelect();
                MMVibrationManager.Haptic(HapticTypes.MediumImpact, false, true, this);
                Destroy(gameObject);
                Controller.RayComand.EnableController();
            }
        }*/
        public void addLinks(GameObject stickman, SelectActive select)
        {
            lastStickman = stickman;
            this.select = select;
        }
    }
}
