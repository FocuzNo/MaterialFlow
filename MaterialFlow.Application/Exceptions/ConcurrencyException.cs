namespace MaterialFlow.Application.Exceptions;

public sealed class ConcurrencyException(
    string message,
    Exception innerException) : Exception;