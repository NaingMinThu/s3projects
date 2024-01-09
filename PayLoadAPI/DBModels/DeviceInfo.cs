using System;
using System.Collections.Generic;

namespace PayLoadAPI.DBModels;

public partial class DeviceInfo
{
    public string DeviceId { get; set; } = null!;

    public string? DeviceType { get; set; }

    public string? DeviceName { get; set; }

    public string? GroupId { get; set; }

    public string? DataType { get; set; }

    public bool FullPowerMode { get; set; }

    public bool ActivePowerControl { get; set; }

    public int? FirmwareVersion { get; set; }

    public int? Temperature { get; set; }

    public int? Humidity { get; set; }

    public int? Version { get; set; }

    public string? MessageType { get; set; }

    public bool Occupancy { get; set; }

    public int? StateChanged { get; set; }

    public long Timestamp { get; set; }
}
