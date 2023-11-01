using IndividualGames.CaseLib.DI;
using IndividualGames.CaseLib.Signalization;
using IndividualGames.OpenLib.Pattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace IndividualGames.CaseLib.Hyper
{
    /// <summary>
    /// GameObject Spawner that uses a SpawnableList to key out the prefabs.
    /// </summary>
    public class Spawner : MonoBehaviour, IGameObjectFactory, IInitializable
    {
        /// <summary> Emit to diminish spawn count. </summary>
        public EmitOnlySignal SpawnMinusOne;

        [SerializeField] private SpawnableList _spawnableList;

        [SerializeField] protected int _spawnIntervalSeconds;
        [SerializeField] protected int _spawnCountMax;

        private Stopwatch _timer = new();
        private int _spawnCountCurrent = 0;

        private Dictionary<int, GameObject> _spawnedObjects = new();

        /// <summary> Spawn callback. </summary>
        protected BasicSignal SpawnNow = new();

        public bool Initialized { get; set; }

        public void Init()
        {
            foreach (var spawnable in _spawnableList.spawnables)
            {
                _spawnedObjects.TryAdd(spawnable.name.GetHashCode(), spawnable);
            }

            _timer.Start();
            SpawnMinusOne = new(OnSpawnMinusOne);
        }

        private void FixedUpdate()
        {
            if (_timer.Elapsed.TotalSeconds < _spawnIntervalSeconds
                && _spawnCountCurrent < _spawnCountMax)
            {
                return;
            }

            _timer.Restart();
            SpawnNow.Emit();
        }

        public void OnSpawnMinusOne()
        {
            _spawnCountCurrent--;
        }

        public GameObject Create(GameObject createThis, Vector3 position, Quaternion rotation)
        {
            var key = createThis.name.GetHashCode();
            _spawnedObjects.TryGetValue(key, out var go);
            if (go != null)
            {
                _spawnCountCurrent++;
                return Instantiate(go, position, rotation);
            }
            else
            {
                throw new KeyNotFoundException($"{nameof(Spawner)}: Key not found for {createThis.name}.");
            }
        }

        public GameObject Create(Type createThis, Vector3 position, Quaternion rotation)
        {
            var key = createThis.Name.GetHashCode();
            _spawnedObjects.TryGetValue(key, out var go);
            if (go != null)
            {
                _spawnCountCurrent++;
                return Instantiate(go, position, rotation);
            }
            else
            {
                throw new KeyNotFoundException($"{nameof(Spawner)}: Key not found for {createThis.Name}.");
            }
        }

        public GameObject Create(int key)
        {
            throw new System.NotImplementedException();
        }

        object IFactory.Create(int key)
        {
            throw new System.NotImplementedException();
        }
    }
}