namespace PayLoadAPI.VModels
{
    public class PayLoadResponseResultV2Model
    {  /// <summary>
       /// Gets or sets a value indicating whether success.
       /// </summary>
        public bool success { get; set; } = default;
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string message { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public PayLoadResponseV2Model data { get; set; } = null!;
    }
}
