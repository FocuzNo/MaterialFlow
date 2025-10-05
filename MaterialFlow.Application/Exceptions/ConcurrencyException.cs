namespace MaterialFlow.Application.Exceptions;

public sealed class ConcurrencyException(
    string Message,
    Exception InnerException) : Exception;