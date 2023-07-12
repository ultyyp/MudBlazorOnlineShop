using OnlineShopFrontend.Interfaces;

namespace OnlineShopFrontend.Services
{
    /// <summary>
    /// Represents an in-memory implementation of a time client for retrieving date and time information.
    /// </summary>
    public class CurrentClock : IClock
    {
        /// <summary>
        /// Gets the current UTC date and time.
        /// </summary>
        /// <returns>The current UTC date and time.</returns>
        public DateTime GetDateUtc()
        {
            return DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the current local date and time.
        /// </summary>
        /// <returns>The current local date and time.</returns>
        public DateTime GetLocalDate()
        {
            return DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Local);
        }
    }
}