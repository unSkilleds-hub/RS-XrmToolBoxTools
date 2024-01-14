using System;

namespace RS_Security_Center
{
    public class SystemUserObj
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDisabled { get; set; }
    }
}
