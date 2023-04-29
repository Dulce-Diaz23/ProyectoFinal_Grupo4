using CurrieTechnologies.Razor.SweetAlert2;
using Hotel.Interfaces;
using Hotel.Servicios;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Hotel.Pages.MisClientes
{
    public partial class EditarCliente
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        private Cliente user = new Cliente();

        [Inject] SweetAlertService Swal { get; set; }
        [Parameter] public string Identidad { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Identidad))
            {
                user = await clienteServicio.GetPorCodigo(Identidad);
            }
        }

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(user.Identidad) || string.IsNullOrEmpty(user.Nombre)
                || string.IsNullOrEmpty(user.Direccion) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Telefono))
            {
                return;
            }

            bool edito = await clienteServicio.Actualizar(user);

            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Cliente actualizado", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se puede actualizar el Cliente", SweetAlertIcon.Error);
            }

            navigationManager.NavigateTo("/Clientes");
        }

        protected void Cancelar()
        {
            navigationManager.NavigateTo("/Clientes");
        }

        protected async void Eliminar()
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
                elimino = await clienteServicio.Eliminar(Identidad);

                if (elimino)
                {
                    await Swal.FireAsync("Felicidades", "Cliente eliminado", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Clientes");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se puede eliminar el CLiente", SweetAlertIcon.Error);
                }
            }
        }
    }

}