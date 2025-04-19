using System.Collections.Generic;
using BancoApp.Data;
using BancoApp.Models;

namespace BancoApp.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> ObtenerClientes()
        {
            return _clienteRepository.ObtenerClientes();
        }
    }
}
