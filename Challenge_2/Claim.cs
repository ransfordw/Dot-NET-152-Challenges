using System;

namespace Challenge_2
{
    public enum TypeOfClaim { Car = 1, Home = 2, Theft = 3, Other = 4 }

    public class Claim
    {
        //Constructors
        public Claim() { }

        public Claim(int id, TypeOfClaim type, string description, decimal amount, string claimDate,
            string incidentDate, bool _isValid)
        {
            ClaimID = id;
            Category = type;
            Description = description;
            ClaimAmount = amount;
            IsValid = _isValid;
            ClaimDate = claimDate;
            IncidentDate = incidentDate;
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
    }
}
