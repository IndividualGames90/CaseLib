using System.Collections.Generic;
using UnityEngine;

namespace IndividualGames.CaseLib.Hyper
{
    [CreateAssetMenu(fileName = "SpawnableList", menuName = "IndividualGames/Hyper/SpawnableList")]
    public class SpawnableList : ScriptableObject
    {
        public List<GameObject> spawnables;
    }
}