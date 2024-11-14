namespace Interfaces;
using DTO;
public interface IAdmin
{
    public bool CreateAdmin(AdminDTO admin, string Password);
    public bool AdminExists(string email);
    public bool UpdateAdmin(AdminDTO admin);
    public bool SoftDeleteAdmin(int id);
    public List<AdminDTO> GetAllAdmins();
}
