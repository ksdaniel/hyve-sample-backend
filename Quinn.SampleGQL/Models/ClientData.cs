namespace Quinn.SampleGQL.Models;

public class ClientData
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int InvestableAssets { get; set; } = 0;
    public int? Aum { get; set; } = 0;
    public int Salary { get; set; } = 0;
    public string DateOnboarded { get; set; } = string.Empty;
    public ClientStatus Status { get; set; } = ClientStatus.Lead;
    public string? Summary { get; set; } = string.Empty;
    public string? Phone { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public bool? Priority { get; set; } = false;
    public string? DateOfBirth { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public string? Prospect { get; set; } = string.Empty;
    public bool? Unread { get; set; } = false;
}

public enum ClientStatus
{
    Lead,
    Client,
    Prospect,
    Archived
}