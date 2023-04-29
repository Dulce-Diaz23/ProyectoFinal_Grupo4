using Hotel.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Hotel.Pages.MisClientes
{
    public partial class Clientes
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }

        private IEnumerable<Cliente> lista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lista = await clienteServicio.GetLista();
        }
    }
}