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
            _vocabularyDataList = _vocabularyModel.GetVocabularyList();
            //_bindingSourceVocabularyList.DataSource = _vocabularyDataList;
            _dataGridViewVocabularies.DataSource = _vocabularyDataList;
        }

        private void ClickAddSubmitButton(object sender, EventArgs e)
        {
            String vocabulary = _textBoxAddVocabulary.Text;
            String englishExplanation = _textBoxAddEnglishExplanation.Text;
            String chineseExplanation = _textBoxAddChineseExplanation.Text;
            String englishExample = _textBoxAddEnglishExample.Text;
            String chineseExample = _textBoxAddChineseExample.Text;
            String comment = _textBoxAddComment.Text;
            _insertPage.ClickAddSubmitButton(vocabulary, englishExplanation, chineseExplanation, englishExample, chineseExample, comment);
        }
    }
}
