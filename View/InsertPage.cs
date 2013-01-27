using System;
public class InsertPage : PresentationModel
{
    private string _vocabulary;
    private string _englishExplanation;
    private string _chineseExplanation;
    private string _englishExample;
    private string _chineseExample;
    private string _comment;

    public string Vocabulary
    {
        get
        {
            return _vocabulary;
        }
    }

    public string EnglishExplanation
    {
        get
        {
            return _englishExplanation;
        }
    }

    public string ChineseExplanation
    {
        get
        {
            return _chineseExplanation;
        }
    }
    public string EnglishExample
    {
        get
        {
            return _englishExample;
        }
    }

    public string ChineseExample
    {
        get
        {
            return _chineseExample;
        }
    }

    public string Comment
    {
        get
        {
            return _comment;
        }
    }

    public InsertPage(VocabularyModel vocabularyModel)
        : base(vocabularyModel)
    {
    }

    internal void ClickAddSubmitButton(string vocabulary, DateTime dateTime, string englishExplanation, string chineseExplanation, string englishExample, string chineseExample, string comment)
    {
        _vocabularyModel.AddVocabulary(vocabulary, dateTime, englishExplanation, chineseExplanation, englishExample, chineseExample, comment);
        ClearTextBoxes();
        UpdateView();
        _vocabularyModel.ChangeModel();
    }

    private void ClearTextBoxes()
    {
        _vocabulary = "";
        _englishExplanation = "";
        _chineseExplanation = "";
        _englishExample = "";
        _chineseExample = "";
        _comment = "";
        UpdateView();
    }

    internal void ChangeAddVocabularyTextBox(string vocabulary)
    {
        _vocabulary = vocabulary;
        UpdateView();
    }

    internal void ChangeAddEnglishExplanationTextBox(string englishExplanation)
    {
        _englishExplanation = englishExplanation;
        UpdateView();
    }

    internal void ChangeAddChineseExplanationTextBox(string chineseExplanation)
    {
        _chineseExplanation = chineseExplanation;
        UpdateView();
    }

    internal void ChangeAddEnglishExampleTextBox(string englishExample)
    {
        _englishExample = englishExample;
        UpdateView();
    }

    internal void ChangeAddChineseExampleTextBox(string chineseExample)
    {
        _chineseExample = chineseExample;
        UpdateView();
    }

    internal void ChangeAddCommentTextBox(string comment)
    {
        _comment = comment;
        UpdateView();
    }
}
