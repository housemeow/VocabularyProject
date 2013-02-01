using System;
using System.Collections.Generic;
public class VocabularyModel
{
    public delegate void ModelChangedEventHandler();
    public event ModelChangedEventHandler ModelChanged;
    public List<VocabularyData> _vocabularyList;
    public SQLiteDB _sqliteDB;

    public VocabularyModel()
    {
        _sqliteDB = new SQLiteDB();
        _sqliteDB.InitializeDB();
    }

    /// <summary>
    /// Update a vocabularyData which has specified id.
    /// </summary>
    /// <param name="vocabularyData"></param>
    public void UpdateVocabulary(VocabularyData vocabularyData)
    {
        _sqliteDB.UpdateVocabularyData(vocabularyData);
    }

    /// <summary>
    /// Delete a vocabularyData which has specified id.
    /// </summary>
    /// <param name="vocabularyData"></param>
    public void DeleteVocabulary(VocabularyData vocabularyData)
    {
        _sqliteDB.DeleteVocabularyData(vocabularyData);
    }

    /// <summary>
    /// Get all vocabularies.
    /// </summary>
    /// <returns></returns>
    public List<VocabularyData> GetVocabularyList()
    {
        return _sqliteDB.GetVocabularyList();;
    }

    /// <summary>
    /// Get vocabularies which contain filterString.
    /// </summary>
    /// <param name="filterString"></param>
    /// <returns></returns>
    public List<VocabularyData> GetFilteredVocabularyListByString(string filterString)
    {
        List<VocabularyData> vocabularyList = this.GetVocabularyList();
        List<VocabularyData> filteredVocabularyList = new List<VocabularyData>();
        if (filterString == string.Empty)
        {
            return vocabularyList;
        }
        else
        {
            foreach (VocabularyData vocabularyData in vocabularyList)
            {
                if (vocabularyData.Vocabulary.Length >= filterString.Length)
                {
                    string subString = vocabularyData.Vocabulary.Substring(0, filterString.Length);
                    if (subString.Equals(filterString))
                    {
                        filteredVocabularyList.Add(vocabularyData);
                    }
                }
            }
            return filteredVocabularyList;
        }
    }

    /// <summary>
    /// Add vocabularyData.
    /// </summary>
    /// <param name="vocabulary"></param>
    /// <param name="dateTime"></param>
    /// <param name="englishExplanation"></param>
    /// <param name="chineseExplanation"></param>
    /// <param name="englishExample"></param>
    /// <param name="chineseExample"></param>
    /// <param name="comment"></param>
    internal void AddVocabulary(string vocabulary, DateTime dateTime, string englishExplanation, string chineseExplanation, string englishExample, string chineseExample, string comment)
    {
        VocabularyData vocabularyData = new VocabularyData(vocabulary, dateTime, englishExplanation, chineseExplanation, englishExample, chineseExample, comment);
        _sqliteDB.InsertVocabularyData(vocabularyData);
    }

    /// <summary>
    /// Trigger all event handler.
    /// </summary>
    internal void ChangeModel()
    {
        if (ModelChanged != null)
        {
            ModelChanged();
        }
    }

    /// <summary>
    /// Delete vocabularyData which has specified id.
    /// </summary>
    /// <param name="id"></param>
    internal void DeleteVocabularyData(int id)
    {
        VocabularyData vocabularyData =  new VocabularyData();
        vocabularyData.Id = id;
        _sqliteDB.DeleteVocabularyData(vocabularyData);
        ChangeModel();
    }

    /// <summary>
    /// Update all vocabularies which has specified id.
    /// </summary>
    /// <param name="vocabularyDataList"></param>
    internal void UpdateVocabularyDataList(List<VocabularyData> vocabularyDataList)
    {
        foreach (VocabularyData vocabularyData in vocabularyDataList)
        {
            UpdateVocabulary(vocabularyData);
        }
    }

    /// <summary>
    /// Return true if the vocabulary is exist.
    /// </summary>
    /// <param name="vocabulary"></param>
    /// <returns></returns>
    internal bool IsExist(string vocabulary)
    {
        return _sqliteDB.IsExist(vocabulary);
    }
}
