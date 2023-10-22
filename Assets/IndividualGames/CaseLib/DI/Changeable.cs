using IndividualGames.CaseLib.Signalization;

namespace IndividualGames.CaseLib.DI
{
    /// <summary>
    /// Changeable state object. DI.
    /// </summary>
    public interface IChangeable
    {
        virtual int ID { get { return 0; } set { } }
        virtual IBasicSignal OnValueChanged { get { return null; } }///Used for nameof()
    }

    /// <summary>
    /// Changeable state object with two parameters;
    /// </summary>
    public interface IChangeable<T> : IChangeable
    {
        new int ID { get { return 0; } set { } }
        BasicSignal<T> OnValueChanged { get; set; }

        void OnChange(T changedData);
    }
}