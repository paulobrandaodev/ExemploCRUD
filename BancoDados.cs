using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUD{
    public class BancoDados
    {
        SqlConnection cn;
        SqlCommand comandos;
        SqlDataReader rd;

        public bool Adicionar(Categoria cat){
            bool rs = false;

            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog=Papelaria;User id=sa;password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "INSERT INTO categorias (titulo) VALUES (@vt)";
                comandos.Parameters.AddWithValue("@vt", cat.Titulo);

                int r = comandos.ExecuteNonQuery();
                if (r > 0)
                    rs = true;

                comandos.Parameters.Clear();    
                
            }catch(SqlException se){
                throw new Exception("Erro ao tentar cadastrar: "+se.Message);
            }catch(Exception ex){
                throw new Exception("Erro inesperado: "+ex.Message);
            }finally{
                cn.Close();
            }

            return rs;
        }


        public bool Atualizar(Categoria cat){
            bool rs = false;

            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog=Papelaria;User id=sa;password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "UPDATE categorias SET titulo = @vt WHERE idCategoria = @vi";
                comandos.Parameters.AddWithValue("@vt", cat.Titulo);
                comandos.Parameters.AddWithValue("@vi", cat.IdCategoria);

                int r = comandos.ExecuteNonQuery();
                if (r > 0)
                    rs = true;

                comandos.Parameters.Clear();    
                
            }catch(SqlException se){
                throw new Exception("Erro ao tentar alterar: "+se.Message);
            }catch(Exception ex){
                throw new Exception("Erro inesperado: "+ex.Message);
            }finally{
                cn.Close();
            }

            return rs;
        }


        public bool Deletar(Categoria cat){
            bool rs = false;

            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog=Papelaria;User id=sa;password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "DELETE FROM categorias WHERE idCategoria = @vi";
                comandos.Parameters.AddWithValue("@vi", cat.IdCategoria);

                int r = comandos.ExecuteNonQuery();
                if (r > 0)
                    rs = true;

                comandos.Parameters.Clear();    
                
            }catch(SqlException se){
                throw new Exception("Erro ao tentar deletar: "+se.Message);
            }catch(Exception ex){
                throw new Exception("Erro inesperado: "+ex.Message);
            }finally{
                cn.Close();
            }

            return rs;
        }


        public List<Categoria> ListarCategorias(int id){

            List<Categoria> lista = new List<Categoria>();

            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog=Papelaria;User id=sa;password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "SELECT * FROM categorias WHERE idCategoria = '@vi'";
                comandos.Parameters.AddWithValue("@vi", id);

                rd = comandos.ExecuteReader();

                while(rd.Read()){
                    lista.Add(new Categoria{ 
                        IdCategoria=rd.GetInt32(0), 
                        Titulo = rd.GetString(1) 
                        });                
                }

                comandos.Parameters.Clear();    
                
            }catch(SqlException se){
                throw new Exception("Erro ao tentar consultar: "+se.Message);
            }catch(Exception ex){
                throw new Exception("Erro inesperado: "+ex.Message);
            }finally{
                cn.Close();
            }

            return lista;
        }

        public List<Categoria> ListarCategorias(string titulo){

            List<Categoria> lista = new List<Categoria>();

            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog=Papelaria;User id=sa;password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "SELECT * FROM categorias WHERE titulo LIKE '@vi'";
                comandos.Parameters.AddWithValue("@vi", titulo);

                rd = comandos.ExecuteReader();

                while(rd.Read()){
                    lista.Add(new Categoria{ 
                        IdCategoria=rd.GetInt32(0), 
                        Titulo = rd.GetString(1) 
                        });                
                }
                
                comandos.Parameters.Clear();    
                
            }catch(SqlException se){
                throw new Exception("Erro ao tentar consultar: "+se.Message);
            }catch(Exception ex){
                throw new Exception("Erro inesperado: "+ex.Message);
            }finally{
                cn.Close();
            }

            return lista;
        }


    }
}