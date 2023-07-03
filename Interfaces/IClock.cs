namespace MudBlazorOnlineShop.Interfaces
{
    /// <summary>
    /// Represents a time client for retrieving date and time information.
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// Gets the current UTC date and time.
        /// </summary>
        /// <returns>The current UTC date and time.</returns>
        DateTime GetDateUtc();

        /// <summary>
        /// Gets the current local date and time.
        /// </summary>
        /// <returns>The current local date and time.</returns>
        DateTime GetLocalDate();
    }
}