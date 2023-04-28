using Hotel.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Hotel.Pages.MisHabitaciones
{
    public partial class Habitaciones
    {
        [Inject] IHabitacionServicio habitacionServicio { get; set; }
        IEnumerable<Habitacion> listaHabitaciones { get; set; }
        protected override async Task OnInitializedAsync()
        {
            listaHabitaciones = await habitacionServicio.GetLista();
        }
    }
}
