namespace IndividualGames.CaseLib.DI
{
    /// <summary>
    /// Object carrier.
    /// </summary>
    public class Container : IContainer
    {
        public object Value { get; set; }

        public Container(object cargo)
        {
            Value = cargo;
        }
    }

    /// <summary>
    /// Object container for DI.
    /// </summary>
    public interface IContainer
    {
        object Value { get; set; }
    }
}