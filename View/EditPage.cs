using System;
public class EditPage : PresentationModel
{
    private String _vocabulary;
    private String _englishExplanation;
    private String _chineseExplanation;
    private String _englishExample;
    private String _chineseExample;
    private String _comment;
    private Boolean _isSubmitButtonEnabled;
    private VocabularyData _vocabularyData;

    public EditPage(VocabularyModel vocabularyModel)
        : base(vocabularyModel)
    {
        _vocabulary = String.Empty;
        _englishExplanation = String.Empty;
        _chineseExplanation = String.Empty;
        _englishExample = String.Empty;
        _chineseExample = String.Empty;
        _comment = String.Empty;
        _isSubmitButtonEnabled = false;
    }

    public String Vocabulary
    {
        get { return _vocabulary; }
    }

    public String EnglishExplanation
    {
        get { return _englishExplanation; }
    }

    public String ChineseExplanation
    {
        get { return _chineseExplanation; }
    }

    public String EnglishExample
    {
        get { return _englishExample; }
    }

    public String ChineseExample
    {
        get { return _chineseExample; }
    }

    public String Comment
    {
        get { return _comment; }
        set { _comment = value; }
    }

    public Boolean IsSubmitButtonEnabled
    {
        get { return _isSubmitButtonEnabled; }
    }

    internal void ChangeModifyVocabularyTextBoxText(string vocabulary)
    {
        _vocabulary = vocabulary;
        Validate();
        UpdateView();
    }

    internal void ChangeModifyEnglishExplanationTextBoxText(string englishExplanation)
    {
        _englishExplanation = englishExplanation;
        Validate();
        UpdateView();
    }

    internal void ChangeModifyChineseExplanationTextBoxText(string chineseExplanation)
    {
        _chineseExplanation = chineseExplanation;
        Validate();
        UpdateView();
    }

    internal void ChangeModifyEnglishExampleTextBoxText(string englishExample)
    {
        _englishExample = englishExample;
        Validate();
        UpdateView();
    }

    internal void ChangeModifyChineseExampleTextBoxText(string chineseExample)
    {
        _chineseExample = chineseExample;
        Validate();
        UpdateView();
    }

    internal void ChangeModifyCommentTextBoxText(string comment)
    {
        _comment = comment;
        Validate();
        UpdateView();
    }

    internal void ClickModifySubmitButton()
    {
        UpdateVocabularyData();
        Initialize();
        UpdateView();
    }

    private void UpdateVocabularyData()
    {
        _vocabularyData.Vocabulary = _vocabulary;
        _vocabularyData.EnglishExplanation = _englishExplanation;
        _vocabularyData.ChineseExplanation = _chineseExplanation;
        _vocabularyData.EnglishExample = _englishExample;
        _vocabularyData.ChineseExample = _chineseExample;
        _vocabularyData.Comment = _comment;
        _vocabularyModel.UpdateVocabulary(_vocabularyData);
    }

    public void Initialize()
    {
        _vocabulary = String.Empty;
        _chineseExplanation = String.Empty;
        _englishExplanation = String.Empty;
        _chineseExample = String.Empty;
        _englishExample = String.Empty;
        _comment = String.Empty;
        _isSubmitButtonEnabled = false;
        UpdateView();
    }

    private void Validate()
    {
        if (_vocabulary == String.Empty || (_chineseExplanation == String.Empty && _englishExplanation == String.Empty))
        {
            _isSubmitButtonEnabled = false;
        }
        else
        {
            if (IsModified())
            {
                _isSubmitButtonEnabled = true;

            }
            else
            {
                _isSubmitButtonEnabled = false;
            }
        }
    }

    private bool IsModified()
    {
        if (_vocabularyData.Vocabulary != _vocabulary)
        {
            return true;
        }
        else if (_vocabularyData.EnglishExplanation != _englishExplanation)
        {
            return true;
        }
        else if (_vocabularyData.ChineseExplanation != _chineseExplanation)
        {
            return true;
        }
        else if (_vocabularyData.EnglishExample != _englishExample)
        {
            return true;
        }
        else if (_vocabularyData.ChineseExample != _chineseExample)
        {
            return true;
        }
        else if (_vocabularyData.Comment != _comment)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal void ClickSelectVocabularyDataGridViewCell(VocabularyData vocabularyData)
    {
        _vocabularyData = vocabularyData;
        _vocabulary = vocabularyData.Vocabulary;
        _chineseExplanation = vocabularyData.ChineseExplanation;
        _englishExplanation = vocabularyData.EnglishExplanation;
        _chineseExample = vocabularyData.ChineseExample;
        _englishExample = vocabularyData.EnglishExample;
        _comment = vocabularyData.Comment;
        _isSubmitButtonEnabled = false;
        UpdateView();
    }
}
