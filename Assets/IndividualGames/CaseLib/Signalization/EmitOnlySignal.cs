using System;

namespace IndividualGames.CaseLib.Signalization
{
    /// <summary>
    /// DI for EmitOnlySignal.
    /// </summary>
    public interface IEmitOnlySignal
    {
        public void Emit();
    }

    /// <summary>
    /// Only be emited as a callback.
    /// </summary>
    public class EmitOnlySignal : IEmitOnlySignal
    {
        private Action m_action;

        /// <summary> Have to pass the action here. Also initialize in Awake/Constructor. </summary>
        public EmitOnlySignal(Action a_action)
        {
            Connect(a_action);
        }

        private void Connect(Action a_action)
        {
            m_action += a_action;
        }

        private void Disconnect(Action a_action)
        {
            m_action -= a_action;
        }

        public void Emit()
        {
            m_action?.Invoke();
        }
    }
}
