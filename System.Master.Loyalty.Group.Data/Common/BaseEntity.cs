using System.Master.Loyalty.Group.Data.Enums;

namespace System.Master.Loyalty.Group.Entitys.Common
{
    public class BaseEntity
    {

        public int Id { get; set; }
        
        public Status Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

    }
}
