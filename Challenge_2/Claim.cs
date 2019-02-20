using System;

namespace Challenge_2
{
    public enum TypeOfClaim { Car = 1, Home, Theft, Other }

    public class Claim
    {
        public Claim(int id, TypeOfClaim type, string description, decimal amount, string claimDate,
            string incidentDate)
        {
            ClaimID = id;
            Category = type;
            Description = description;
            ClaimAmount = amount;
            ClaimDate = claimDate;
            IncidentDate = incidentDate;
            IsValid = ValidateClaim(TimeSinceIncident);
        }

        //Properties
        public int ClaimID { get; set; }
        public TypeOfClaim Category { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public string ClaimDate { get; set; }
        public string IncidentDate { get; set; }
        public TimeSpan TimeSinceIncident => Convert.ToDateTime(ClaimDate) - Convert.ToDateTime(IncidentDate);
        public bool IsValid { get; set; }

        public override string ToString() => $"Claim ID: {ClaimID} \nClaim Type: {Category} \nDescription: {Description} \nClaim Amount: ${ClaimAmount} \nClaim Date: {ClaimDate}\nIncident Date: {IncidentDate}\nTime Since Incident: {TimeSinceIncident}\nIs the claim valid? {IsValid}";

        private bool ValidateClaim(TimeSpan timeSince)
        {
            if (timeSince.Days <= 30)
                return true;
            else return false;
        }
    }
}
