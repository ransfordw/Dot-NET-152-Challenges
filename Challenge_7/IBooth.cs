namespace Challenge_7
{
    public interface IBooth
    {
        string BoothName { get; set; }
        int TicketsTaken { get; set; }
        decimal MiscCost { get; set; }
        decimal TotalCostPerTicket { get; set; }
    }
}
