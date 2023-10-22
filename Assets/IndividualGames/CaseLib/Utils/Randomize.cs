using UnityEngine;

namespace IndividualGames.CaseLib.Utils
{
    /// <summary>
    /// Encapsulates UnityEngine.Random for ease-of-use.
    /// </summary>
    public static class Randomize
    {
        public static Vector3 RandomVector3(float minX = 0f, float maxX = 10f,
                                            float minY = 0f, float maxY = 10f,
                                            float minZ = 0f, float maxZ = 10f)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            float randomZ = Random.Range(minZ, maxZ);

            return new Vector3(randomX, randomY, randomZ);
        }
    }
}