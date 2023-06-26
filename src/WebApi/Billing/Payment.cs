namespace WebApi.Billing;

public record Payment(string Name, decimal Amount, Currency Currency);