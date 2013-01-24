using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace SQLiteCon
{
    public class StudentDB
    {
        const String SELECT_SQL_COMMAND = "select * from Student";

        public void CreateTable()
        {
            try
            {
                using (DbConnection con = SQLiteConnectionBuilder.GetDbConnection())
                {
                    con.Open();
                    DbCommand cmd = con.CreateCommand();
                    const String CREATE_COMMAND = "create table Student(id TEXT, name TEXT, birthday TEXT, height REAL, weight INTEGER);";
                    cmd.CommandText = CREATE_COMMAND;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (SQLiteException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        public void DropTable()
        {
            try
            {
                using (DbConnection con = SQLiteConnectionBuilder.GetDbConnection())
                {
                    con.Open();
                    DbCommand cmd = con.CreateCommand();
                    const String DROP_COMMAND = "drop table Student";
                    cmd.CommandText = DROP_COMMAND;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (SQLiteException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        public List<Student> GetStudentListByDbConnection()
        {
            List<Student> students = new List<Student>();
            DbConnection dbConnection = SQLiteConnectionBuilder.GetDbConnection();
            dbConnection.Open();
            try
            {
                DbCommand dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = SELECT_SQL_COMMAND;
                DbDataReader dbReader = dbCommand.ExecuteReader();
                while (dbReader.Read())
                {
                    Student student = GetStudent(dbReader);
                    students.Add(student);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                dbConnection.Close();
            }
            return students;
        }

        private static Student GetStudent(DbDataReader reader)
        {
            Student student = new Student();
            student.Id = reader.GetString(0);
            student.Name = reader.GetString(1);
            student.Birthday = reader.GetDateTime(2);
            student.Height = reader.GetDouble(3);
            student.Weight = reader.GetInt32(4);
            return student;
        }

        public List<Student> GetStudentListBySQLiteConnection()
        {
            List<Student> students = new List<Student>();
            SQLiteConnection sqliteConnection = SQLiteConnectionBuilder.GetSQLiteConnection();
            sqliteConnection.Open();
            try

            {
                SQLiteCommand sqliteCommand = sqliteConnection.CreateCommand();
                sqliteCommand.CommandText = SELECT_SQL_COMMAND;
                SQLiteDataReader sqliteReader = sqliteCommand.ExecuteReader();
                while (sqliteReader.Read())
                {
                    Student student = GetStudent(sqliteReader);
                    students.Add(student);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                sqliteConnection.Close();
            }
            return students;
        }

        public void InsertStudent(Student student)
        {
            try
            {
                using (DbConnection dbConnection = SQLiteConnectionBuilder.GetDbConnection())
                {//"create table Student(id TEXT, name TEXT, birthday TEXT, height REAL, weight INTEGER);";
                    String dateString = student.Birthday.ToString("yyyy-MM-dd HH:mm:ss");
                    String insertCommand = "insert into Student(id, name, birthday, height, weight) values('" + student.Id + "','" + student.Name + "','" + dateString + "', " + student.Height + ", " + student.Weight + ");";
                    dbConnection.Open();
                    DbCommand cmd = dbConnection.CreateCommand();
                    cmd.CommandText = insertCommand;
                    cmd.ExecuteNonQuery();
                    //if you want to add another data, you have to do ExecuteNonQuery twice.
                    //cmd.CommandText = INSERT_COMMAND2;
                    //cmd.ExecuteNonQuery();
                    dbConnection.Close();
                }
            }
            catch (SQLiteException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
    }
}
