/**************************************************
 * Mã sinh viên: 202419021
 * Họ tên: Phạm Đình Vũ
 **************************************************/

using TeachingDeviceAllocation.Enums;

namespace TeachingDeviceAllocation.Models;

public class ProjectorRemote : TeachingDevice
{
    public int BatteryLevel { get; }

    public ProjectorRemote(string id, string name, string storageLocation, int batteryLevel, DeviceStatus status = DeviceStatus.Available)
        : base(id, name, storageLocation, status)
    {
        BatteryLevel = Math.Clamp(batteryLevel, 0, 100);
    }

    // Sẵn sàng khi Available và pin từ 20% trở lên
    public override bool IsReadyForUse() => Status == DeviceStatus.Available && BatteryLevel >= 20;

    // Điểm ưu tiên bằng mức pin
    public override double GetDefaultPriorityScore() => BatteryLevel;

    public override string ToString() => $"[ĐK Máy Chiếu] Mã: {Id} | Tên: {Name} | Vị trí: {StorageLocation} | Pin: {BatteryLevel}% | TT: {Status}";
}