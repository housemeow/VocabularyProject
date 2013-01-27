using System;
public class InsertPage : PresentationModel
{
    private string _vocabulary;
    private string _englishExplanation;
    private string _chineseExplanation;
    private string _englishExample;
    private string _chineseExample;
    private string _comment;
    private bool _isSubmitButtonEnabled;
    private String _errorMessage;

    public bool IsSubmitButtonEnabled
    {
        get
        {
            return _isSubmitButtonEnabled;
        }
    }

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

    public String ErrorMessage
    {
        get { return _errorMessage; }
    }

    public InsertPage(VocabularyModel vocabularyModel)
        : base(vocabularyModel)
    {
        ClearTextBoxes();
    }

    private void ClearTextBoxes()
    {
        _vocabulary = "";
        _englishExplanation = "";
        _chineseExplanation = "";
        _englishExample = "";
        _chineseExample = "";
        _comment = "";
        Validate();
        UpdateView();
    }

    internal void ChangeAddVocabularyTextBox(string vocabulary)
    {
        _vocabulary = vocabulary;
        Validate();
        UpdateView();
    }

    internal void ChangeAddEnglishExplanationTextBox(string englishExplanation)
    {
        _englishExplanation = englishExplanation;
        Validate();
        UpdateView();
    }

    internal void ChangeAddChineseExplanationTextBox(string chineseExplanation)
    {
        _chineseExplanation = chineseExplanation;
        Validate();
        UpdateView();
    }

    internal void ChangeAddEnglishExampleTextBox(string englishExample)
    {
        _englishExample = englishExample;
        Validate();
        UpdateView();
    }

    internal void ChangeAddChineseExampleTextBox(string chineseExample)
    {
        _chineseExample = chineseExample;
        Validate();
        UpdateView();
    }

    internal void ChangeAddCommentTextBox(string comment)
    {
        _comment = comment;
        Validate();
        UpdateView();
    }

    private void Validate()
    {
        if (_vocabularyModel.IsExist(_vocabulary))
        {
            _errorMessage = "有重複的單字存在";
            _isSubmitButtonEnabled = false;
        }
        else if (_vocabulary == String.Empty || (_chineseExplanation == String.Empty && _englishExplanation == String.Empty))
        {
            _errorMessage = "單字不能為空白以及中文或英文至少要有一個解釋";
            _isSubmitButtonEnabled = false;
        }
        else
        {
            _errorMessage = "";
            _isSubmitButtonEnabled = true;
        }
    }

    internal void ClickAddSubmitButton(DateTime dateTime)
    {
        _vocabularyModel.AddVocabulary(_vocabulary, dateTime, _englishExplanation, _chineseExplanation, _englishExample, _chineseExample, _comment);
        ClearTextBoxes();
        UpdateView();
        _vocabularyModel.ChangeModel();
    }
}
