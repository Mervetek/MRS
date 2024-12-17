using System;
using System.IO;
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
    
    
    public async Task SaveToFile(ClientInformationViewModel client)
    {
        var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var appointments = GetAllAppointments(Path.Combine(documentsPath, "appointment.json")) ??
                           new AvaloniaList<ClientSummary>();
        
        appointments.Add(_converter.ConvertToSummary(client));

        // Güncel json stringini olusturma
        var updatedJsonString =
            JsonSerializer.Serialize(appointments, new JsonSerializerOptions { WriteIndented = true });
        
        // JSON dosyasına veri yazma
        await File.WriteAllTextAsync(Path.Combine(documentsPath, "appointment.json"), updatedJsonString);
        
        //refresh list
        GetAllAppointments(Path.Combine(documentsPath, "appointment.json"));
    }

    public Task SaveToFile(ClientSummary client)
    {
        throw new NotImplementedException();
    }

    public AvaloniaList<ClientSummary>? GetAllAppointments(string path)
    {
        AvaloniaList<ClientSummary>? list = null;
        if (!File.Exists(path)) return list;
        var jsonString = File.ReadAllText(path);
        list = JsonConvert.DeserializeObject<AvaloniaList<ClientSummary>>(jsonString);
        return list;
    }
}