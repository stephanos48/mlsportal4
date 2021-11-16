using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class PurchaseOrderLine
    {
        public int PurchaseOrderLineId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int MasterPartId { get; set; }
        public string PartNumber { get; set; }
        public string PurchaseOrderLineNo { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? PromiseDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public int OrderQty { get; set; }
        public string Notes { get; set; }

        public int ContainerId { get; set; }
        public Container Containers { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public ICollection<ContainerDetail> ContainerDetails { get; set; }
    }
}