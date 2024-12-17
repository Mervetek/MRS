using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Collections;
using MRS.Models;
using MRS.ViewModels;
using ReactiveUI;

namespace MRS.Interfaces;

public interface IFileOperations
{
    public Task SaveToFile(ClientInformationViewModel client);

    public AvaloniaList<ClientSummary>? GetAllAppointments(string path);
}