using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Container
    {
        public int ContainerId { get; set; }
        public string ContainerNoFF { get; set; }
        public string ContainerNoInt { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EtdDate")]
        public DateTime? EtdDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DepartureDate")]
        public DateTime? DepartureDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EtpDate")]
        public DateTime? EtpDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "PortDate")]
        public DateTime? PortDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EtaDate")]
        public DateTime? EtaDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ArrivalDate")]
        public DateTime? ArrivalDate { get; set; }

        public string BOL { get; set; }
        public string AMS { get; set; }
        public string Invoice { get; set; }
        public string FreightForwarder { get; set; }
        public string Destination { get; set; }
        public string DeparturePort { get; set; }
        public string ArrivalPort { get; set; }
        public int ContainerStatusId { get; set; }
        public string ContainerStatusName { get; set; }
        public int ShipModeId { get; set; }
        public string ShipModeName { get; set; }
        public string Notes { get; set; }

        public ICollection<ContainerDetail> ContainerDetails { get; set; }
        public ICollection<ShipMode> ShipModes { get; set; }
    }
}