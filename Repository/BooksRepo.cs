using Microsoft.Data.Sqlite;
using System.Data;
using System.Net;
using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public class BooksRepo:IBooksRepo
    {
        private readonly string _connectionString;

        public BooksRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Books> GetAll()
        {   
            var books = new List<Books>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT BookId, Title ,Author , Genre , PublicationDate , TotalCopies , AvailableCopies From Books";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Books
                        {
                            BookId = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            Genre = reader.GetString(3),
                            PublicationDate = reader.GetDateTime(4),
                            TotalCopies = reader.GetInt32(5),
                            AvailableCopies = reader.GetInt32(6)

                        });
                    }
                }
            }
            return books;
        }
    }
}
