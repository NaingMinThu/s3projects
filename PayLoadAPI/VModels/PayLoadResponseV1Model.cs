namespace PayLoadAPI.VModels
{
    public class PayLoadResponseV1Model
    {
        public string device_id { get; set; } = null!;

        public string? device_type { get; set; }

        public string? device_name { get; set; }

        public string? group_id { get; set; }

        public string? data_type { get; set; }

        public PayLoadDataV1? data { get; set; }
        public long timestamp { get; set; }
    }
    public class PayLoadDataV1
    {
        public bool full_power_mode { get; set; }

        public bool active_power_control { get; set; }

        public int? firmware_version { get; set; }

        public int? temperature { get; set; }

        public int? humidity { get; set; }


    }
}
