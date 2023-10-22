using System;

namespace IndividualGames.CaseLib.Signalization
{
    /// <summary>
    /// Can be connected and changed to reflect value changes.
    /// </summary>
    public class ChangingProperty<T>
    {
        public T ChangingValue
        {
            get { return changingValue; }
            set
            {
                changingValue = value;
                changeSignal.Emit(changingValue);
            }
        }
        private T changingValue;

        private BasicSignal<T> changeSignal = new();

        public void Connect(Action<T> onChangeValue)
        {
            changeSignal.Connect(onChangeValue);
        }
    }
}