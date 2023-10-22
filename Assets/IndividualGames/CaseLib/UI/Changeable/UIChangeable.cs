using IndividualGames.CaseLib.DI;
using IndividualGames.CaseLib.Signalization;
using System;
using UnityEngine;
using IContainer = IndividualGames.CaseLib.DI.IContainer;
using IInitializable = IndividualGames.CaseLib.DI.IInitializable;

namespace IndividualGames.CaseLib.UI
{
    /// <summary>
    /// A changing type of ui element.
    /// </summary>
    public abstract class UIChangeable<T> : MonoBehaviour, IChangeable<T>, IInitializable
    {
        public BasicSignal<T> OnValueChanged { get; set; } = new();

        /// <summary> Use for hash lookups in hubs.</summary>
        public int ID { get { return id; } set { } }
        private int id;

        public bool Initialized { get; set; } = false;

        /// <summary> Initialize with auto-incremental ID. </summary>
        public void Init()
        {
            Initialized = true;
            id = IncrementalIDMaker.GenerateID(gameObject.name);
            OnValueChanged.Connect(OnChange);
        }

        /// <summary> Initialize with cargo passed ID. </summary>
        public void Init(IContainer IDCargo)
        {
            try
            {
                id = (int)IDCargo.Value;
            }
            catch (InvalidCastException e)
            {
                Debug.Log($"ID Problem:\n Cargo mismatch for value {IDCargo.Value} with exception: \n{e}");
                return;
            }

            Initialized = true;
            OnValueChanged.Connect(OnChange);
        }

        public virtual void OnChange(T changedValue)
        { }
    }
}