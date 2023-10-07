namespace Catalog.API.Application.Contracts.Data;

public sealed record FilterData(
    string? Filter,
    int? PageSize,
    int? PageIndex);
