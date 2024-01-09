namespace PayLoadAPI.VModels
{
    public class PayLoadRequestModel
    {
        public string device_id { get; set; } = null!;

        public string? device_type { get; set; }

        public string? device_name { get; set; }

        public string? group_id { get; set; }

        public string? data_type { get; set; }

        public bool full_power_mode { get; set; }

        public bool active_power_control { get; set; }

        public int? firmware_version { get; set; }

        public int? temperature { get; set; }

        public int? humidity { get; set; }

        public int? version { get; set; }

        public string? message_type { get; set; }

        public bool occupancy { get; set; }

        public int? state_changed { get; set; }
    }
}
