using System;
using MRS.Models;
using MRS.ViewModels;

namespace MRS.Utils;

public class Converter
{
    public ClientSummary ConvertToSummary(ClientInformationViewModel client)
    {
        return new ClientSummary
        {
            Name = client.Name,
            Surname = client.Surname,
            AppointmentTime = client.AppointmentTime ?? DateTime.Now, 
            Time = $"{client.AppointmentHour}:{client.AppointmentMinute}",
            Type = client.AppointmentType
        };
    }
}