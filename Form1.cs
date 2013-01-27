using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VocabularyProject
{
    public partial class Form1 : Form
    {
        VocabularyModel _vocabularyModel;
        InsertPage _insertPage;
        List<VocabularyData> _vocabularyDataList;

        public Form1()
        {
            InitializeComponent();
            _vocabularyModel = new VocabularyModel();
            _insertPage = new InsertPage(_vocabularyModel);
            _insertPage._modelChange += UpdateInsertPageView;
            _vocabularyDataList = _vocabularyModel.GetVocabularyList();
            _bindingSourceVocabularyList.DataSource = _vocabularyDataList;
        }

        private void UpdateInsertPageView()
        {
            _textBoxAddVocabulary.Text = _insertPage.Vocabulary;
            _textBoxAddEnglishExplanation.Text = _insertPage.EnglishExplanation;
            _textBoxAddChineseExplanation.Text = _insertPage.ChineseExplanation;
            _textBoxAddEnglishExample.Text = _insertPage.EnglishExample;
            _textBoxAddChineseExample.Text = _insertPage.ChineseExample;
            _textBoxAddComment.Text = _insertPage.Comment;
        }

        private void ClickAddSubmitButton(object sender, EventArgs e)
        {
            String vocabulary = _textBoxAddVocabulary.Text;
            DateTime dateTime = DateTime.Now;
            String englishExplanation = _textBoxAddEnglishExplanation.Text;
            String chineseExplanation = _textBoxAddChineseExplanation.Text;
            String englishExample = _textBoxAddEnglishExample.Text;
            String chineseExample = _textBoxAddChineseExample.Text;
            String comment = _textBoxAddComment.Text;
            _insertPage.ClickAddSubmitButton(vocabulary,dateTime, englishExplanation, chineseExplanation, englishExample, chineseExample, comment);
            _textBoxAddVocabulary.Focus();
        }

        private void ChangeAddVocabularyTextBox(object sender, EventArgs e)
        {
            _insertPage.ChangeAddVocabularyTextBox(_textBoxAddVocabulary.Text);
        }

        private void ChangeAddEnglishExplanationTextBox(object sender, EventArgs e)
        {
            _insertPage.ChangeAddEnglishExplanationTextBox(_textBoxAddEnglishExplanation.Text);
        }

        private void ChangeAddChineseExplanationTextBox(object sender, EventArgs e)
        {
            _insertPage.ChangeAddChineseExplanationTextBox(_textBoxAddChineseExplanation.Text);
        }

        private void ChangeAddEnglishExampleTextBox(object sender, EventArgs e)
        {
            _insertPage.ChangeAddEnglishExampleTextBox(_textBoxAddEnglishExample.Text);
        }

        private void ChangeAddChineseExampleTextBox(object sender, EventArgs e)
        {
            _insertPage.ChangeAddChineseExampleTextBox(_textBoxAddChineseExample.Text);
        }

        private void ChangeAddCommentTextBox(object sender, EventArgs e)
        {
            _insertPage.ChangeAddCommentTextBox(_textBoxAddComment.Text);
        }
    }
}
