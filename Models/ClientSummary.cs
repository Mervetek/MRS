using System;

namespace MRS.Models;

public record ClientSummary
{
    public required int Id { get; init; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required AppointmentType Type { get; set; }
    public required DateTime AppointmentTime { get; set; }
    public required string Time { get; set; }
}