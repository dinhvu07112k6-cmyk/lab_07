/**************************************************
 * Mã sinh viên: 202419021
 * Họ tên: Phạm Đình Vũ
 **************************************************/

using TeachingDeviceAllocation.Enums;

namespace TeachingDeviceAllocation.Models;

public class WirelessMicrophone : TeachingDevice
{
    public int BatteryLevel { get; }
    public int SignalQuality { get; }

    public WirelessMicrophone(string id, string name, string storageLocation, int batteryLevel, int signalQuality, DeviceStatus status = DeviceStatus.Available)
        : base(id, name, storageLocation, status)
    {
        BatteryLevel = Math.Clamp(batteryLevel, 0, 100);
        SignalQuality = Math.Clamp(signalQuality, 0, 100);
    }

    // Sẵn sàng khi Available, pin >= 30% và sóng >= 40%
    public override bool IsReadyForUse() => Status == DeviceStatus.Available && BatteryLevel >= 30 && SignalQuality >= 40;

    // Điểm ưu tiên bằng trung bình cộng pin và sóng
    public override double GetDefaultPriorityScore() => (BatteryLevel + SignalQuality) / 2.0;

    public override string ToString() => $"[Micro Không Dây] Mã: {Id} | Tên: {Name} | Vị trí: {StorageLocation} | Pin: {BatteryLevel}% | Sóng: {SignalQuality}% | TT: {Status}";
}