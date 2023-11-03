using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace webApi.Repositorios{
    public class TableroRepository : ITableroRepository{
        private string cadenaConexion = "Data Source=db/kanban.db;Cache=Shared";
        public void Create(Tablero tablero){
            var query = $"INSERT INTO Tablero (id_usuario_propietario, nombre, descripcion) VALUES (@idUser, @nombre, @descripcion)";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@idUser", tablero.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@nombre", tablero.Nombre));
                command.Parameters.Add(new SQLiteParameter("@idUser", tablero.Descripcion));

                command.ExecuteNonQuery();

                connection.Close();   
            }
        }
        public void Update(int id, Tablero tablero){
            var query = $"UPDATE Tablero SET id_usuario_propietario = @idUser, nombre = @nombre, descripcion = @descripcion WHERE id = @id";

            using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idUser", tablero.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@nombre", tablero.Nombre));
                command.Parameters.Add(new SQLiteParameter("@descripcion", tablero.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@id", tablero.Id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public List<Tablero> GetAll(){
             var queryString = @"SELECT * FROM Tablero;";
            List<Tablero> tableros = new List<Tablero>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(reader["id"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre"].ToString();
                        tablero.Descripcion = reader["descripcion"].ToString();
                        tableros.Add(tablero);
                    }
                }
                connection.Close();
            }
            return tableros;
        }
        public Tablero Get(int id);
        public List<Tablero> GetByUser(int idUsuario);
        public void Remove(int id);
    }
}