using Microsoft.AspNetCore.Mvc;
using PayLoadAPI.Interfaces;
using PayLoadAPI.Logging;
using PayLoadAPI.VModels;

namespace PayLoadAPI.Controllers
{
    public class LogInApi : Controller
    {
        private readonly ResponseCommonMsg msg = new();
        private readonly IJwtManager jWTManager;
        private readonly ILoggerService logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogInApi"/> class.
        /// </summary>
        /// <param name="jwtManager">The jwt manager.</param>
        /// <param name="loggerService">The logger service.</param>
        public LogInApi(IJwtManager jwtManager, ILoggerService loggerService)
        {
            jWTManager = jwtManager;
            logger = loggerService;
        }
        /// <summary>
        /// Login In to access other api.
        /// </summary>
        /// <returns></returns>
        /// <response code="400">Error in API Call</response>
        /// <response code="200">Success in API Call</response>
        [HttpGet]
        [Route("/api/v1/Authenticate")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, Type = typeof(string))]
        //[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public Message Authenticate()
        {
            logger.Information("LoginAPI:Authenticate:");
            Message message = new() { success = false, message = msg.error };
            try
            {
                var token = jWTManager.GetJWTToken();
                message.success = true;
                message.message = token.Token;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
            return message;
        }
    }
}
