using System;
using System.Data.SqlClient;

namespace ListeLectureJCC.Models
{
    public class DataAccess
    {
        const string ConnectionString = @"Server=.\SQLExpress;Database=ListeLecture;Integrated Security=true";
        public static ConfirmationLectureModel ChargerConfirmationLectureDepuisBDD(int idLivre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "SELECT Titre, DateFinLecture FROM Livre WHERE ID = @idLivre", connection);
                command.Parameters.AddWithValue("@idLivre", idLivre);

                SqlDataReader reader = command.ExecuteReader();

                //On avance sur la première ligne
                reader.Read();

                string titre = (string)reader["Titre"];
                DateTime dateFinLecture = (DateTime)reader["DateFinLecture"];

                ConfirmationLectureModel model = new ConfirmationLectureModel(titre, dateFinLecture);

                return model;
            }
        }

        public static void MettreAJourDateDeFinDeLecture(int idLivre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    @"UPDATE Livre SET DateFinLecture = GETDATE() WHERE ID = @idLivre", connection);
                command.Parameters.AddWithValue("@idLivre", idLivre);

                command.ExecuteNonQuery();
            }
        }

        public static Livre ChargerLivreDepuisBDD(int idLivre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "SELECT Titre, Auteur, Note, DateDebutLecture, DateFinLecture FROM Livre WHERE ID = @idLivre", connection);
                command.Parameters.AddWithValue("@idLivre", idLivre);

                SqlDataReader reader = command.ExecuteReader();

                //On avance sur la première ligne
                reader.Read();

                string titre = (string)reader["Titre"];
                string auteur = (string)reader["Auteur"];

                short? note;
                if (reader.IsDBNull(2))
                {
                    note = null;
                }
                else
                {
                    note = (byte)reader["Note"];
                }

                DateTime dateDebutLecture = (DateTime)reader["DateDebutLecture"];

                DateTime? dateFinLecture;
                if (reader.IsDBNull(4))
                {
                    dateFinLecture = null;
                }
                else
                {

                    dateFinLecture = (DateTime)reader["DateFinLecture"];
                }

                Livre livre = new Livre(titre, auteur, dateDebutLecture, dateFinLecture, note, idLivre);
                return livre;
            }
        }

        internal static void MettreAJouerTitreEtAuteur(int idLivre, string titre, string auteur)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"UPDATE Livre SET titre=@titre, Auteur=@auteur WHERE ID = @idLivre", connection);
                command.Parameters.AddWithValue("@titre", titre);
                command.Parameters.AddWithValue("@auteur", auteur);
                command.Parameters.AddWithValue("@idLivre", idLivre);   
                command.ExecuteNonQuery();
            }
        }

        public static DetailModel ChargerDetailDepuisBDD(int idLivre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "SELECT Titre, Auteur, Note, DateDebutLecture, DateFinLecture FROM Livre WHERE ID = @idLivre", connection);
                command.Parameters.AddWithValue("@idLivre", idLivre);

                SqlDataReader reader = command.ExecuteReader();

                //On avance sur la première ligne
                reader.Read();

                string titre = (string)reader["Titre"];
                string auteur = (string)reader["Auteur"];

                short? note;
                if (reader.IsDBNull(2))
                {
                    note = null;
                }
                else
                {
                    note = (byte)reader["Note"];
                }

                DateTime dateDebutLecture = (DateTime)reader["DateDebutLecture"];

                DateTime? dateFinLecture;
                if (reader.IsDBNull(4))
                {
                    dateFinLecture = null;
                }
                else
                {

                    dateFinLecture = (DateTime)reader["DateFinLecture"];
                }

                DetailModel model = new DetailModel(titre, auteur, dateDebutLecture, dateFinLecture, note, idLivre);
                return model;
            }
        }

        public static int CreerNouveauLivre(string titre, string auteur)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"INSERT INTO Livre(Titre, Auteur, DateDebutLecture) OUTPUT Inserted.ID VALUES (@titre, @auteur, GETDATE())", connection);
                command.Parameters.AddWithValue("@titre", titre);
                command.Parameters.AddWithValue("@auteur", auteur);
                int idInsere = (int)command.ExecuteScalar();
                return idInsere;
            }
        }
    }
}