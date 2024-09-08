namespace FinanceTracker.Application.Capitals.Responses;

public sealed record CapitalResponse
{
    public CapitalResponse()
    {
    }

    public CapitalResponse(int id, string name, float balance, float totalIncome, float totalExpense, float totalTransferIn, float totalTransferOut)
    {
        Id = id;
        Balance = balance;
        TotalIncome = totalIncome;
        TotalExpense = totalExpense;
        TotalTransferIn = totalTransferIn;
        TotalTransferOut = totalTransferOut;
        Name = name;
    }

    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public float Balance { get; init; }

    public float TotalIncome { get; init; }

    public float TotalExpense { get; init; }

    public float TotalTransferIn { get; init; }

    public float TotalTransferOut { get; init; }
}