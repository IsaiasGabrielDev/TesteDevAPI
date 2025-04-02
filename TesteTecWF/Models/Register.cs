namespace TesteTecWF.Models;

public sealed record class Register(
    string Name,
    string Email,
    string Password
);