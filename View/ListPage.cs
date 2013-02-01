using System.Collections.Generic;
public class ListPage : PresentationModel
{
    private bool _isDeleteButtonEnabled;
    private bool _isModifyButtonEnabled;
    private bool _isCancelButtonEnabled;
    private int _vocabularyId;
    private List<VocabularyData> _vocabularyDataList;

    public ListPage(VocabularyModel vocabularyModel)
        : base(vocabularyModel)
    {

    }

    public bool IsDeleteButtonEnabled
    {
        get { return _isDeleteButtonEnabled; }
    }

    public bool IsModifyButtonEnabled
    {
        get { return _isModifyButtonEnabled; }
    }

    public bool IsCancelButtonEnabled
    {
        get { return _isCancelButtonEnabled; }
    }

    public List<VocabularyData> VocabularyDataList
    {
        get { return _vocabularyDataList; }
    }

    /// <summary>
    /// click modify button
    /// </summary>
    internal void ClickModifyButton()
    {
        _vocabularyModel.UpdateVocabularyDataList(_vocabularyDataList);
        SetButtonEnabled(false, false, false);
        UpdateView();
    }

    /// <summary>
    /// set buttons enabled
    /// </summary>
    /// <param name="deleteButtonEnabled"></param>
    /// <param name="modifyButtonEnabled"></param>
    /// <param name="cancelButtonEnabled"></param>
    private void SetButtonEnabled(bool deleteButtonEnabled, bool modifyButtonEnabled, bool cancelButtonEnabled)
    {
        _isDeleteButtonEnabled = deleteButtonEnabled;
        _isModifyButtonEnabled = modifyButtonEnabled;
        _isCancelButtonEnabled = cancelButtonEnabled;
    }

    /// <summary>
    /// click delete button
    /// </summary>
    internal void ClickDeleteButton()
    {
        _vocabularyModel.DeleteVocabularyData(_vocabularyId);
        SetButtonEnabled(false, false, false);
        UpdateView();
    }

    /// <summary>
    /// click cancel button
    /// </summary>
    internal void ClickCancelButton()
    {
        SetButtonEnabled(false, false, false);
        UpdateView();
    }

    /// <summary>
    /// change selected vocabulary
    /// </summary>
    /// <param name="vocabularyId"></param>
    /// <param name="vocabularyDataList"></param>
    internal void ChangeVocabulariesDataGridViewSelection(int vocabularyId, List<VocabularyData> vocabularyDataList)
    {
        _vocabularyId = vocabularyId;
        _vocabularyDataList = vocabularyDataList;
        SetButtonEnabled(true, _isModifyButtonEnabled, true);
        UpdateView();
    }

    /// <summary>
    /// change vocabularyData
    /// </summary>
    /// <param name="vocabularyDataList"></param>
    internal void ChangeVocabulariesDataGridViewCellValue(List<VocabularyData> vocabularyDataList)
    {
        _vocabularyDataList = vocabularyDataList;
        SetButtonEnabled(true, true, true);
        UpdateView();
    }

    /// <summary>
    /// initialize listpage view
    /// </summary>
    internal void Initialize()
    {
        SetButtonEnabled(false, false, false);
        UpdateView();
    }
}
