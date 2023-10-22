namespace IndividualGames.CaseLib.DI
{
    /// <summary>
    /// Denotes an object that can be enabled or disabled.
    /// </summary>
    public interface IEnableable
    {
        void Enable();
        void Disable();
    }
}