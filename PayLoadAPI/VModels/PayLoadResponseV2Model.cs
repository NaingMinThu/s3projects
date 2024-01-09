namespace PayLoadAPI.VModels
{
    public class PayLoadResponseV2Model
    {
        public string device_id { get; set; } = null!;

        public string? device_type { get; set; }

        public string? device_name { get; set; }

        public string? group_id { get; set; }

        public string? data_type { get; set; }

        public PayLoadDataV2? data { get; set; }
        public long timestamp { get; set; }

    }
    public class PayLoadDataV2
    {
        public int? version { get; set; }

        public string? message_type { get; set; }

        public bool occupancy { get; set; }

        public int? state_changed { get; set; }

    }
}
