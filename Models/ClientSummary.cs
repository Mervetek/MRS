using System;

namespace MRS.Models;

public record ClientSummary
{
    public required string Name { get; init; }
    public required string Surname { get; init; }
    public required AppointmentType Type { get; init; }
    public required DateTime AppointmentTime { get; init; }
    public required string Time { get; init; }
}