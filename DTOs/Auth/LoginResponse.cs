namespace TesteQuestor.DTOs.Auth;

public sealed record LoginResponse(
    string Token,
    DateTime ExpiresAtUtc
);
