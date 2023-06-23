using loja.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace loja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Teste";

        [HttpGet("ObterTodosClientes")]
        public IEnumerable<Cliente> ObterTodosClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            Cliente cliente = new Cliente();
            cliente.ClienteId = 1;
            cliente.Nome = "Jonatas";
            cliente.DataNascimento = DateTime.Parse("06/02/1995");
            cliente.Ativo = true;

            clientes.Add(cliente);


            Cliente cliente2 = new Cliente();
            cliente2.ClienteId = 2;
            cliente2.Nome = "Pedro";
            cliente2.Ativo = false;

            clientes.Add(cliente2);

            return clientes;
        }

        [HttpGet("ObterTodosClientes1")]
        public IEnumerable<Cliente> ObterTodosClientes1()
        {
            List<Cliente> clientes = new List<Cliente>();

            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Teste";

            // Crie uma conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Defina a consulta SELECT
                string query = "SELECT ClienteId, Nome, DataNascimento, Cpf, Ativo FROM Clientes";

                // Crie um objeto Command para executar a consulta
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute a consulta e obtenha um leitor de dados
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Itere pelas linhas retornadas
                        while (reader.Read())
                        {
                            // Acesse os dados de cada coluna pelo seu índice ou nome
                            int ClienteId = reader.GetInt32("ClienteId");
                            string? Nome = reader.IsDBNull("Nome") ? null : reader.GetString("Nome");
                            DateTime? DataNascimento = reader.GetDateTime("DataNascimento");
                            string? Cpf = reader.IsDBNull("Cpf") ? null : reader.GetString("Cpf");
                            bool? Ativo = reader.GetBoolean("Ativo");

                            Cliente cliente = new Cliente();
                            cliente.ClienteId = ClienteId;
                            cliente.Nome = Nome;
                            cliente.DataNascimento = DataNascimento;
                            cliente.Cpf = Cpf;
                            cliente.Ativo = Ativo;

                            clientes.Add(cliente);
                        }
                    }
                }
            }

            return clientes;
        }

        [HttpGet("ObterClientesPorId/{clienteId}")]
        public Cliente ObterClientesPorId(string clienteId)
        {
            Cliente cliente = new Cliente();

            // Crie uma conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Defina a consulta SELECT
                string query = "SELECT ClienteId, Nome, DataNascimento, Cpf, Ativo FROM Clientes WHERE ClienteId = " + clienteId;

                // Crie um objeto Command para executar a consulta
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute a consulta e obtenha um leitor de dados
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Itere pelas linhas retornadas
                        if (reader.Read())
                        {
                            // Acesse os dados de cada coluna pelo seu índice ou nome
                            cliente.ClienteId = reader.GetInt32("ClienteId");
                            cliente.Nome = reader.IsDBNull("Nome") ? null : reader.GetString("Nome");
                            cliente.DataNascimento = reader.IsDBNull("DataNascimento") ? null : reader.GetDateTime("DataNascimento");
                            cliente.Cpf = reader.IsDBNull("Cpf") ? null : reader.GetString("Cpf");
                            cliente.Ativo = reader.IsDBNull("Ativo") ? null : reader.GetBoolean("Ativo");

                        }
                    }
                }
            }

            return cliente;
        }

        [HttpPost("CadastrarCliente")]
        public int CadastrarCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Clientes (Nome, DataNascimento, Cpf, Ativo) VALUES (@Nome, @DataNascimento, @Cpf, @Ativo)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Defina os parâmetros e seus valores
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
                    command.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    command.Parameters.AddWithValue("@Ativo", cliente.Ativo);

                    // Execute o comando INSERT
                    return command.ExecuteNonQuery();
                }
            }
        }

        [HttpPut("AlterarCliente")]
        public int AlterarCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Clientes SET Nome = @Nome, DataNascimento = @DataNascimento, Cpf = @Cpf, Ativo = @Ativo WHERE ClienteId = @ClienteId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Defina os parâmetros e seus valores
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
                    command.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    command.Parameters.AddWithValue("@Ativo", cliente.Ativo);
                    command.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);

                    // Execute o comando UPDATE
                    return command.ExecuteNonQuery();

                }
            }
        }

        [HttpDelete("DeletarCliente/{clienteId}")]
        public int DeletarCliente(int clienteId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Clientes WHERE ClienteId = @ClienteId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Defina os parâmetros e seus valores
                    command.Parameters.AddWithValue("@ClienteId", clienteId);

                    // Execute o comando UPDATE
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
