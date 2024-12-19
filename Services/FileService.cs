using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Collections;
using MRS.Interfaces;
using MRS.Models;
using MRS.Utils;
using MRS.ViewModels;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MRS.Services;

public class FileService : IFileOperations
{
    private Converter _converter = new();
    private TextFileReaderWriter _readerWriter = new();
    private string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    public async Task SaveToFile(ClientInformationViewModel client)
    {
        //PROBLEMS
        //!!!Kayıt eklendiginde listeye hemen düşmüyor ekranı kapatıp acmak gerekiyor..
        //!!!Edit yaptıgımda yeni kayıt ekliyor.

        //FEATURES
        // tarihi geçen kayıtları otomatik sil
        // silme islemi henuz implement edilmedi
        
        var appointments = GetAllAppointments(Path.Combine(documentsPath, "appointment.json")) ??
                           new AvaloniaList<ClientSummary>();

        if (DoesClientExist(_converter.ClientConvertToEditedItem(client), appointments))
        {
            UpdateClient(_converter.ClientConvertToEditedItem(client), appointments);
            return;
        }

        appointments.Add(_converter.ConvertToSummary(client));
        _readerWriter.WriteFile(Path.Combine(documentsPath, "counter.txt"), appointments.Count);


        // Güncel json stringini olusturma
        var updatedJsonString =
            JsonSerializer.Serialize(appointments, new JsonSerializerOptions { WriteIndented = true });

        // JSON dosyasına veri yazma
        await File.WriteAllTextAsync(Path.Combine(documentsPath, "appointment.json"), updatedJsonString);

        //refresh list
        appointments = GetAllAppointments(Path.Combine(documentsPath, "appointment.json"));
    }

    public AvaloniaList<ClientSummary>? GetAllAppointments(string path)
    {
        AvaloniaList<ClientSummary>? list = null;
        if (!File.Exists(path)) return list;
        var jsonString = File.ReadAllText(path);
        list = JsonConvert.DeserializeObject<AvaloniaList<ClientSummary>>(jsonString);
        return list;
    }

    private static bool DoesClientExist(ClientSummary client, AvaloniaList<ClientSummary> clients)
    {
        return clients.Any(currentClient => currentClient.Id == client.Id);
    }

    private static void UpdateClient(ClientSummary client, AvaloniaList<ClientSummary> clients)
    {
        foreach (var t in clients.Where(t => t.Id == client.Id))
        {
            t.Name = client.Name;
            t.Surname = client.Surname;
            t.Type = client.Type;
            t.AppointmentTime = client.AppointmentTime;
            t.Time = client.Time;
        }
    }

    public AvaloniaList<ClientSummary>? RefreshList()
    {
       return GetAllAppointments(Path.Combine(documentsPath, "appointment.json"));
    }
}