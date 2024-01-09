using PayLoadAPI.VModels;

namespace PayLoadAPI.Interfaces
{
    public interface IJwtManager
    {
        /// <summary>
        /// Gets the j w t toen.
        /// </summary>
        /// <returns>A Tokens.</returns>
        Tokens GetJWTToken();
    }
}
