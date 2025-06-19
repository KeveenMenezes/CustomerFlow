namespace BuildingBlocks.Core.Exceptions;

public class DomainException(
    string name, object value, string? message = null)
    : Exception($"The domain rule for \"{name}\" with value \"{value}\" was violated{(string.IsNullOrWhiteSpace(message) ? "." : $": {message}")}");
