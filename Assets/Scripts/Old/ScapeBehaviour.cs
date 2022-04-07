using UnityEngine;

namespace Game.Bixo.Sensor
{
    public class ScapeBehaviour : Sensor
    {
        private Vector3 ScapeFromAll()
        {
            Vector3 resp = Vector3.zero;
            foreach (Transform t in listOfTargets)
            {
                resp += transform.position - t.position;
            }
            return resp;
        }

        protected override void FixedUpdate()
        {
            if (listOfTargets.Count > 0)
            {
                mov.InDanger = true;
                mov.SetTarget(ScapeFromAll());
            }
            else
            {
                mov.InDanger = false;
            }
        }

        protected override void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(ObjTag))
            {
                listOfTargets.Remove(collision.transform);
                mov.SetTarget(null);
            }
        }
    }
}

