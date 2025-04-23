using System.Collections.Generic;
using BancoApp.Models;
using BancoApp.Data;

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

        public bool AgregarCliente(Cliente cliente)
        {
            return _clienteRepository.AgregarCliente(cliente);
        }

        public Cliente? ObtenerClientePorId(int id)
        {
            return _clienteRepository.ObtenerClientePorId(id);
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            return _clienteRepository.ActualizarCliente(cliente);
        }

        public bool EliminarCliente(int id)
        {
            return _clienteRepository.EliminarCliente(id);
        }
        public List<Cliente> BuscarClientes(string criterio)
        {
            return _clienteRepository.BuscarClientes(criterio);
        }
        
    }
}
