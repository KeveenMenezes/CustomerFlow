namespace BuildingBlocks.Core.Exceptions;

public class BadRequestException(
    string name, object value, string? message = null)
    : Exception($"The input \"{name}\" with value \"{value ?? "null"}\" is invalid{(string.IsNullOrWhiteSpace(message) ? "." : $": {message}")}");
