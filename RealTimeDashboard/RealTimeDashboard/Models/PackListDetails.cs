using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeDashboard.Models
{
    public class PackListDetails
    {
        public int ID { get; set; }

        public string PacklistNo { get; set; }

        public DateTime PacklistDate { get; set; }

        public string Batchbarcode { get; set; }

        public string RFIDNo { get; set; }

        public string GateNo { get; set; }

        public bool? DispatchStatus { get; set; }

        public DateTime? Lastread { get; set; }

        public string WrongGateNo { get; set; }

        public bool? isTagCollected { get; set; }

        public string TruckNo { get; set; }

        public string CustomerName { get; set; }

    }
}
