public class PresentationModel
{
    public delegate void ViewChangedEventHandler();
    public event ViewChangedEventHandler ViewChanged;
    protected VocabularyModel _vocabularyModel;

    /// <summary>
    /// trigger event handlers
    /// </summary>
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
}
