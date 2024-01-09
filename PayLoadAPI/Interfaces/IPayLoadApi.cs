using PayLoadAPI.VModels;

namespace PayLoadAPI.Interfaces
{
    public interface IPayLoadApi
    {
        /// <summary>
        /// Create PayLoad Info
        /// </summary>
        /// <param name="model">payload info data model</param>
        /// <returns>A Message.</returns>
        Task<Message> Create(PayLoadRequestModel model);
        /// <summary>
        /// Update PayLoad Info
        /// </summary>
        /// <param name="model">payload info data model</param>
        /// <returns>A Message.</returns>
        Task<Message> Update(PayLoadRequestModel model);
        /// <summary>
        /// Delete PayLoad Info
        /// </summary>
        /// <param name="device_id">device_id to delete</param>
        /// <returns>A Message.</returns>
        Task<Message> Delete(string device_id);
        /// <summary>
        /// Retrieve the payload information by ID 
        /// </summary>
        /// <param name="device_id">device id to search for</param>
        /// <returns>A Message.</returns>
        Task<PayLoadResponseResultV1Model> ReadV1(string device_id);
        /// <summary>
        /// Retrieve the payload information by ID 
        /// </summary>
        /// <param name="device_id">device id to search for</param>
        /// <returns>A Message.</returns>
        Task<PayLoadResponseResultV2Model> ReadV2(string device_id);
    }
}
