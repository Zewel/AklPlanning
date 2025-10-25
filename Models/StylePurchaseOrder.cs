using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class StylePurchaseOrder
    {
        public int POCod { get; set; }
        public string PONo { get; set; }
        public int? stylecode { get; set; }
        public int? POQty { get; set; }
        public DateTime? PoEntrydate { get; set; }
        public string poentryUsercod { get; set; }
        public string Remarks { get; set; }
        public DateTime? BookingExfty { get; set; }
        public DateTime? POExfty { get; set; }
        public DateTime? RevExfty { get; set; }
        public int? CnclQty { get; set; }
        public string CnclRemarks { get; set; }
        public string POColor { get; set; }
        public string StyleNumber { get; set; }
        public int? BuyerId { get; set; }
        public int? SeasonId { get; set; }
        public string Bur_Name { get; set; }
        public DateTime? ConfDt { get; set; }
        public string HOD { get; set; }
        public string MerchantName { get; set; }
        public string MerchantCode { get; set; }
        public string SeasonName { get; set; }
        public string GaugeDesc { get; set; }
        public byte[] stylePhoto { get; set; }
        public string styleStatus { get; set; }

        public string ShipMode { get; set; }

        public int GugId { get; set; }
        public DateTime? ExftyNew { get; set; }
        public DateTime? InitialPlaneDate { get; set; }

        public int? TotalProductionCapacity { get; set; }
        public int? TotalBookedQty { get; set; }
        public int? PoSplitId { get; set; }
        public int? StageId { get; set; }
        public int? KnittQty { get; set; }
        public int? planStatus { get; set; }

    }
}
