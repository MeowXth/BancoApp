using Microsoft.AspNetCore.Mvc.RazorPages;
using BancoApp.Services;
using BancoApp.Models;
using System.Collections.Generic;

namespace BancoApp.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly ClienteService _clienteService;

        public List<Cliente> Clientes { get; set; } = new();

        public IndexModel(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void OnGet()
        {
            Clientes = _clienteService.ObtenerClientes();
        }
    }
}
