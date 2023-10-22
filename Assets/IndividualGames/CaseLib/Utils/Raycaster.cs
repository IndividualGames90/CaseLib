using UnityEngine;

namespace IndividualGames.CaseLib.Utils
{
    //TODO: This class has layer dependencies, make this generic.
    /// <summary>
    /// Raycast encapsulation for specific use cases.
    /// </summary>
    public static class Raycaster
    {
        private static RaycastHit m_hit;


        /// <summary> Detect if we are hitting ground layer with down vector. </summary>
        public static (bool, RaycastHit) HitGround(Vector3 a_origin, float a_maxDistance)
        {
            return (Physics.Raycast(a_origin,
                                    Vector3.down,
                                    out m_hit,
                                    a_maxDistance,
                                    Layers.Ground),
                    m_hit);
        }

        /// <summary> Detect if we are hitting ground layer with ray. </summary>
        public static (bool, RaycastHit) HitGround(Ray a_ray, float a_maxDistance)
        {
            return (Physics.Raycast(a_ray.origin,
                                    a_ray.direction,
                                    out m_hit,
                                    a_maxDistance,
                                    Layers.Ground),
                    m_hit);
        }

        /// <summary> Detect if we are hitting player layer with ray. </summary>
        public static (bool, RaycastHit) HitPlayer(Ray a_ray, float a_maxDistance)
        {
            return (Physics.Raycast(a_ray,
                                    out m_hit,
                                    a_maxDistance,
                                    Layers.Player),
                    m_hit);
        }

        /// <summary> Detect if we are hitting player layer with origin and direction. </summary>
        public static (bool, RaycastHit) HitPlayer(Vector3 a_origin, Vector3 a_direction, float a_maxDistance)
        {
            return (Physics.Raycast(a_origin,
                                    a_direction,
                                    out m_hit,
                                    a_maxDistance,
                                    Layers.Player),
                    m_hit);
        }



        /// <summary> Debug rays by drawing </summary>
        private static void RayDebugger(Ray a_ray, float a_maxDistance)
        {
            Debug.DrawRay(a_ray.origin, a_ray.direction * a_maxDistance, Color.red, 5f);
        }
    }
}