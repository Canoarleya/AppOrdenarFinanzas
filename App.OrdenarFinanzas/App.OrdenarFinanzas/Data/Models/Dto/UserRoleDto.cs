using App.OrdenarFinanzas.Enumerations;
namespace App.OrdenarFinanzas.Data.Models.Dto
{
    public class UserRoleDto
    {
        public long RoleId { get; set; }
        public string Name { get; set; }
        public RoleType Type { get; set; }
    }

}
