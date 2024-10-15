using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public class BorrowingReportRepo : IBorrowingReportRepo
    {
        private readonly string _connectionString;
        public BorrowingReportRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<BorrowingReport> GetAll()
        {
            var borrowing = new List<BorrowingReport>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT LendingId , MemberName,BookTitle,LendingDate,DueDate,ReturnDate ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                            borrowing.Add(new BorrowingReport
                            {
                                LendingId = reader.GetInt32(0),
                                MemberName = reader.GetString(1),
                                BookTitle = reader.GetString(2),
                                LendingDate = reader.GetDateTime(3),
                                DueDate = reader.GetDateTime(4),
                                ReturnDate = reader.GetDateTime(5),
                            });
                        
                    }
                }

            }
            return borrowing;
        }

        public BorrowingReport GetById(int BorrowingReportId)
        {
            using ( var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText=""
            }
        }
        
    }
}
