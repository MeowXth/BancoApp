using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BancoApp.Models;

namespace BancoApp.Data
{
    public class ClienteRepository
    {
        private readonly DatabaseHelper _databaseHelper;

        public ClienteRepository(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public List<Cliente> ObtenerClientes() 
        {
            var clientes = new List<Cliente>();
            using (var connection = _databaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id,Nombre,Correo,Saldo FROM Clientes", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Correo = reader.GetString(2),
                                Saldo = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }

            return clientes;

        }
    }
}