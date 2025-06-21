namespace CustomerFlow.BuildingBlocks.Core.Exceptions;

public class NotFoundException(string name, object value)
    : Exception($"Entity \"{name}\", value: ({value}) was not found.");
