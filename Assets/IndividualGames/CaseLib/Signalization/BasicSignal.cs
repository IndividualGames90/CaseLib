using System;

namespace IndividualGames.CaseLib.Signalization
{
    /// <summary>
    /// DI for BasicSignal.
    /// </summary>
    public interface IBasicSignal
    {
        public abstract void Connect(Action a_action);
        public abstract void Disconnect(Action a_action);
        public abstract void Emit();
    }

    /// <summary>
    /// Basic Signal for action.
    /// </summary>
    public class BasicSignal : IBasicSignal
    {
        private Action m_action;


        public void Connect(Action a_action)
        {
            m_action += a_action;
        }

        public void Disconnect(Action a_action)
        {
            m_action -= a_action;
        }

        public void Emit()
        {
            m_action?.Invoke();
        }
    }


    /// <summary>
    /// Basic Signal for action with single parameter.
    /// </summary>
    public class BasicSignal<T> : BasicSignal
    {
        private Action<T> m_action;


        public void Connect(Action<T> a_action)
        {
            m_action += a_action;
        }

        public void Disconnect(Action<T> a_action)
        {
            m_action -= a_action;
        }

        public void Emit(T a_parameter)
        {
            m_action?.Invoke(a_parameter);
        }
    }

    /// <summary>
    /// Basic Signal for action with two parameters.
    /// </summary>
    public class BasicSignal<T1, T2> : BasicSignal
    {
        private Action<T1, T2> m_action;


        public void Connect(Action<T1, T2> a_action)
        {
            m_action += a_action;
        }

        public void Disconnect(Action<T1, T2> a_action)
        {
            m_action -= a_action;
        }

        public void Emit(T1 a_first, T2 a_second)
        {
            m_action?.Invoke(a_first, a_second);
        }
    }
}
