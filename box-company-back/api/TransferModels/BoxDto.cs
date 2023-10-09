using System.Diagnostics.CodeAnalysis;

namespace box_company_back.api.TransferModels;

public class BoxDto
{
    [NotNull]
    public int Height { get; set; }
    [NotNull]
    public int Width { get; set; }
    [NotNull]
    public int Length { get; set; }
    [NotNull]
    public string Type { get; set; }
    [NotNull]
    public int Amount { get; set; }
}