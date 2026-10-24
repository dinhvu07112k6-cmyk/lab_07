/**************************************************
 * Mã sinh viên: 202419021
 * Họ tên: Phạm Đình Vũ
 **************************************************/

using TeachingDeviceAllocation.Enums;

namespace TeachingDeviceAllocation.Models;

public class AirConditionerRemote : TeachingDevice
{
    public IReadOnlySet<string> CompatibleRooms { get; }

    public AirConditionerRemote(string id, string name, string storageLocation, IEnumerable<string> compatibleRooms, DeviceStatus status = DeviceStatus.Available)
        : base(id, name, storageLocation, status)
    {
        CompatibleRooms = new HashSet<string>(compatibleRooms ?? Enumerable.Empty<string>());
    }

    public bool IsCompatibleWith(string roomId) => !string.IsNullOrWhiteSpace(roomId) && CompatibleRooms.Contains(roomId);

    // Sẵn sàng khi Available
    public override bool IsReadyForUse() => Status == DeviceStatus.Available;

    public override double GetDefaultPriorityScore() => 100.0;

    public override string ToString() => $"[ĐK Điều Hòa] Mã: {Id} | Tên: {Name} | Vị trí: {StorageLocation} | Tương thích: {string.Join(", ", CompatibleRooms)} | TT: {Status}";
}