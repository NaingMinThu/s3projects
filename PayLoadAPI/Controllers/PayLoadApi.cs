using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayLoadAPI.Logging;
using PayLoadAPI.DBModels;
using PayLoadAPI.VModels;
using static Azure.Core.HttpHeader;
using System.Text;
using System;
using System.Text.RegularExpressions;
using PayLoadAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace PayLoadAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PayLoadApi : IPayLoadApi
    {
        private readonly S3payLoadsContext db;
        private readonly ILoggerService logger;
        private readonly ResponseCommonMsg msg = new();
        private readonly CommonController common;
        /// <summary>
        /// Initializes a new instance of the <see cref="PayLoadApi"/> class.
        /// </summary>
        /// <param name="dbCon">The db con.</param>
        /// <param name="loggerService">The logger service.</param>
        public PayLoadApi(S3payLoadsContext dbCon, ILoggerService loggerService)
        {
            db = dbCon;
            logger = loggerService;
            common = new CommonController(loggerService);
        }
        /// <summary>
        /// Create PayLoad Info
        /// </summary>
        /// <param name="model">payload info data model</param>
        /// <returns></returns>
        /// <response code="400">Error in API Call</response>
        /// <response code="200">Success in API Call</response>
        [HttpPost]
        [Route("/api/v1/PayLoad/")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<Message> Create(PayLoadRequestModel model)
        {
            Message message = new() { success = false, message = msg.error };
            bool success = common.CheckModelIsNull(model, " calling payload info create api");
            if (success)
            {
                logger.Information("RequestValues:PayLoad:Create:Param:" + JsonConvert.SerializeObject(model));
                try
                {
                    DeviceInfo entity = new()
                    {
                        DeviceId = model.device_id,
                        DeviceName = model.device_name,
                        DeviceType = model.device_type,
                        GroupId = model.group_id,
                        DataType = model.data_type,
                        FullPowerMode = model.full_power_mode,
                        ActivePowerControl = model.active_power_control,
                        FirmwareVersion = model.firmware_version,
                        Temperature = model.temperature,
                        Humidity = model.humidity,
                        Version = model.version,
                        MessageType = model.message_type,
                        Occupancy = model.occupancy,
                        StateChanged = model.state_changed,
                        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                    };
                    db.DeviceInfos.Add(entity);
                    message.success = await db.SaveChangesAsync() > 0;
                    message.message = "";
                }
                catch (Exception ex)
                {
                    logger.Error((ex.InnerException != null ? ex.InnerException.Message : ex.Message) + " in calling payload info create api");
                }
            }
            return message;
        }

        /// <summary>
        /// Update the payload information by ID
        /// </summary>             
        /// <param name="model">payload data model</param>
        /// <returns></returns>
        /// <response code="400">Error in API Call</response>
        /// <response code="200">Success in API Call</response>
        [HttpPut]
        [Route("/api/v1/PayLoad/")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<Message> Update(PayLoadRequestModel model)
        {
            Message message = new() { success = false, message = msg.error };
            bool success = common.CheckModelIsNull(model, "calling payload info update api");
            if (success)
            {
                logger.Information("RequestValues:PayLoad:Update:Param:" + JsonConvert.SerializeObject(model));
                try
                {
                    DeviceInfo dataInfo = db.DeviceInfos.Where(x => x.DeviceId == model.device_id).Select(x => x).FirstOrDefault();
                    if (dataInfo != null)
                    {
                        dataInfo.DeviceName = model.device_name;
                        dataInfo.DeviceType = model.device_type;
                        dataInfo.GroupId = model.group_id;
                        dataInfo.DataType = model.data_type;
                        dataInfo.FullPowerMode = model.full_power_mode;
                        dataInfo.ActivePowerControl = model.active_power_control;
                        dataInfo.FirmwareVersion = model.firmware_version;
                        dataInfo.Temperature = model.temperature;
                        dataInfo.Humidity = model.humidity;
                        dataInfo.Version = model.version;
                        dataInfo.MessageType = model.message_type;
                        dataInfo.Occupancy = model.occupancy;
                        dataInfo.StateChanged = model.state_changed;
                        dataInfo.Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    }
                    message.success = await db.SaveChangesAsync() > 0;
                    message.message = "";
                }
                catch (Exception ex)
                {
                    logger.Error((ex.InnerException != null ? ex.InnerException.Message : ex.Message) + " in calling payload info update api");
                }
            }
            return message;
        }

        /// <summary>
        /// Delete the payload information by ID
        /// </summary>             
        /// <param name="device_id">device id to delete</param>
        /// <returns></returns>
        /// <response code="400">Error in API Call</response>
        /// <response code="200">Success in API Call</response>
        [HttpDelete]
        [Route("/api/v1/PayLoad/")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<Message> Delete(string device_id)
        {
            Message message = new() { success = false, message = msg.error };
            bool success = common.CheckIdIsNull(device_id, "calling payload info delete api");
            if (success)
            {
                logger.Information("RequestValues:PayLoad:Delete:Param:" + JsonConvert.SerializeObject(device_id));
                try
                {
                    DeviceInfo dataInfo = db.DeviceInfos.Where(x => x.DeviceId == device_id).Select(x => x).FirstOrDefault();
                    db.DeviceInfos.Remove(dataInfo);
                    message.success = await db.SaveChangesAsync() > 0;
                    message.message = "";
                }
                catch (Exception ex)
                {
                    logger.Error((ex.InnerException != null ? ex.InnerException.Message : ex.Message) + " in calling payload info delete api");
                }
            }
            return message;
        }

        /// <summary>
        /// Retrieve the payload information by ID 
        /// </summary>
        /// <param name="device_id">device id to search for</param>
        /// <response code="400">Error in API Call</response>
        /// <response code="200">Success in API Call</response>
        [HttpGet]
        [Route("/api/v1/PayLoadV1/")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<PayLoadResponseResultV1Model> ReadV1(string device_id)
        {
            bool success = common.CheckIdIsNull(device_id, "calling payload info v1 retrieve api");
            PayLoadResponseResultV1Model response = new() { success = false, message = msg.error };
            if (success)
            {
                logger.Information("RequestValues:PayLoadV1:Read:Param:" + JsonConvert.SerializeObject(device_id));
                try
                {
                    PayLoadResponseV1Model dataInfo = db.DeviceInfos.Where(x => x.DeviceId == device_id).Select(x => new PayLoadResponseV1Model()
                    {
                       device_id = x.DeviceId,
                       device_type = x.DeviceType,
                       device_name = x.DeviceName,
                       group_id = x.GroupId,
                       data_type = x.DataType,
                       data = new PayLoadDataV1()
                        {
                          full_power_mode= x.FullPowerMode,
                          active_power_control = x.ActivePowerControl,
                          firmware_version = x.FirmwareVersion,
                          temperature = x.Temperature,
                          humidity = x.Humidity
                        },
                       timestamp = x.Timestamp
                    }).FirstOrDefault();

                    response.success = dataInfo != null;
                    response.message = "";
                    response.data = dataInfo ?? new PayLoadResponseV1Model() { };
                }
                catch (Exception ex)
                {
                    logger.Error((ex.InnerException != null ? ex.InnerException.Message : ex.Message) + " in calling payload info v1 retrieve api!");
                }
            }
            return response;
        }

        /// <summary>
        /// Retrieve the payload information by ID 
        /// </summary>
        /// <param name="device_id">device id to search for</param>
        /// <response code="400">Error in API Call</response>
        /// <response code="200">Success in API Call</response>
        [HttpGet]
        [Route("/api/v1/PayLoadV2/")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest, Type = typeof(string))]
        //[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<PayLoadResponseResultV2Model> ReadV2(string device_id)
        {
            bool success = common.CheckIdIsNull(device_id, "calling payload info v2 retrieve api");
            PayLoadResponseResultV2Model response = new() { success = false, message = msg.error };
            if (success)
            {
                logger.Information("RequestValues:PayLoadV2:Read:Param:" + JsonConvert.SerializeObject(device_id));
                try
                {
                    PayLoadResponseV2Model dataInfo = db.DeviceInfos.Where(x => x.DeviceId == device_id).Select(x => new PayLoadResponseV2Model()
                    {
                        device_id = x.DeviceId,
                        device_type = x.DeviceType,
                        device_name = x.DeviceName,
                        group_id = x.GroupId,
                        data_type = x.DataType,
                        data = new PayLoadDataV2()
                        {
                            version = x.Version,
                            message_type = x.MessageType,
                            occupancy = x.Occupancy,
                            state_changed = x.StateChanged
                        },
                        timestamp = x.Timestamp
                    }).FirstOrDefault();

                    response.success = dataInfo != null;
                    response.message = "";
                    response.data = dataInfo ?? new PayLoadResponseV2Model() { };
                }
                catch (Exception ex)
                {
                    logger.Error((ex.InnerException != null ? ex.InnerException.Message : ex.Message) + " in calling payload info v2 retrieve api!");
                }
            }
            return response;
        }
    }
}
