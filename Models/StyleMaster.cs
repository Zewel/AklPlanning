using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class StyleMaster
    {
        public int StlCode { get; set; }
        public string StlDesc { get; set; }
        public int? BuyerId { get; set; }
        public int? SeasonId { get; set; }
        public int? BrndId { get; set; }
        public int? GmtDptid { get; set; }
        public int? GugId { get; set; }
        public decimal? FobAmnt { get; set; }
        public DateTime? ConfDt { get; set; }
        public DateTime? PkD { get; set; }
        public string StlDescrptn { get; set; }
        public string Stag { get; set; }
        public string Comp_Name { get; set; }
        public string Bur_Name { get; set; }
        public string TeamName { get; set; }
        public string GmtDept { get; set; }
        public string Fullname { get; set; }
        public string SeasonName { get; set; }
        public string GaugeDesc { get; set; }
        public byte[] StyleSktbyt { get; set; }
        public DateTime? YrnOrddt { get; set; }
        public DateTime? YrnInhsDt { get; set; }
        public DateTime? YrnColapvdt { get; set; }
        public int? Yrnprclead { get; set; }
        public DateTime? YrnTrnsitdt { get; set; }
        public DateTime? Smpapvdt { get; set; }
        public DateTime? BlkHngrapvdt { get; set; }
        public DateTime? tstApvdt { get; set; }
        public DateTime? SewitmIH { get; set; }
        public DateTime? PakItmIH { get; set; }
        public int? ProdLead { get; set; }
        public string srcType { get; set; }
        public string SupName { get; set; }
        public decimal SmvKn { get; set; }
        public decimal SmvLk { get; set; }
        public decimal SmvSw { get; set; }
        public decimal SmvTr { get; set; }
        public decimal SmvMn { get; set; }
        public decimal Smvotr { get; set; }
        public decimal SmvTtl { get; set; }
        public int? McnTypCd { get; set; }
        public string Ieby { get; set; }
        public DateTime? IEdt { get; set; }
        public string IeRemrks { get; set; }
        public string Plnby { get; set; }
        public DateTime? PlnDt { get; set; }
        public string PlnRemrks { get; set; }
        public DateTime? lstRevdt { get; set; }
        public string RevRemrks { get; set; }
        public string MerRemrks { get; set; }
        public DateTime? POfirstdeldt { get; set; }
        public int? pottlqty { get; set; }
        public DateTime? Pomaxdel { get; set; }
        public DateTime? filehndovrdt { get; set; }
        public string YarnComp { get; set; }
        public string Gmttype { get; set; }
        public string YarnDescription { get; set; }
        public string YarnCount { get; set; }
        public string MachineType { get; set; }
        public string SewProc { get; set; }
        public decimal? Smvfin { get; set; }
        public string Knitsys { get; set; }
        public int? Embstitch { get; set; }
        public string StyleType { get; set; }
        public string CostStatus { get; set; }
        public int? StlQty { get; set; }
        public int? BookingQty { get; set; }
        public int? CostQty { get; set; }
        public string CriticalTyp { get; set; }
        public List<StylePurchaseOrder> StylePurchaseOrders { get; set; }
        public List<BOM> BOMs { get; set; }
        public string GoodsName { get; set; }
        public string OrderType { get; set; }
        public string OrderMotherCompany { get; set; }
        
    }
}
