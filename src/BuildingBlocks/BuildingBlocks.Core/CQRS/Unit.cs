namespace BuildingBlocks.Core.CQRS;

public sealed class Unit
{
    public static readonly Unit Value = new();
    private Unit() { }
}
