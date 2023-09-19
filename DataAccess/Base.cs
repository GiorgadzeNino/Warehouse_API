using System;

namespace BTUProject.DataAccess
{
    public class Base
    {
        //public long Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
