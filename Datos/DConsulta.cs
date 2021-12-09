using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Common.DTO;
using Common.Cache;


namespace Datos
{
    public class DConsulta : DConexion
    {
        MySqlDataReader Leer;

        public bool ObtenerUsuario(string usuario, string Contraseña)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_validarlogin";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nombreusuario", usuario);
                    comando.Parameters.AddWithValue("@contraseñausuario", Contraseña);
                    Leer = comando.ExecuteReader();
                    if (Leer.HasRows) //Si encuentra columnas
                    {
                        while (Leer.Read()) //Obtenemos los datos de la columna y asignamos a los campos de las propiedades
                        {
                            Usuario.cve_usuario = Leer.GetInt32(0);
                            Usuario.nombre_usuario = Leer.GetString(1);
                            Usuario.nombre_completo = Leer.GetString(2);
                            Usuario.apepaterno_usuario = Leer.GetString(3);
                            Usuario.apematerno_usuario = Leer.GetString(4);
                            Usuario.edad_usuario = Leer.GetInt32(5);
                            Usuario.contraseña = Leer.GetString(6);
                            Usuario.fechaalta_usuario = Leer.GetString(7);
                            Usuario.fechamod_usuario = Leer.IsDBNull(8) ? null : Leer.GetString(8);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public DataTable MostrarReservacion()
        {
            DataTable Reservacion = new DataTable();
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_mostrarReservacion";
                    comando.CommandType = CommandType.StoredProcedure;
                    Leer = comando.ExecuteReader();
                    Reservacion.Load(Leer);
                    Leer.Close();
                }
            }
            return Reservacion;
        }

        public DataTable mostrarPeliculaB()
        {
            DataTable Pelicula = new DataTable();
            using (var conexion = ObtenerConexion())
            { 
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_mostrarPeliculaB";
                    comando.CommandType = CommandType.Text;
                    Leer = comando.ExecuteReader();
                    Pelicula.Load(Leer);
                    Leer.Close();
                }
            }
            return Pelicula;
        }
        public DataTable mostrarPeliculaB15()
        {
            DataTable Pelicula = new DataTable();
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_mostrarPeliculaB15";
                    comando.CommandType = CommandType.Text;
                    Leer = comando.ExecuteReader();
                    Pelicula.Load(Leer);
                    Leer.Close();
                }
            }
            return Pelicula;
        }
        public DataTable mostrarPeliculaC()
        {
            DataTable Pelicula = new DataTable();
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_mostrarPeliculaC";
                    comando.CommandType = CommandType.Text;
                    Leer = comando.ExecuteReader();
                    Pelicula.Load(Leer);
                    Leer.Close();
                }
            }
            return Pelicula;
        }
        public DataTable mostrarPeliculaD()
        {
            DataTable Pelicula = new DataTable();
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_mostrarPeliculaD";
                    comando.CommandType = CommandType.Text;
                    Leer = comando.ExecuteReader();
                    Pelicula.Load(Leer);
                    Leer.Close();
                }
            }
            return Pelicula;
        }
        public DataTable mostrarPeliculasDG()
        {
            DataTable Pelicula = new DataTable();
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_mostrarPeliculaDG";
                    comando.CommandType = CommandType.Text;
                    Leer = comando.ExecuteReader();
                    Pelicula.Load(Leer);
                    Leer.Close();
                }
            }
            return Pelicula;
        }
        public DataTable mostrarClasificacion()
        {
            DataTable Clasificacion = new DataTable();
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_mostrarClasificacion";
                    comando.CommandType = CommandType.StoredProcedure;
                    Leer = comando.ExecuteReader();
                    Clasificacion.Load(Leer);
                    Leer.Close();
                }
            }
            return Clasificacion;
        }

        public DataTable mostrarUsuario()
        {
            DataTable Usuarios = new DataTable();

            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_mostrarUsuario";
                    comando.CommandType = CommandType.StoredProcedure;
                    Leer = comando.ExecuteReader();
                    Usuarios.Load(Leer);
                    Leer.Close();
                }
            }
            return Usuarios;
        }
        public DataTable mostrarSala()
        {
            DataTable Sala = new DataTable();

            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_mostrarSala";
                    comando.CommandType = CommandType.StoredProcedure;
                    Leer = comando.ExecuteReader();
                    Sala.Load(Leer);
                    Leer.Close();
                }
            }
            return Sala;
        }
        public DataTable mostrarSalaCB()
        {
            DataTable Sala = new DataTable();

            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_mostrarSalaCB";
                    comando.CommandType = CommandType.StoredProcedure;
                    Leer = comando.ExecuteReader();
                    Sala.Load(Leer);
                    Leer.Close();
                }
            }
            return Sala;
        }

        //
        //OBTENER NUMERO DE ASIENTOS RESERVADOS
        //
        public List< > obtenerNumAsiento(int CveAsiento)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_obtenerNumeroAsiento";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@cvePelicula", CveAsiento);

                    Leer = comando.ExecuteReader();

                    List<Asiento> NumeroAsiento = new List<Asiento>();

                    while (Leer.Read())
                    {
                        NumeroAsiento.Add(new Asiento { numeroAsiento = Leer.GetInt32(0) });
                    }
                    Leer.Close();

                    return NumeroAsiento;
                }
                
            }
        }
        //
        //OBTENER CLAVE DE SALA 
        //
        public int obtenercvesala(int cvePelicula)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_obtenerCveSala";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@cvepelicula", cvePelicula);
                    comando.Parameters.Add("cvesala", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    comando.ExecuteNonQuery();
                    return (int)comando.Parameters["@cvesala"].Value;
                }
            }
        }
        //
        //OBTENER CAPACIDAD DE SALA
        //
        public int capacidadSala(int cve_pelicula)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_capacidadAsiento;";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@cvepelicula", cve_pelicula);
                    comando.Parameters.Add("capacidadSala",MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    comando.ExecuteNonQuery();
                    return (int)comando.Parameters["@capacidadSala"].Value;
                }
            }

        }
        //
        //OBTENER CLAVE DE ASIENTO 
        //
        public int ObtenerCveAsiento(int CveSala, int NumAsiento)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_obtenerCveAsiento";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@cveSala", CveSala);
                    comando.Parameters.AddWithValue("@numAsiento", NumAsiento);
                    comando.Parameters.Add("cveAsiento", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    comando.ExecuteNonQuery();
                    return (int)comando.Parameters["@cveAsiento"].Value;
                }
            }
        }
        //
        //VALIDAR LA EDAD OBTENIENDO BOOL
        //
       
        //
        //INSERTAR, ACTUALIZAR Y ELIMINAR DATOS
        //
        public void insertaUsuario(string nombreusuario, string nombrecompleto, string apepaterno, string apematerno, int edad,  string contraseña)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_agregarusuario";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("nombreusuario", nombreusuario);
                    comando.Parameters.AddWithValue("nombrecompleto", nombrecompleto);
                    comando.Parameters.AddWithValue("apepaterno", apepaterno);
                    comando.Parameters.AddWithValue("apematerno", apematerno);
                    comando.Parameters.AddWithValue("edadusuario", edad);
                    comando.Parameters.AddWithValue("contraseñausuario", contraseña);
                    comando.ExecuteNonQuery();
                } 
            }
        }
        public void insertarRervacion(int cveUsuario, int cvePelicula, int cveAsiento)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_insertarReservacion";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("cveusuario", cveUsuario);
                    comando.Parameters.AddWithValue("cvepelicula", cvePelicula);
                    comando.Parameters.AddWithValue("cveasiento", cveAsiento);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void insertarSala(string NombreSala, int CapacidadSala, int CveClasificacion)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_insertarSala";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("nombreSala", NombreSala);
                    comando.Parameters.AddWithValue("capacidadSala", CapacidadSala);
                    comando.Parameters.AddWithValue("cveclasificacionSala", CveClasificacion);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void insertarPelicula(string nombrePelicula, int cveSala)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_insertarPelicula";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("nombrePelicula", nombrePelicula);
                    comando.Parameters.AddWithValue("cveSala", cveSala);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void ActualizarAsiento(int cvepelicula, int numeroAsiento)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_actualizarAsiento";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("cvepelicula", cvepelicula);
                    comando.Parameters.AddWithValue("numeroAsiento", numeroAsiento);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void desActualizarAsiento(int cvepelicula, int numeroAsiento)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_desactualizarAsiento";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("cvepelicula", cvepelicula);
                    comando.Parameters.AddWithValue("numeroAsiento", numeroAsiento);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void EditarPerfil(int cveusuario, string nombreUsuario, string nombreCompleto, string apepaterno, string apematerno, string contraseña)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_editarUsuario";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("cveusuario", cveusuario);
                    comando.Parameters.AddWithValue("nombreUsuario", nombreUsuario);
                    comando.Parameters.AddWithValue("nombreCompleto", nombreCompleto);
                    comando.Parameters.AddWithValue("apepaterno", apepaterno);
                    comando.Parameters.AddWithValue("apematerno", apematerno);
                    comando.Parameters.AddWithValue("contraseña_mod", contraseña);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void ActualizarSala(string nombreSala, int capacidadSala, int cvleClasificacion, int cveSala)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_actualizarSala";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("nombreSala", nombreSala);
                    comando.Parameters.AddWithValue("capacidadSala", capacidadSala);
                    comando.Parameters.AddWithValue("cveclasificacion", cvleClasificacion);
                    comando.Parameters.AddWithValue("cveSala", cveSala);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void ModificarPelicula(string nombrePelicula, int cveSala, int cvePelicula)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_modificarPelicula";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("nombrePelicula", nombrePelicula);
                    comando.Parameters.AddWithValue("cveSala", cveSala);
                    comando.Parameters.AddWithValue("cvePelicula", cvePelicula);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void EliminarUsuario(int cveUsuario)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_eliminarUsuario";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("cveUsuario", cveUsuario);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void EliminarReservacion(int cveRervacion)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_borrarReservacion";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("cveReservacion", cveRervacion);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void EliminarSala(int cveSala)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_eliminarSala";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("cveSala", cveSala);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void EliminarPelicula(int cvePelicula)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "pa_eliminarPelicula";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("cvePelicula", cvePelicula);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
