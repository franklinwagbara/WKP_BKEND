using WKP.Domain.Entities;

namespace WKP.Domain.Repositories
{
    public interface IDeskRepository: IBaseRepository<MyDesk>
    {
       Task<int> GetStaffDeskCount(int StaffId); 
       Task<int> GetStaffAppProcessingDeskCount(int StaffId);
    }
}