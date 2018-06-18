using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_CommonLibraries.Utilities.CommonEnum;

namespace App_CommonLibraries.AbstractClass
{
    public abstract class WorkOrder
    {
        public int JobID { get; set; }
        public string JobNo { get; set; }
        public string BookingNo { get; set; }
        public DateTime BookingDateTime { get; set; }
        public string DeptCode { get; set; }
        public string CustNo { get; set; }
        public string BranchCode { get; set; }
        public string JobType { get; set; } //LCL or FCL
        public string SourceReference { get; set; } // if connected from other job
        public string QuotationNo { get; set; } //If Marketing is available
        public Job_Status JobStatus { get; set; }
        public JobUrgency_Type JobUrgencyType { get; set; }
        public bool BillByTransport { get; set; }
        public bool IsBillable { get; set; }
        public bool IsFlexibleTime { get; set; }
        public string JobCreatedBy { get; set; }
        public string LastModified_By { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public byte[] UpdateVersion { get; set; }

        public WorkOrder()
        {
            this.JobID = 0;
            this.JobNo = string.Empty;
            this.BookingNo = string.Empty;
            this.BookingDateTime = DateTime.Now;
            this.DeptCode = string.Empty;
            this.CustNo = string.Empty;
            this.BranchCode = string.Empty;
            this.JobType = string.Empty;
            this.SourceReference = string.Empty;
            this.QuotationNo = string.Empty;
            this.JobStatus = Job_Status.UnConfirm;
            this.JobUrgencyType = JobUrgency_Type.Normal;
            this.BillByTransport = true;
            this.IsBillable = true;
            this.IsFlexibleTime = true;
            this.JobCreatedBy = string.Empty;
            this.LastModified_By = string.Empty;
            this.LastModifiedDateTime = DateTime.Now;
            this.UpdateVersion = new byte[8];
        }
    }
}
