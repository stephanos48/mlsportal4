namespace API.DTOs
{
    public class TxQohForCreationDto
    {
        public int TxQohId { get; set; }
        public string Pn { get; set; }
        public string ExtremePn { get; set; }
        public string PartDescription { get; set; }
        public string Customer { get; set; }
        public int? Jan1Qoh { get; set; }
        public int? Jan1Rec { get; set; }
        public int? Jan1Ship { get; set; }
        public int? Qoh { get; set; }
        public string Location { get; set; }
        public string HtsCode { get; set; }
        public string Notes { get; set; }
    }
}