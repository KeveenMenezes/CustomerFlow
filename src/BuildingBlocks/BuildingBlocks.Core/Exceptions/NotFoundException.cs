namespace BuildingBlocks.Core.Exceptions;

public class NotFoundException(string name, object value)
    : Exception($"Entity \"{name}\" ({value}) was not found.");
