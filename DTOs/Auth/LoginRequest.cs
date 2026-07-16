using System.ComponentModel.DataAnnotations;

namespace TesteQuestor.DTOs.Auth;

public sealed record LoginRequest(
    [Required] string Username,
    [Required] string Password
);
