using System.Reactive;
using ReactiveUI;

namespace MRS.Interfaces;

public interface IAppointmentOperations
{
    public ReactiveCommand<Unit, Unit> CreateAppointment { get; }
    public ReactiveCommand<Unit, Unit> EditAppointments { get; }
    public ReactiveCommand<Unit, Unit> DeleteAppointment { get; }
}