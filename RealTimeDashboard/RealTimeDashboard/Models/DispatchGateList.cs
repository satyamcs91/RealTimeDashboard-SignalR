using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeDashboard.Models
{
   
    public class DispatchGateList
    {
        public string GateNo { get; set; }
        public string PacklistNo { get; set; }
        public string PacklistDate { get; set; }
        public string batchInfos { get; set; }
        public string Total { get; set; }
        public string Pending { get; set; }
        public string Dispatched { get; set; }
        public string RFIDTagCollected { get; set; }
        public string BatchNo { get; set; }
        public string ProducedOn { get; set; }
        public string RFIDNo { get; set; }
        public string Weight { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string MaterialType { get; set; }
        public string Location { get; set; }
        public string FoundStatus { get; set; }
        public string LastRead { get; set; }
        public string RFIDTagCollectedStatus { get; set; }
        public string TruckNo { get; set; }

    }

    public class BatchInfos
    {
        public string BatchNo { get; set; }
        public string ProducedOn { get; set; }
        public string RFIDNo { get; set; }
        public string Weight { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string MaterialType  { get; set; }
        public string Location { get; set; }
        public string FoundStatus { get; set; }
        public string LastRead { get; set; }
        public string RFIDTagCollectedStatus { get; set; }
        public string TruckNo { get; set; }

    }
}
