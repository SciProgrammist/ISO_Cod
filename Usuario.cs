using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace Proyecto_Catedra_PEDG01T
{
    public class Usuario
    {
        Conexion conexion = new Conexion();

        private string idUsuario;
        private string nombre;
        private string apellido;
        private DateTime fechanacimiento;
        private string user;
        private string contrasena;
        private string email;
        private string telefono;
        private string idtypeUser;       
        private string tipousuario;
        private string verificarcontra;

        private SqlDataAdapter dataAdapter;
        private SqlDataReader dataReader;
        private SqlCommand command;


        public string IdUsuario
        {
            get { return idUsuario; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("El campo IdUsuario no puede estar vació.");
                else
                    idUsuario = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                if (string.IsNullOrEmpty(Nombre))
                {
                    throw new Exception("El campo Nombre no puede estar vació.");
                }
            }
        }
        public string Apellido
        {
            get { return apellido; }
            set
            {
                apellido = value;
                if (string.IsNullOrEmpty(Apellido))
                {
                    throw new Exception("El campo Apellido no puede estar vació.");
                }
            }
        }

        public DateTime FechaNacimiento
        {
            get { return fechanacimiento; }
            set
            {
                fechanacimiento = value;
            }
        }

        public string User
        {
            get { return user; }
            set
            {
                user = value;
                if (string.IsNullOrEmpty(User))
                {
                    throw new Exception("El campo Usuario no puede estar vació.");
                }
            }
        }

        public string Contrasena
        {
            get { return contrasena; }
            set
            {
                contrasena = value;
                if (string.IsNullOrEmpty(Contrasena))
                {
                    throw new Exception("El campo Contraseña no puede estar vació.");
                }
            }
        }

        public string VerficarContra
        {
            get { return verificarcontra; }
            set
            {
                verificarcontra = value;
                if (string.IsNullOrEmpty(VerficarContra))
                {
                    throw new Exception("El campo Verificar Contrasena no puede estar vació.");
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                if (string.IsNullOrEmpty(Email))
                {
                    throw new Exception("El campo Email no puede estar vació.");
                }

            }
        }

        public string Telefono
        {
            get { return telefono; }
            set
            {
                telefono = value;
                if (string.IsNullOrEmpty(Telefono.ToString()))
                {
                    throw new Exception("El campo Telefono no puede estar vació.");
                }
            }
        }

        public string TipoUsuario
        {
            get { return tipousuario; }
            set
            {
                tipousuario = value;
                if (string.IsNullOrEmpty(TipoUsuario))
                {
                    throw new Exception("El campo TipoUsuario no puede estar vació.");
                }
            }
        }       

        public string IdtypeUser
        {
            get => idtypeUser;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("El campo IDTipoUsuario no puede estar vació.");
                else
                    idtypeUser = value;
            }
        }


        //----- Métodos de la clase -----//

        //Método que guarda un usuario en la BD
        public void SaveUserInDB()
        {
            string sqlinsert = "INSERT INTO Usuarios(nombre, apellido, fechaNacimiento, usuario, contrasena, email, Telefono , idTipoUsuario)" +
                "VALUES(@nombre, @apellido, @fechanaci, @usuario, @clave, @correo, @tel, @idTypeoUser)";
            try
            {
                conexion.Conectar();
                command = new SqlCommand(sqlinsert, conexion.Conn);

                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@apellido", Apellido);
                command.Parameters.AddWithValue("@fechanaci", FechaNacimiento);
                command.Parameters.AddWithValue("@usuario", User);
                command.Parameters.AddWithValue("@clave", Contrasena);
                command.Parameters.AddWithValue("@correo", Email);
                command.Parameters.AddWithValue("@tel", Telefono);
                command.Parameters.AddWithValue("@idTypeoUser", IdtypeUser);
                command.ExecuteNonQuery();

                MessageBox.Show("Usuario creado exitosamente, ahora inicie sesión", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al registrar usuario: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        //guarda registro en la tabla Tipo_usuario y retorna el Id del registro (posiblemente se borre)
        private int SaveTypeUserDB()
        {
            string sqlinsert = "INSER INTO Tipo_usuario (TipoUsuario) VALUES (@typeUser)";
            command = new SqlCommand(sqlinsert, conexion.Conn);
            command.Parameters.AddWithValue("@typeUser", TipoUsuario);
            command.ExecuteNonQuery();

            dataAdapter = new SqlDataAdapter("SELECT TOP 1 * FROM Tipo_Usuario ORDER BY idTipoUsuario DESC", conexion.Conn);
            dataReader = dataAdapter.SelectCommand.ExecuteReader();
            dataReader.Read();
            return Convert.ToInt32(dataReader["idTipoUsuario"]);
        }

        //método encargado de extraer un usuario desde la BD
        public bool GetUserFromDB(string usuario, string contrasena, string tipoUsuario)
        {
            bool userExists = false;
            string seleccionar = "SELECT idUsuario, nombre, apellido, fechaNacimiento, usuario, contrasena, " + 
                "email, Telefono, usu.idTipoUsuario, TipoUsuario FROM Usuarios usu " +
                "INNER JOIN Tipo_usuario tpuser " +
                "ON usu.idTipoUsuario = tpuser.idTipoUsuario " +
                "WHERE usuario = @user AND contrasena = @contra AND TipoUsuario = @typeusu";
            try
            {
                conexion.Conectar();
                dataAdapter = new SqlDataAdapter(seleccionar, conexion.Conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@user", usuario);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@contra", contrasena);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@typeusu", tipoUsuario);
                dataReader = dataAdapter.SelectCommand.ExecuteReader();

                //evalua si existe el registro de este usuario
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    IdUsuario = dataReader["idUsuario"].ToString();
                    Nombre = dataReader["nombre"].ToString();
                    Apellido = dataReader["apellido"].ToString();
                    FechaNacimiento = Convert.ToDateTime(dataReader["fechaNacimiento"].ToString());
                    User = dataReader["usuario"].ToString();
                    Contrasena = dataReader["contrasena"].ToString();
                    Email = dataReader["email"].ToString();
                    Telefono = dataReader["Telefono"].ToString();
                    IdtypeUser = dataReader[8].ToString();
                    TipoUsuario = dataReader["TipoUsuario"].ToString();
                    userExists = true;
                }
                dataReader.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ha ocurrido un error al extraer el usuario desde la BD. Contacte con el Administrador: "
                    + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Cerrar();
            }
            return userExists;
        }

        public bool claveEsfuerte(string password)
        {
            int cuentanum = 0;
            int cuentaminusculas = 0;
            int cuentamayusculas = 0;
            char[] contra = password.ToArray<char>();

            Regex reminus = new Regex(@"\A([a-z])\Z");
            Regex remayuus = new Regex(@"\A([A-Z])\Z");
            Regex renum = new Regex(@"\A([0-9])\Z");

            //Vamos caracter a caracter y comprobamos que tipo de caracter es
            for (int i = 0; i < password.Length; i++)
            {
                if (remayuus.IsMatch(Convert.ToString(contra[i])))
                {
                    cuentamayusculas++;
                }
                else if (reminus.IsMatch(Convert.ToString(contra[i])))
                {
                    cuentaminusculas++;
                }
                else if (renum.IsMatch(Convert.ToString(contra[i])))
                {
                    cuentanum++;
                }
            }

            //Si la constraseña tiene mas de 3 numeros, mas de 2 minuscula y mas de 2 mayusculas
            if (cuentanum >= 3 && cuentaminusculas >= 2 && cuentamayusculas >= 2)
                return true;
            else
                return false;
        }

        //método encargado de actualizar un usuario en la BD
        public bool UpdateUser()
        {
            int rowsAffected = 0;
            string sqlupdate = "UPDATE Usuarios SET nombre = @nombre, apellido = @apellido, fechaNacimiento = @fnacimiento, " +
                "usuario = @user, contrasena = @clave, email = @correo, Telefono = @tel WHERE idUsuario = @idUser";
            try
            {
                conexion.Conectar();

                command = new SqlCommand(sqlupdate, conexion.Conn);
                command.Parameters.AddWithValue("@idUser", IdUsuario);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@apellido", Apellido);
                command.Parameters.AddWithValue("@fnacimiento", FechaNacimiento);
                command.Parameters.AddWithValue("@user", User);
                command.Parameters.AddWithValue("@clave", Contrasena);
                command.Parameters.AddWithValue("@correo", Email);
                command.Parameters.AddWithValue("@tel", Telefono);
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al actualizar usuario en la BD: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rowsAffected = 0;
            }
            finally
            {
                conexion.Cerrar();
            }

            if (rowsAffected != 0)
                return true;
            else
                return false;
        }

    }
}

