using SQLiteCon;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
public class SQLiteDB
{
    const String DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

    /// <summary>
    /// Initialize database.
    /// </summary>
    public void InitializeDB()
    {
        CreateTable();
    }

    /// <summary>
    /// Create VocabularyData table
    /// </summary>
    public void CreateTable()
    {
        try
        {
            using (DbConnection con = SQLiteConnectionBuilder.GetDbConnection())
            {
                con.Open();
                DbCommand cmd = con.CreateCommand();
                const String CREATE_COMMAND = "create table VocabularyData(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, vocabulary TEXT, addDateTime TEXT, " +
                    "englishExplanation TEXT, chineseExplanation TEXT, " +
                    "englishExample TEXT, chineseExample TEXT, " +
                    "correctTimes INTEGER, guessTimes INTEGER, comment TEXT);";
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

    /// <summary>
    /// Insert a vocabularyData
    /// </summary>
    /// <param name="vocabularyData"></param>
    public void InsertVocabularyData(VocabularyData vocabularyData)
    {
        try
        {
            using (DbConnection dbConnection = SQLiteConnectionBuilder.GetDbConnection())
            {//
                String vocabulary = vocabularyData.Vocabulary;
                String addDateTimeString = vocabularyData.AddDateTime.ToString(DATETIME_FORMAT);
                String chineseExplanation = vocabularyData.ChineseExplanation;
                String englishExplanation = vocabularyData.EnglishExplanation;
                String englishExample = vocabularyData.EnglishExample;
                String chineseExample = vocabularyData.ChineseExample;
                int correctTimes = vocabularyData.CorrectTimes;
                int guessTimes = vocabularyData.GuessTimes;
                String comment = vocabularyData.Comment;

                String insertCommand = "insert into VocabularyData(" +
                    "vocabulary, addDateTime, " +
                    "chineseExplanation, englishExplanation," +
                    "englishExample, chineseExample, " +
                    "correctTimes, guessTimes, comment) values('" + 
                    vocabulary + "','" + addDateTimeString + "', '" +
                    chineseExplanation + "', '" + englishExplanation + "', '" +
                    englishExample + "', '" + chineseExample + "', " +
                    correctTimes + ", " + guessTimes + ", '" + comment + "');";

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

    /// <summary>
    /// Retrieve a vocabulary by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public VocabularyData RetrieveVocabularyData(int id)
    {
        SQLiteConnection sqliteConnection = SQLiteConnectionBuilder.GetSQLiteConnection();
        sqliteConnection.Open();
        try
        {
            String selectCommand = "select * from Student WHERE id="+ id.ToString();
            SQLiteCommand sqliteCommand = sqliteConnection.CreateCommand();
            sqliteCommand.CommandText = selectCommand;
            SQLiteDataReader sqliteReader = sqliteCommand.ExecuteReader();
            while (sqliteReader.Read())
            {
                VocabularyData vocabularyData = GetVocabularyData(sqliteReader);
                return vocabularyData;
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
        return null;
    }

    /// <summary>
    /// Update a vocabulary which has a specified id.
    /// </summary>
    /// <param name="vocabularyData"></param>
    public void UpdateVocabularyData(VocabularyData vocabularyData)
    {
        try
        {
            using (DbConnection dbConnection = SQLiteConnectionBuilder.GetDbConnection())
            {//
                int id = vocabularyData.Id;
                String vocabulary = vocabularyData.Vocabulary;
                String addDateTimeString = vocabularyData.AddDateTime.ToString(DATETIME_FORMAT);
                String chineseExplanation = vocabularyData.ChineseExplanation;
                String englishExplanation = vocabularyData.EnglishExplanation;
                String englishExample = vocabularyData.EnglishExample;
                String chineseExample = vocabularyData.ChineseExample;
                int correctTimes = vocabularyData.CorrectTimes;
                int guessTimes = vocabularyData.GuessTimes;
                String comment = vocabularyData.Comment;
                /*
                    UPDATE table_name
                    SET column1=value, column2=value2,...
                    WHERE some_column=some_value
                  */
                String updateCommand = "UPDATE VocabularyData SET " +
                    "vocabulary='" + vocabulary + "', " +
                    "addDateTime='" + addDateTimeString + "', " +
                    "chineseExplanation='" + chineseExplanation + "', " +
                    "englishExplanation='" + englishExplanation + "', " +
                    "englishExample='" + englishExample + "', " +
                    "chineseExample='" + chineseExample + "', " +
                    "correctTimes=" + correctTimes.ToString() + ", " +
                    "guessTimes=" + guessTimes.ToString() + ", " +
                    "comment='" + comment + "'" +
                    " WHERE id=" + id.ToString();

                dbConnection.Open();
                DbCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = updateCommand;
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

    /// <summary>
    /// Delete a vocabulary which has a specified id
    /// </summary>
    /// <param name="vocabularyData"></param>
    public void DeleteVocabularyData(VocabularyData vocabularyData)
    {//DELETE FROM table_name WHERE some_column=some_value
        try
        {
            using (DbConnection dbConnection = SQLiteConnectionBuilder.GetDbConnection())
            {//
                int id = vocabularyData.Id;
                String DELETE_COMMAND = "DELETE FROM VocabularyData WHERE id=" + id.ToString();
                dbConnection.Open();
                DbCommand cmd = dbConnection.CreateCommand();
                cmd.CommandText = DELETE_COMMAND;
                cmd.ExecuteNonQuery();
                dbConnection.Close();
            }
        }
        catch (SQLiteException e)
        {
            System.Windows.Forms.MessageBox.Show(e.Message);
        }
    }

    /// <summary>
    /// Get a vocabularyData from database data type.
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>

    private static VocabularyData GetVocabularyData(DbDataReader reader)
    {/*
            int _id;
            String _vocabulary;
            DateTime _addDateTime;
            String _chineseExplanation;
            String _englishExplanation;
            String _example;
            String _chineseExample;
            int _correctTimes;
            int _guessTimes;
            String _comment;
        */
        VocabularyData vocabularyData = new VocabularyData();
        vocabularyData.Id = reader.GetInt32(0);
        vocabularyData.Vocabulary = reader.GetString(1);
        vocabularyData.AddDateTime = reader.GetDateTime(2);
        vocabularyData.EnglishExplanation = reader.GetString(3);
        vocabularyData.ChineseExplanation = reader.GetString(4);
        vocabularyData.EnglishExample = reader.GetString(5);
        vocabularyData.ChineseExample = reader.GetString(6);
        vocabularyData.CorrectTimes = reader.GetInt32(7);
        vocabularyData.GuessTimes = reader.GetInt32(8);
        vocabularyData.Comment = reader.GetString(9);
        return vocabularyData;
    }

    /// <summary>
    /// Get all vocabularies from database.
    /// </summary>
    /// <returns></returns>
    public List<VocabularyData> GetVocabularyList()
    {
        List<VocabularyData> vocabularyList = new List<VocabularyData>();
        SQLiteConnection sqliteConnection = SQLiteConnectionBuilder.GetSQLiteConnection();
        sqliteConnection.Open();
        try
        {
            const String SELECT_SQL_COMMAND = "select * from VocabularyData";
            SQLiteCommand sqliteCommand = sqliteConnection.CreateCommand();
            sqliteCommand.CommandText = SELECT_SQL_COMMAND;
            SQLiteDataReader sqliteReader = sqliteCommand.ExecuteReader();
            while (sqliteReader.Read())
            {
                VocabularyData vocabularyData = GetVocabularyData(sqliteReader);
                vocabularyList.Add(vocabularyData);
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
        return vocabularyList;
    }

    /// <summary>
    /// Return true if the vocabulary is exist.
    /// </summary>
    /// <param name="vocabulary"></param>
    /// <returns></returns>
    internal bool IsExist(string vocabulary)
    {
        List<VocabularyData> vocabularyDataList = GetVocabularyList();
        foreach (VocabularyData vocabularyData in vocabularyDataList)
        {
            if (vocabularyData.Vocabulary == vocabulary)
            {
                return true;
            }
        }
        return false;
    }
}
