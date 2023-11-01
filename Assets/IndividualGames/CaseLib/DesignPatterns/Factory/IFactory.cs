using System;
using UnityEngine;

namespace IndividualGames.OpenLib.Pattern
{
    /// <summary>
    /// Essence of all factories.
    /// </summary>
    public interface IFactory
    {
        public object Create(int key);
    }

    /// <summary>
    /// Essence of all Unity factories.
    /// </summary>
    public interface IGameObjectFactory : IFactory
    {
        public new GameObject Create(int key);
        public GameObject Create(Type createThis, Vector3 position, Quaternion rotation);
        public GameObject Create(GameObject createThis, Vector3 position, Quaternion rotation);
    }
}