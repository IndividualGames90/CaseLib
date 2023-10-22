using UnityEngine;

namespace IndividualGames.CaseLib.DI
{
    /// <summary>
    /// Container for ChangeableData structs.
    /// Make a struct ChangeableData : IChangeableData to use with Changeable DI.
    /// </summary>
    public interface IChangeableData
    { }

    /// <summary>
    /// This is an example holding values to emit on change.
    /// </summary>
    public struct ExampleChangeableData : IChangeableData
    {
        public Vector3 vector3Data;
        public string stringData;
        public int intData;
    }
}