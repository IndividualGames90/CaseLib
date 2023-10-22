using UnityEngine;
using UnLevel.IndividualGames.Player;

namespace IndividualGames.CaseLib.Control
{
    /// <summary>
    /// Leads a Follower.
    /// </summary>
    public class FollowLead : MonoBehaviour
    {
        [SerializeField] int repeatInterval;
        [SerializeField] bool randomMoving;

        public Transform Follow { get; set; }
        public bool Following { get; set; }

        public void Init(Follower follower)
        {
            Following = true;
            follower.Follow = transform;

            if (randomMoving)
            {
                InvokeRepeating(nameof(RandomMove), 0f, repeatInterval);
            }
        }

        public void RandomMove()
        {
            if (Following)
            {
                var x = transform.position.x + Random.Range(-10, 10);
                var z = transform.position.z + Random.Range(-10, 10);

                transform.position = new Vector3(x, 0f, z);
            }
        }
    }
}