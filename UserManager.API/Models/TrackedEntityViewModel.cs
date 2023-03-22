﻿namespace UserManager.API.Models
{
    public class TrackedEntityViewModel
    {
        public string CreatedBy { get; set; } = "";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = "";
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
