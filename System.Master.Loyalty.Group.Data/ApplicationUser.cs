using Microsoft.AspNetCore.Identity;
using System.Master.Loyalty.Group.Data.Enums;

namespace System.Master.Loyalty.Group.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Nombre { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;

        public Status Status { get; set; }

        public int CreatedById { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? LastModifiedById { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public List<OrderData> Orders { get; set; }

        public ApplicationUser()
        {
            Orders = new List<OrderData>();
        }
    }
}
