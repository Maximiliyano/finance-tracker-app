using System.Text.Json.Serialization;
using FinanceTracker.Domain.Conventers;

namespace FinanceTracker.Domain.Entities;

public sealed class Exchange
    : Entity, IAuditableEntity, ISoftDeletableEntity
{
    [JsonPropertyName("base_ccy")]
    public string NationalCurrencyCode { get; init; }

    [JsonPropertyName("ccy")]
    public string TargetCurrencyCode { get; init; }

    [JsonConverter(typeof(StringToFloatConverter))]
    public float Buy { get; init; }

    [JsonConverter(typeof(StringToFloatConverter))]
    public float Sale { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public int CreatedBy { get; init; }

    public DateTimeOffset? UpdatedAt { get; init; }

    public int? UpdatedBy { get; init; }

    public DateTimeOffset? DeletedAt { get; init; }

    public bool? IsDeleted { get; init; }
}
