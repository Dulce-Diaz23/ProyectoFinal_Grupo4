using CurrieTechnologies.Razor.SweetAlert2;
using Hotel.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Modelos;

namespace Hotel.Pages.MisHabitaciones
{
    public partial class NuevaHabitacion
    {
        [Inject] private IHabitacionServicio habitacionServicio { get; set; }
        private Habitacion hab= new Habitacion();
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }

        string imgUrl = string.Empty;

        private async Task SeleccionarImagen(InputFileChangeEventArgs e)
        {
            IBrowserFile imgFile = e.File;
            var buffers = new byte[imgFile.Size];
            hab.Imagen = buffers;
            await imgFile.OpenReadStream().ReadAsync(buffers);
            string imageType = imgFile.ContentType;
            imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
        }

        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(hab.Codigo.ToString()) || string.IsNullOrEmpty(hab.Descripcion))
            {
                return;
            }
            hab.FechaCreacion = DateTime.Now;
            Habitacion habitacionExistente = new Habitacion();

            habitacionExistente = await habitacionServicio.GetPorCodigo(hab.Codigo);

            if (habitacionExistente != null)
            {
                if (habitacionExistente.Codigo != 0)
                {
                    await Swal.FireAsync("Advertencia", "Ya existe una habitacion con este codigo", SweetAlertIcon.Warning);
                    return;
                }
            }

            bool inserto = await habitacionServicio.Nuevo(hab);

            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Habitacion guardada con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Habitaciones");
            }
            else
            {
                await Swal.FireAsync("Error", "Habitacion no se pudo guardar", SweetAlertIcon.Error);
            }
        }
        protected async Task Cancelar()
        {
            _navigationManager.NavigateTo("/Habitaciones");
        }
    }
}
