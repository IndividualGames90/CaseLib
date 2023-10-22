using IndividualGames.CaseLib.Control;
using IndividualGames.CaseLib.DataStructures;
using System.Collections.Generic;
using UnityEngine;
using UnLevel.IndividualGames.Virus;

namespace IndividualGames.CaseLib.Hyper
{
    /// <summary>
    /// Universal spawner that uses a SpawnableList to key out the prefabs.
    /// WHAT IS THIS? THIS ISNT GENERIC AT ALL? FIX IT!
    /// </summary>
    public class Spawner : SingletonBehavior<Spawner>
    {
        [SerializeField] SpawnableList spawnableList;

        [SerializeField] GameObject virusPrefab;
        [SerializeField] GameObject followPrefab;
        [SerializeField] int spawnInterval;
        [SerializeField] int spawnLimit;

        private float spawnTimer;
        private int spawnCount = 0;
        private Dictionary<int, GameObject> spawnables = new();

        private void Awake()
        {
            foreach (var spawnable in spawnableList.spawnables)
            {
                spawnables.TryAdd(spawnable.name.GetHashCode(), spawnable);
            }
        }

        private void FixedUpdate()
        {
            spawnTimer += Time.fixedDeltaTime;

            if (spawnTimer > spawnInterval && spawnLimit > spawnCount)
            {
                SpawnVirus();
                spawnTimer = 0f;
                spawnCount++;
            }
        }

        public void SpawnVirus()
        {
            var go_vp = Instantiate(virusPrefab, transform.position, transform.rotation);
            var go_fp = Instantiate(followPrefab, transform.position, transform.rotation);

            var vc = go_vp.GetComponent<VirusController>();
            go_fp.GetComponent<FollowLead>().Init(vc);
            vc.Follow = go_fp.transform;
        }

        public void Spawn(GameObject keyObject, Vector3 position, Quaternion rotation)
        {
            var key = keyObject.name.GetHashCode();
            spawnables.TryGetValue(key, out var go);
            if (go != null)
            {
                Instantiate(go, position, rotation);
            }
            else
            {
                Debug.LogWarning("No such spawnable found.");
            }
        }
    }
}