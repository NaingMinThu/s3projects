using PayLoadAPI.VModels;

namespace PayLoadAPI.Interfaces
{
    public interface ILogInApi
    {
        /// <summary>
        /// Authenticates the.
        /// </summary>
        /// <returns>A Message.</returns>
        Message Authenticate();
    }
}
