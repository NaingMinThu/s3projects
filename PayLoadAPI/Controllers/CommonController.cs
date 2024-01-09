using Microsoft.AspNetCore.Mvc;
using PayLoadAPI.Logging;

namespace PayLoadAPI.Controllers
{
    public class CommonController
    {
        private readonly ILoggerService logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonController"/> class.
        /// </summary>
        /// <param name="loggerService">The logger service.</param>
        public CommonController(ILoggerService loggerService)
        {
            logger = loggerService;
        }
        /// <summary>
        /// Checks the model is null.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="apiName">The api name.</param>
        /// <returns>A bool.</returns>
        public bool CheckModelIsNull(object model, string apiName)
        {
            if (model == null)
            {
                logger.Error("Data Object Model is null in " + apiName + "!");
                return false;
            }
            else
            {
                return true;
            }
        } /// <summary>
          /// Checks the id is null.
          /// </summary>
          /// <param name="id">The id.</param>
          /// <param name="apiName">The api name.</param>
          /// <returns>A bool.</returns>
        public bool CheckIdIsNull(string id, string apiName)
        {
            if (string.IsNullOrEmpty(id))
            {
                logger.Error("ID is empty in " + apiName + "!");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
