using System;

namespace API.DTOs
{
    public class MPForCreationDto
    {
        public int MasterPartId { get; set; }
        public string PartNumber { get; set; }
        public string MlsPn { get; set; }
        public string PartDescription { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerDivisionId { get; set; }
        public string CustomerDivisionName { get; set; }
        public int MlsDivisionId { get; set; }
        public string MlsDivisionName { get; set; }
        public bool IsActive { get; set; }
        public int PartTypeId { get; set; }
        public string PartTypeName { get; set; }
        public int? Jan1Qoh { get; set; }
        public int? Jan1Rec { get; set; }
        public int? Jan1Ship { get; set; }
        public int? Qoh { get; set; }
        public string Location { get; set; }
        public string HtsCode { get; set; }
        public string Notes { get; set; }
        
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public int AppUserId { get; set; }
    }
}