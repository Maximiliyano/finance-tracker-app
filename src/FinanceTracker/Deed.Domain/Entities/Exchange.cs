using System.Text.Json.Serialization;
using Deed.Domain.Converters;

namespace Deed.Domain.Entities;

public sealed class Exchange
    : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public Exchange(int id)
        : base(id)
    {
    }

    public Exchange()
    {
    }

    [JsonPropertyName("base_ccy")]
    public required string NationalCurrencyCode { get; init; }

    [JsonPropertyName("ccy")]
    public required string TargetCurrencyCode { get; init; }

    [JsonConverter(typeof(StringToFloatConverter))]
    public required float Buy { get; set; }

    [JsonConverter(typeof(StringToFloatConverter))]
    public required float Sale { get; set; }

    public DateTimeOffset CreatedAt { get; init; }

    public int CreatedBy { get; init; }

    public DateTimeOffset? UpdatedAt { get; init; }

    public int? UpdatedBy { get; init; }

    public DateTimeOffset? DeletedAt { get; init; }

    public bool? IsDeleted { get; init; }
}
