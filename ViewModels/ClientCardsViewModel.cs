using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Collections;
using MRS.Interfaces;
using MRS.Models;
using MRS.Services;
using MRS.Utils;
using ReactiveUI.Fody.Helpers;

namespace MRS.ViewModels;

public class ClientCardsViewModel : ViewModelBase
{
    private readonly IFileOperations _fileOperations = new FileService();
    private readonly Converter _converter = new();

    public ClientCardsViewModel()
    {
        var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var appointments = _fileOperations
                               .GetAllAppointments(Path.Combine(documentsPath, "appointment.json"))
                           ?? new AvaloniaList<ClientSummary>();

        foreach (var appointment in appointments)
        {
            ClientCards.Add(_converter.ConvertToCard(appointment));
            Console.Write(appointment);
        }
    }
    
    [Reactive] public AvaloniaList<ClientSummaryCardViewModel> ClientCards { get; set; } = new();
}