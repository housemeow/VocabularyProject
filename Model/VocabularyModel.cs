using System.Collections.Generic;
public class VocabularyModel {
	public List<VocabularyData> _vocabularyList ;
    public SQLiteDB _sqliteDB;

    public VocabularyModel()
    {
        _sqliteDB = new SQLiteDB();
        _sqliteDB.InitializeDB();
    }

    //public void AddVocabulary(VocabularyData vocabularyData){
    //    _sqliteDB.InsertVocabularyData(vocabularyData);
    //}

	public void UpdateVocabulary(VocabularyData vocabularyData){
        _sqliteDB.UpdateVocabularyData(vocabularyData);
	}

	public void DeleteVocabulary(VocabularyData vocabularyData){
        _sqliteDB.DeleteVocabularyData(vocabularyData);
	}

	public List<VocabularyData> GetVocabularyList(){
        List<VocabularyData> vocabularyList ;
        vocabularyList =  _sqliteDB.GetVocabularyList();
        return vocabularyList;
	}

    internal void AddVocabulary(string vocabulary, string englishExplanation, string chineseExplanation, string englishExample, string chineseExample)
    {
    }

    internal void AddVocabulary(string vocabulary, string englishExplanation, string chineseExplanation, string englishExample, string chineseExample, string comment)
    {
        VocabularyData vocabularyData = new VocabularyData(vocabulary, englishExplanation, chineseExplanation, englishExample, chineseExample, comment);
        _sqliteDB.InsertVocabularyData(vocabularyData);
    }
}
