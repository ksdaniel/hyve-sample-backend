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

public class CreateClientDataInput
{
    public string Name { get; set; } = string.Empty;
    public int InvestableAssets { get; set; } = 0;
    public int? Aum { get; set; } = null;
    public int Salary { get; set; } = 0;
    public string? DateOnboarded { get; set; } = null;
    public ClientStatus Status { get; set; } = ClientStatus.Lead;
    public string? Summary { get; set; } = null;
    public string? Phone { get; set; } = null;
    public string? Email { get; set; } = null;
    public bool? Priority { get; set; } = false;
    public string? DateOfBirth { get; set; } = null;
    public string? Address { get; set; } = null;
    public string? Prospect { get; set; } = null;
    public bool? Unread { get; set; } = false;
}

public class UpdateClientDataInput
{
    public string Id { get; set; } = string.Empty;
    public string? Name { get; set; } = null;
    public int? InvestableAssets { get; set; } = null;
    public int? Aum { get; set; } = null;
    public int? Salary { get; set; } = null;
    public string? DateOnboarded { get; set; } = null;
    public ClientStatus? Status { get; set; } = null;
    public string? Summary { get; set; } = null;
    public string? Phone { get; set; } = null;
    public string? Email { get; set; } = null;
    public bool? Priority { get; set; } = null;
    public string? DateOfBirth { get; set; } = null;
    public string? Address { get; set; } = null;
    public string? Prospect { get; set; } = null;
    public bool? Unread { get; set; } = null;
}