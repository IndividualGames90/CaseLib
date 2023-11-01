using UnityEngine;

namespace IndividualGames.CaseLib.DesignPattern
{
    /// <summary>
    /// Base class for SingletonComponent.
    /// </summary>
    public abstract class SingletonBehavior : MonoBehaviour
    {
        public abstract void OnAwake();

        public abstract void KeepDuplicates(bool keepDuplicates);
    }
}
