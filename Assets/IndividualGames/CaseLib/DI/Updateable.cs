namespace IndividualGames.CaseLib.DI
{
    /// <summary>
    /// Can be updated.
    /// </summary>
    public interface IUpdateable
    {
        void Update();
    }

    /// <summary>
    /// Can be fixedupdated.
    /// </summary>
    public interface IFixedUpdateable
    {
        void FixedUpdate();
    }
}