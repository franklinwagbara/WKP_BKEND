using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IDeskRepository: IBaseRepository<MyDesk>
    {
       Task<int> GetStaffDeskCount(int StaffId); 
       Task<int> GetStaffAppProcessingDeskCount(int StaffId);
       Task<MyDesk?> GetDeskByDeskId(int DeskId);
       Task<MyDesk?> GetDeskByDeskIdAppIdWithStaff(int DeskId, int AppId, bool? HasWork = null);
       Task<MyDesk?> GetDeskByStaffIdAppIdWithStaff(int StaffId, int AppId, bool? HasWork = null);
       Task<MyDesk?> GetDeskByStaffTierAppIdWithStaffSBU(int Tier, int AppId, bool? HasWork = null);
    }
}