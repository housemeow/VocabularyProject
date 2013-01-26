public class InsertPage : PresentationModel
{
    public InsertPage(VocabularyModel vocabularyModel)
        : base(vocabularyModel)
    {
    }

    internal void ClickAddSubmitButton(string vocabulary, string englishExplanation, string chineseExplanation, string englishExample, string chineseExample, string comment)
    {
        _vocabularyModel.AddVocabulary(vocabulary, englishExplanation, chineseExplanation, englishExample, chineseExample, comment);
    }
}
