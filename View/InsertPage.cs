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
        get
        {
            return _errorMessage;
        }
    }

    public InsertPage(VocabularyModel vocabularyModel)
        : base(vocabularyModel)
    {
        ClearTextBoxes();
    }

    /// <summary>
    /// Clear all fields
    /// </summary>
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

    /// <summary>
    /// change vocabulary textbox text
    /// </summary>
    /// <param name="vocabulary"></param>
    internal void ChangeAddVocabularyTextBox(string vocabulary)
    {
        _vocabulary = vocabulary;
        Validate();
        UpdateView();
    }

    /// <summary>
    /// change english expalantion textbox
    /// </summary>
    /// <param name="englishExplanation"></param>
    internal void ChangeAddEnglishExplanationTextBox(string englishExplanation)
    {
        _englishExplanation = englishExplanation;
        Validate();
        UpdateView();
    }

    /// <summary>
    /// change chinese explanatnion textbox
    /// </summary>
    /// <param name="chineseExplanation"></param>
    internal void ChangeAddChineseExplanationTextBox(string chineseExplanation)
    {
        _chineseExplanation = chineseExplanation;
        Validate();
        UpdateView();
    }

    /// <summary>
    /// change english example textbox
    /// </summary>
    /// <param name="englishExample"></param>
    internal void ChangeAddEnglishExampleTextBox(string englishExample)
    {
        _englishExample = englishExample;
        Validate();
        UpdateView();
    }

    /// <summary>
    /// change chinese exmaple textbox
    /// </summary>
    /// <param name="chineseExample"></param>
    internal void ChangeAddChineseExampleTextBox(string chineseExample)
    {
        _chineseExample = chineseExample;
        Validate();
        UpdateView();
    }

    /// <summary>
    /// change comment textbox
    /// </summary>
    /// <param name="comment"></param>
    internal void ChangeAddCommentTextBox(string comment)
    {
        _comment = comment;
        Validate();
        UpdateView();
    }

    /// <summary>
    /// validate all fields and set error message
    /// </summary>
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

    /// <summary>
    /// click submit button
    /// </summary>
    /// <param name="dateTime"></param>
    internal void ClickAddSubmitButton(DateTime dateTime)
    {
        _vocabularyModel.AddVocabulary(_vocabulary, dateTime, _englishExplanation, _chineseExplanation, _englishExample, _chineseExample, _comment);
        ClearTextBoxes();
        UpdateView();
        _vocabularyModel.ChangeModel();
    }
}
