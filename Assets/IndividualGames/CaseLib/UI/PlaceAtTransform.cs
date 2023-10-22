using IndividualGames.CaseLib.DI;
using IndividualGames.CaseLib.Signalization;
using UnityEngine;

namespace IndividualGames.CaseLib.UI
{
    /// <summary>
    /// Place a UI element at a certain screen position when value is changed.
    /// WARNING: This class is wrong, it should be using a Changeable class the implement all these change stuff. Like UIChangeable.
    /// </summary>
    public class PlaceAtTransform : MonoBehaviour, IChangeable<Vector3>
    {
        public int ID { get { return id; } set { } }
        private int id;

        /// <summary> Emit with new location to update. </summary>
        public BasicSignal<Vector3> OnValueChanged { get; set; } = new();

        private RectTransform rect;
        private Camera main;

        private void Awake()
        {
            id = IncrementalIDMaker.GenerateID(gameObject.name);

            main = Camera.main;
            OnValueChanged.Connect((V3) => OnChange(V3));
            rect = GetComponent<RectTransform>();
        }

        public void PlaceAt(Vector3 pos)
        {
            rect.position = main.WorldToScreenPoint(pos);
            //var newPositon = main.WorldToScreenPoint(pos);
            //var smooth = Vector3.SmoothDamp(rect.position, newPositon, ref velocity, );
        }

        public void OnChange(Vector3 changedValue)
        {
            PlaceAt(changedValue);
        }
    }
}