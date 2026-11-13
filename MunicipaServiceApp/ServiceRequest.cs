using System;

namespace MunicipalServiceApp
{
    public enum RequestStatus
    {
        Submitted, Acknowledged, InProgress, Resolved, Closed
    }

    public enum RequestCategory
    {
        Water, Electricity, Roads, Sanitation, Refuse, Other
    }

    public class ServiceRequest
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public RequestCategory Category { get; set; }
        public RequestStatus Status { get; set; }
        public int Priority { get; set; }
        public DateTime DateSubmitted { get; set; }

        public ServiceRequest()
        {
            ReferenceNumber = "";
            Description = "";
            Location = "";
            Status = RequestStatus.Submitted;
            DateSubmitted = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{ReferenceNumber} | {Category,-12} | {Status,-12} | Priority: {Priority} | {Description}";
        }
    }
}