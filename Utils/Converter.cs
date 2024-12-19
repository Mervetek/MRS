using System;
using System.IO;
using MRS.Models;
using MRS.Services;
using MRS.ViewModels;

namespace MRS.Utils;

public class Converter
{
    private static readonly TextFileReaderWriter ReaderWriter = new();
    private static readonly string DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private static string _counter = "";


    public ClientSummary ConvertToSummary(ClientInformationViewModel client)
    {
        _counter = ReaderWriter.ReadFile(Path.Combine(DocumentsPath, "counter.txt"));
        var id = _counter == "" ? 0 : int.Parse(_counter);
        return new ClientSummary
        {
            Id = ++id,
            Name = client.Name,
            Surname = client.Surname,
            AppointmentTime = client.AppointmentTime ?? DateTime.Now,
            Time = $"{client.AppointmentHour}:{client.AppointmentMinute}",
            Type = client.AppointmentType
        };
    }

    public ClientSummary ClientConvertToEditedItem(ClientInformationViewModel client)
    {
        _counter = ReaderWriter.ReadFile(Path.Combine(DocumentsPath, "counter.txt"));
        var id = _counter == "" ? 0 : int.Parse(_counter);
        return new ClientSummary
        {
            Id = id,
            Name = client.Name,
            Surname = client.Surname,
            AppointmentTime = client.AppointmentTime ?? DateTime.Now,
            Time = $"{client.AppointmentHour}:{client.AppointmentMinute}",
            Type = client.AppointmentType
        };
    }

    public ClientSummaryCardViewModel ConvertToCard(ClientSummary client)
    {
        return new ClientSummaryCardViewModel
        {
            Name = client.Name,
            Surname = client.Surname,
            AppointmentTime = client.AppointmentTime,
            Time = client.Time,
            Type = client.Type
        };
    }

    public ClientInformationViewModel ConvertToClientInformation(ClientSummaryCardViewModel summary)
    {
        var parts = summary.Time.Split(":");
        return new ClientInformationViewModel
        {
            Name = summary.Name,
            Surname = summary.Surname,
            AppointmentTime = summary.AppointmentTime,
            AppointmentType = summary.Type,
            AppointmentHour = int.Parse(parts[0]),
            AppointmentMinute = parts[1]
        };
    }
}