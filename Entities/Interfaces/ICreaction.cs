namespace _4Create.Entities.Interfaces
{
    public interface ICreaction
    {
        #region Properties
        /// <summary>
        /// Data will represent time when each instance has been created.
        /// </summary>
        DateTime CreatedAt { get; set; }
        #endregion
    }
}
