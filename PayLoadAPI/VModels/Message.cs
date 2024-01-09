namespace PayLoadAPI.VModels
{
    public class Message
    {
        /// <summary>
        /// Gets or sets a value indicating whether success.
        /// </summary>
        public bool success { get; set; } = default;
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string message { get; set; } = String.Empty;
    }
}
