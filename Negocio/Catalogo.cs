using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Dominio;
using static System.Net.WebRequestMethods;

namespace Negocio
{
    public class Catalogo
    {
        public List<Articulo> Filtro(string campoSeleccionado, string criterioSeleccionado, string valor)
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDB datos = new ConexionDB();
            try
            {
                // Definir la consulta SQL
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, A.IdMarca, C.Descripcion AS Categoria, A.IdCategoria, A.ImagenUrl, A.Precio FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE ";
                if (campoSeleccionado == "Precio")
                {
                    if (criterioSeleccionado == "Menor a")
                    {
                        consulta += "A.Precio < " + valor;
                    }
                    else if (criterioSeleccionado == "Mayor a")
                    {
                        consulta += "A.Precio > " + valor;
                    }
                    else if (criterioSeleccionado == "Igual a")
                    {
                        consulta += "A.Precio = " + valor;
                    }
                }
                else if (campoSeleccionado == "Marca")
                {
                    consulta += "M.Descripcion LIKE '%" + valor + "%'";
                }
                else if (campoSeleccionado == "Categoria")
                {
                    consulta += "C.Descripcion LIKE '%" + valor + "%'";
                }
                datos.SqlQuery(consulta);
                // Ejecutar la consulta y obtener el resultado
                var reader = datos.EjecutarLectura();
                // Leer los resultados
                while (reader.Read())
                {
                    // Crear un nuevo objeto Articulo
                    // Verifico si los campos son nulos
                    Articulo aux = new Articulo();
                    aux.Id = (int)reader["Id"];
                    aux.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? "VACIO" : reader["Codigo"].ToString();
                    aux.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? "VACIO" : reader["Nombre"].ToString();
                    aux.Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "VACIO" : reader["Descripcion"].ToString();
                    aux.Marca = new Marcas();
                    aux.Marca.Nombre = reader.IsDBNull(reader.GetOrdinal("Marca")) ? "VACIO" : reader["Marca"].ToString();
                    aux.Marca.Id = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? 0 : (int)reader["IdMarca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Nombre = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? "VACIO" : reader["Categoria"].ToString();
                    aux.Categoria.Id = reader.IsDBNull(reader.GetOrdinal("IdCategoria")) ? 0 : (int)reader["IdCategoria"];
                    aux.ImagenUrl = reader.IsDBNull(reader.GetOrdinal("ImagenUrl")) ? "VACIO" : reader["ImagenUrl"].ToString();
                    aux.Precio = reader.IsDBNull(reader.GetOrdinal("Precio")) ? 0000 : (decimal)reader["Precio"];
                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar los articulos: " + ex.Message);
            }
        }

        public Articulo FiltroCodigo(string Clave)
        {
            ConexionDB conexion = new ConexionDB();
            Articulo articulo = new Articulo();
            try
            {

                conexion.SqlProcedimiento("storeFiltroCodigo");
                conexion.AgregarParametro("@Codigo", Clave);
                var reader = conexion.EjecutarLectura();

                if (reader.Read())
                {
                    articulo.Id = (int)reader["Id"];
                    articulo.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? "VACIO" : reader["Codigo"].ToString();
                    articulo.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? "VACIO" : reader["Nombre"].ToString();
                    articulo.Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "VACIO" : reader["Descripcion"].ToString();
                    articulo.Marca = new Marcas();
                    articulo.Marca.Nombre = reader.IsDBNull(reader.GetOrdinal("Marca")) ? "VACIO" : reader["Marca"].ToString();
                    articulo.Marca.Id = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? 0 : (int)reader["IdMarca"];
                    articulo.Categoria = new Categorias();
                    articulo.Categoria.Nombre = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? "VACIO" : reader["Categoria"].ToString();
                    articulo.Categoria.Id = reader.IsDBNull(reader.GetOrdinal("IdCategoria")) ? 0 : (int)reader["IdCategoria"];
                    articulo.ImagenUrl = reader.IsDBNull(reader.GetOrdinal("ImagenUrl")) ? "VACIO" : reader["ImagenUrl"].ToString();
                    articulo.Precio = reader.IsDBNull(reader.GetOrdinal("Precio")) ? 999 : (decimal)reader["Precio"];
                    System.Diagnostics.Debug.WriteLine("PRECIO LEÍDO: " + articulo.Precio);


                    return articulo;
                }
                else { return null; }

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al filtrar el articulo por ID (Codigo: {Clave}): {ex.Message}");
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public List<Articulo> Lista()
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDB conexion = new ConexionDB();
            try
            {

                // Definir la consulta SQL
                conexion.SqlQuery("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, A.IdMarca, C.Descripcion AS Categoria, A.IdCategoria, A.ImagenUrl, A.Precio FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id");
                // Ejecutar la consulta y obtener el resultado
                var reader = conexion.EjecutarLectura();
                // Leer los resultados
                while (reader.Read())
                {
                    // Crear un nuevo objeto Articulo
                    // Verifico si los campos son nulos
                    Articulo aux = new Articulo();
                    aux.Id = (int)reader["Id"];
                    aux.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? "VACIO" : reader["Codigo"].ToString();
                    aux.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? "VACIO" : reader["Nombre"].ToString();
                    aux.Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "VACIO" : reader["Descripcion"].ToString();
                    aux.Marca = new Marcas();
                    aux.Marca.Nombre = reader.IsDBNull(reader.GetOrdinal("Marca")) ? "VACIO" : reader["Marca"].ToString();
                    aux.Marca.Id = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? 0 : (int)reader["IdMarca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Nombre = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? "VACIO" : reader["Categoria"].ToString();
                    aux.Categoria.Id = reader.IsDBNull(reader.GetOrdinal("IdCategoria")) ? 0 : (int)reader["IdCategoria"];
                    aux.ImagenUrl = reader.IsDBNull(reader.GetOrdinal("ImagenUrl")) ? "VACIO" : reader["ImagenUrl"].ToString();
                    aux.Precio = reader.IsDBNull(reader.GetOrdinal("Precio")) ? 0000 : (decimal)reader["Precio"];

                    lista.Add(aux);


                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los articulos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos y el lector
                conexion.CerrarConexion();


            }
        }

        public List<Articulo> ListaSp()
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDB datos = new ConexionDB();
            try
            {

                //string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, A.IdMarca, C.Descripcion AS Categoria, A.IdCategoria, A.ImagenUrl, A.Precio FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE ";
                //datos.SqlQuery(consulta);
                datos.SqlProcedimiento("storelistar");
                var reader = datos.EjecutarLectura();
                // Leer los resultados
                while (reader.Read())
                {
                    // Crear un nuevo objeto Articulo
                    // Verifico si los campos son nulos
                    Articulo aux = new Articulo();
                    aux.Id = (int)reader["Id"];
                    aux.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? "VACIO" : reader["Codigo"].ToString();
                    aux.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? "VACIO" : reader["Nombre"].ToString();
                    aux.Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "VACIO" : reader["Descripcion"].ToString();
                    aux.Marca = new Marcas();
                    aux.Marca.Nombre = reader.IsDBNull(reader.GetOrdinal("Marca")) ? "VACIO" : reader["Marca"].ToString();
                    aux.Marca.Id = reader.IsDBNull(reader.GetOrdinal("IdMarca")) ? 0 : (int)reader["IdMarca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Nombre = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? "VACIO" : reader["Categoria"].ToString();
                    aux.Categoria.Id = reader.IsDBNull(reader.GetOrdinal("IdCategoria")) ? 0 : (int)reader["IdCategoria"];
                    aux.ImagenUrl = reader.IsDBNull(reader.GetOrdinal("ImagenUrl")) || string.IsNullOrWhiteSpace(reader["ImagenUrl"].ToString()) ? "https://cdn4.iconfinder.com/data/icons/ui-beast-3/32/ui-49-4096.png" : reader["ImagenUrl"].ToString();
                    aux.Precio = reader.IsDBNull(reader.GetOrdinal("Precio")) ? 0000 : (decimal)reader["Precio"];
                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar los articulos: " + ex.Message);
            }
        }

        public List<Marcas> ObtenerMarcas()
        {
            List<Marcas> lista = new List<Marcas>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                // Consulta SQL para obtener las marcas
                conexion.SqlQuery("SELECT Id, Descripcion FROM MARCAS");
                var reader = conexion.EjecutarLectura();

                // Leer los resultados y convertirlos en objetos Marcas
                while (reader.Read())
                {
                    lista.Add(new Marcas
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Descripcion"].ToString()
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las marcas: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public List<Categorias> ObtenerCategorias()
        {
            List<Categorias> lista = new List<Categorias>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                // Consulta SQL para obtener las categorías
                conexion.SqlQuery("SELECT Id, Descripcion FROM CATEGORIAS");
                var reader = conexion.EjecutarLectura();

                // Leer los resultados y convertirlos en objetos Categorias
                while (reader.Read())
                {
                    lista.Add(new Categorias
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Descripcion"].ToString()
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las categorías: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public List<Articulo> Ultimos3Elementos()
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlQuery("SELECT TOP 3 Codigo, Nombre, Descripcion, ImagenUrl FROM Articulos ORDER BY Id DESC");
                var reader = conexion.EjecutarLectura();
                while (reader.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? "VACIO" : reader["Codigo"].ToString();
                    aux.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? "VACIO" : reader["Nombre"].ToString();
                    aux.Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "VACIO" : reader["Descripcion"].ToString();
                    aux.ImagenUrl = reader.IsDBNull(reader.GetOrdinal("ImagenUrl")) ? "VACIO" : reader["ImagenUrl"].ToString();
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los últimos 3 elementos: " + ex.Message);

            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void AgregarSp(Articulo art)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlProcedimiento("storeAgregar");
                conexion.AgregarParametro("@Codigo", string.IsNullOrEmpty(art.Codigo) ? (object)DBNull.Value : art.Codigo);
                conexion.AgregarParametro("@Nombre", string.IsNullOrEmpty(art.Nombre) ? (object)DBNull.Value : art.Nombre);
                conexion.AgregarParametro("@Descripcion", string.IsNullOrEmpty(art.Descripcion) ? (object)DBNull.Value : art.Descripcion);
                conexion.AgregarParametro("@IdMarca", art.Marca?.Id > 0 ? (object)art.Marca.Id : DBNull.Value);
                conexion.AgregarParametro("@IdCategoria", art.Categoria?.Id > 0 ? (object)art.Categoria.Id : DBNull.Value);
                conexion.AgregarParametro("@ImagenUrl", string.IsNullOrEmpty(art.ImagenUrl) ? (object)DBNull.Value : art.ImagenUrl);
                conexion.AgregarParametro("@Precio", art.Precio > 0 ? (object)art.Precio : DBNull.Value);
                conexion.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el artículo: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void Agregar(Articulo articulo)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlQuery("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) " +
                                  "VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                conexion.AgregarParametro("@Codigo", articulo.Codigo);
                conexion.AgregarParametro("@Nombre", articulo.Nombre);
                conexion.AgregarParametro("@Descripcion", articulo.Descripcion);
                conexion.AgregarParametro("@IdMarca", articulo.Marca.Id);
                conexion.AgregarParametro("@IdCategoria", articulo.Categoria.Id);
                conexion.AgregarParametro("@ImagenUrl", articulo.ImagenUrl);
                conexion.AgregarParametro("@Precio", articulo.Precio);
                conexion.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el artículo: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void Modificar(Articulo articulo)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlQuery("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, " +
                                  "IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio " +
                                  "WHERE Id = @Id");
                conexion.AgregarParametro("@Codigo", articulo.Codigo);
                conexion.AgregarParametro("@Nombre", articulo.Nombre);
                conexion.AgregarParametro("@Descripcion", articulo.Descripcion);
                conexion.AgregarParametro("@IdMarca", articulo.Marca.Id);
                conexion.AgregarParametro("@IdCategoria", articulo.Categoria.Id);
                conexion.AgregarParametro("@ImagenUrl", articulo.ImagenUrl);
                conexion.AgregarParametro("@Precio", articulo.Precio);
                conexion.AgregarParametro("@Id", articulo.Id);
                conexion.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el artículo: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void ModificarSp(Articulo articulo)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlProcedimiento("storeModificar");
                conexion.AgregarParametro("@Codigo", articulo.Codigo);
                conexion.AgregarParametro("@Nombre", articulo.Nombre);
                conexion.AgregarParametro("@Descripcion", articulo.Descripcion);
                conexion.AgregarParametro("@IdMarca", articulo.Marca.Id);
                conexion.AgregarParametro("@IdCategoria", articulo.Categoria.Id);
                conexion.AgregarParametro("@ImagenUrl", articulo.ImagenUrl);
                conexion.AgregarParametro("@Precio", articulo.Precio);
                conexion.AgregarParametro("@Id", articulo.Id);
                conexion.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el artículo: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlQuery("DELETE FROM ARTICULOS WHERE Id = @Id");
                conexion.AgregarParametro("@Id", id);
                conexion.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el artículo: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void EliminarSp(int id)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlProcedimiento("storeEliminar");
                conexion.AgregarParametro("@Id", id);
                conexion.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el artículo: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public bool ExisteCodigo(string codigo)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlQuery("SELECT COUNT(*) FROM ARTICULOS WHERE Codigo = @Codigo");
                conexion.AgregarParametro("@Codigo", codigo);
                int count = (int)conexion.EjecutarEscalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar el código: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void AgregarMarca(string nombre)
        {
            if (ExisteMarca(nombre))
            {
                throw new Exception("La marca ya existe.");
            }
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlQuery("INSERT INTO MARCAS (Descripcion) VALUES (@Nombre)");
                conexion.AgregarParametro("@Nombre", nombre);
                conexion.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la marca: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void AgregarCategoria(string nombre)
        {
            if (ExisteCategoria(nombre))
            {
                throw new Exception("La categoria ya existe.");
            }
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlQuery("INSERT INTO CATEGORIAS (Descripcion) VALUES (@Nombre)");
                conexion.AgregarParametro("@Nombre", nombre);
                conexion.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la categoría: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public bool ExisteMarca(string nombre)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlQuery("Select count(*) from MARCAS where MARCAS.descripcion = @nombre");
                conexion.AgregarParametro("@nombre", nombre);
                int count = (int)conexion.EjecutarEscalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la marca: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            {

            }
        }

        public bool ExisteCategoria(string nombre)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlQuery("Select count(*) from CATEGORIAS where CATEGORIAS.descripcion = @nombre");
                conexion.AgregarParametro("@nombre", nombre);
                int count = (int)conexion.EjecutarEscalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la categoria: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public List<Articulo> FiltroMultiple(List<string> marcas, List<string> categorias)
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDB datos = new ConexionDB();

            try
            {
                string consulta = @"SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, 
                            M.Descripcion AS Marca, A.IdMarca, 
                            C.Descripcion AS Categoria, A.IdCategoria, 
                            A.ImagenUrl, A.Precio 
                            FROM ARTICULOS A 
                            INNER JOIN MARCAS M ON A.IdMarca = M.Id 
                            INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id 
                            WHERE 1 = 1";

                // Marcas
                if (marcas.Count > 0)
                {
                    string filtrosMarcas = string.Join(",", marcas.Select(m => $"'{m}'"));
                    consulta += $" AND M.Descripcion IN ({filtrosMarcas})";
                }

                // Categorías
                if (categorias.Count > 0)
                {
                    string filtrosCategorias = string.Join(",", categorias.Select(c => $"'{c}'"));
                    consulta += $" AND C.Descripcion IN ({filtrosCategorias})";
                }

                datos.SqlQuery(consulta);
                var reader = datos.EjecutarLectura();

                while (reader.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)reader["Id"];
                    aux.Codigo = reader["Codigo"].ToString();
                    aux.Nombre = reader["Nombre"].ToString();
                    aux.Descripcion = reader["Descripcion"].ToString();
                    aux.Marca = new Marcas();
                    aux.Marca.Nombre = reader["Marca"].ToString();
                    aux.Marca.Id = (int)reader["IdMarca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Nombre = reader["Categoria"].ToString();
                    aux.Categoria.Id = (int)reader["IdCategoria"];
                    aux.ImagenUrl = reader["ImagenUrl"].ToString();
                    aux.Precio = (decimal)reader["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar múltiples: " + ex.Message);
            }
        }


    }

}
