using CurrieTechnologies.Razor.SweetAlert2;
using Hotel.Interfaces;
using Hotel.Servicios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Modelos;
using System;

namespace Hotel.Pages.MisHabitaciones
{
    public partial class EditarHabitacion
    {
        [Inject] private IHabitacionServicio habitacionServicio { get; set; }
        private Habitacion hab = new Habitacion();
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }

        [Parameter] public string Codigo { get; set; }
        string imgUrl = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                hab = await habitacionServicio.GetPorCodigo(Convert.ToInt32(Codigo));
            }
        }

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
            if (string.IsNullOrEmpty(hab.Descripcion))
            {
                return;
            }
     
            bool edito = await habitacionServicio.Actualizar(hab);
            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Habitacion guardada con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Habitaciones");
            }
            else
            {
                await Swal.FireAsync("Error", "Habitacion no se pudo guardar", SweetAlertIcon.Error);
            }
        }
        protected void Cancelar()
        {
            _navigationManager.NavigateTo("/Habitaciones");
        }

        protected async Task Eliminar()
        {
            {
                bool elimino = false;

                SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "¿Seguro que desea eliminar el registro?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Aceptar",
                    CancelButtonText = "Cancelar"
                });

                if (!string.IsNullOrEmpty(result.Value))
                {
                    elimino = await habitacionServicio.Eliminar(Convert.ToInt32(Codigo));

                    if (elimino)
                    {
                        await Swal.FireAsync("Felicidades", "Habitacion Eliminada", SweetAlertIcon.Success);
                        _navigationManager.NavigateTo("/Habitaciones");
                    }
                    else
                    {
                        await Swal.FireAsync("Error", "No se puede eliminar la habitacion", SweetAlertIcon.Error);
                    }
                }
            }
        }


    }
}
