
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BancoApp.Services;
using BancoApp.Models;

namespace BancoApp.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly ClienteService _clienteService;

        [BindProperty]
        public Cliente Cliente { get; set; } = new();

        public CreateModel(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _clienteService.AgregarCliente(Cliente);
            return RedirectToPage("Index");
        }
    }
}
