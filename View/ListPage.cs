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

    internal void ClickModifyButton()
    {
        _vocabularyModel.UpdateVocabularyDataList(_vocabularyDataList);
        SetButtonEnabled(false, false, false);
        UpdateView();
    }

    private void SetButtonEnabled(bool deleteButtonEnabled, bool modifyButtonEnabled, bool cancelButtonEnabled)
    {
        _isDeleteButtonEnabled = deleteButtonEnabled;
        _isModifyButtonEnabled = modifyButtonEnabled;
        _isCancelButtonEnabled = cancelButtonEnabled;
    }

    internal void ClickDeleteButton()
    {
        _vocabularyModel.DeleteVocabularyData(_vocabularyId);
        SetButtonEnabled(false, false, false);
        UpdateView();
    }

    internal void ClickCancelButton()
    {
        SetButtonEnabled(false, false, false);
        UpdateView();
    }

    internal void ChangeVocabulariesDataGridViewSelection(int vocabularyId, List<VocabularyData> vocabularyDataList)
    {
        _vocabularyId = vocabularyId;
        _vocabularyDataList = vocabularyDataList;
        SetButtonEnabled(true, _isModifyButtonEnabled, true);
        UpdateView();
    }

    internal void ChangeVocabulariesDataGridViewCellValue(List<VocabularyData> vocabularyDataList)
    {
        _vocabularyDataList = vocabularyDataList;
        SetButtonEnabled(true, true, true);
        UpdateView();
    }

    internal void Initialize()
    {
        SetButtonEnabled(false, false, false);
        UpdateView();
    }
}
