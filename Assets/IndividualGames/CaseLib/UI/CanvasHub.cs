using IndividualGames.CaseLib.DataStructures;
using IndividualGames.CaseLib.DI;
using IndividualGames.CaseLib.Signalization;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IndividualGames.CaseLib.UI
{
    /// <summary>
    /// Signal handler for changing canvas elements. Have to be located on Canvas.
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public class CanvasHub : SingletonBehavior<CanvasHub>, IInitializable
    {
        [SerializeField] Canvas canvas;

        private Dictionary<int, IBasicSignal> uiSignals = new();

        public bool Initialized { get; set; }

        public void Init()
        {
            InitializeChangeables();
        }

        /// <summary> Acquire all changeables under this gameobject. </summary>
        private void InitializeChangeables()
        {
            if (canvas == null)
            {
                canvas = transform.GetComponent<Canvas>();
            }

            var changeables = canvas.GetComponentsInChildren<IChangeable>(true);

            foreach (var changeable in changeables)
            {
                Type changeableType = changeable.GetType();
                var onValueChanged = (IBasicSignal)changeableType
                            .GetProperty(nameof(IChangeable.OnValueChanged))?
                            .GetValue(changeable, null);

                uiSignals.TryAdd(changeable.ID, onValueChanged);
            }
        }

        /// <summary> Acquire LabelChangeable with given key. </summary>
        public IBasicSignal AcquireLabelChangeableSignal(int key)
        {
            if (!Initialized)
            {
                Init();
            }

            if (uiSignals.TryGetValue(key, out var changeSignal))
            {
                return changeSignal;
            }

            return null;
        }
    }
}