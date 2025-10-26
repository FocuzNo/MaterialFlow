namespace MaterialFlow.Infrastructure.Authentication.Models;

internal sealed class CredentialRepresentationModel
{
    public string Algorithm { get; init; }

    public string Config { get; init; }

    public int Counter { get; init; }

    public long CreatedDate { get; init; }

    public string Device { get; init; }

    public int Digits { get; init; }

    public int HashIterations { get; init; }

    public string HashedSaltedValue { get; init; }

    public int Period { get; init; }

    public string Salt { get; init; }

    public bool Temporary { get; init; }

    public string Type { get; init; }

    public string Value { get; init; }
}