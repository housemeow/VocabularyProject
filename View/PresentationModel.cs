public class PresentationModel
{
    public delegate void ViewChangedEventHandler();
    public event ViewChangedEventHandler ViewChanged;

    public void UpdateView()
    {
        if (ViewChanged != null)
        {
            ViewChanged();
        }
    }

    public PresentationModel(VocabularyModel vocabularyModel)
    {
        _vocabularyModel = vocabularyModel;
    }

    protected VocabularyModel _vocabularyModel;
}
