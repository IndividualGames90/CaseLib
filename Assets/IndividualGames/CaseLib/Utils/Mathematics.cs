using UnityEngine;

namespace IndividualGames.CaseLib.Utils
{
    /// <summary>
    /// Math related calls not covered by Unity.
    /// </summary>
    public static class Mathematics
    {
        private static float m_epsilon = 0.001f;
        private static float m_nearby = 1f;

        /// <summary> Calculate if this value is close to zero. </summary>
        public static bool AlmostZero(float a_value)
        {
            return Mathf.Abs(a_value) < m_epsilon;
        }

        /// <summary> Calculate if both values are close to zero. </summary>
        public static bool AlmostZero(float a_first, float a_second)
        {
            return AlmostZero(a_first) && AlmostZero(a_second);
        }

        /// <summary> Check if two vectors are near one another. </summary>
        public static bool Nearby(Vector3 a_first, Vector3 a_second)
        {
            float distanceSquared = (a_first - a_second).sqrMagnitude;

            return distanceSquared < m_nearby;
        }
    }

}