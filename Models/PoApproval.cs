using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.Models
{
    public class PoApproval
    {
        [Key]
        public int PoCod { get; set; }
        public int? StlCod { get; set; }
        public DateTime? InitialPlaneDate { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// In Below Property for po split.
        /// </summary>
        public int GaugeId { get; set; }
        public int BrandId { get; set; }
        public int PoQty { get; set; }
        public int Smv { get; set; }
        public int? KntOperationId { get; set; }
        public int? PoConfirmId { get; set; }
        public string PoColor { get; set; }

       
    }
}
