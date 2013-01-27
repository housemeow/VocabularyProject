public class PresentationModel
{
    public delegate void ModelChangedHandler();
    public event ModelChangedHandler _modelChange;

    public void UpdateView()
    {
        if (_modelChange != null)
        {
            _modelChange();
        }
    }

    public PresentationModel(VocabularyModel vocabularyModel)
    {
        _vocabularyModel = vocabularyModel;
    }

    protected VocabularyModel _vocabularyModel;
}
