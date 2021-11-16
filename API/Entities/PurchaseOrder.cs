using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        public string PurchaseOrderNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "OrderDate")]
        public DateTime? OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerDivisionId { get; set; }
        public string CustomerDivisionName { get; set; }
        public int MlsDivisionId { get; set; }
        public string MlsDivisionName { get; set; }
        public int SalesOrderId { get; set; }
        public string SalesOrderNumber { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Notes { get; set; }
        public int PoStatusId { get; set; }
        public string PoStatusName { get; set; }

        public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    }
}