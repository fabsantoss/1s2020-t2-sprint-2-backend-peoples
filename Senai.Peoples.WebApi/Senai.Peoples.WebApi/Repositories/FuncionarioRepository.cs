﻿using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {


        private string stringConexao = "Data Source=DEV13\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132";

        public void AtualizarIdCorpo(FuncionariosDomain funcionario)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome WHERE IdFuncionario = @ID";


                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@ID", funcionario.IdFuncionario);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);


                    con.Open();


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FuncionariosDomain funcionario)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome WHERE IdFuncionario = @ID";


                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);


                    con.Open();


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionariosDomain BuscarPorId(int id)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectById = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = @ID";


                con.Open();


                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);


                    rdr = cmd.ExecuteReader();


                    if (rdr.Read())
                    {

                        FuncionariosDomain genero = new FuncionariosDomain
                        {

                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()


                        };


                        return genero;
                    }


                    return null;
                }
            }
        }

        public void Cadastrar(FuncionariosDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {



                string queryInsert = "INSERT INTO Funcionarios(Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";


                SqlCommand cmd = new SqlCommand(queryInsert, con);


                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);


                con.Open();


                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);


                    con.Open();


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionariosDomain> Listar()
        {

            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios";


                con.Open();


                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {

                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {

                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()

                        };


                        funcionarios.Add(funcionario);
                    }
                }
            }


            return funcionarios;
        }

    }
}

