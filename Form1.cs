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
        ListPage _listPage;
        EditPage _editPage;

        public Form1()
        {
            InitializeComponent();
            _vocabularyModel = new VocabularyModel();
            _insertPage = new InsertPage(_vocabularyModel);
            _insertPage.ViewChanged += UpdateInsertPageView;
            _listPage = new ListPage(_vocabularyModel);
            _listPage.ViewChanged += UpdateListPageView;
            _editPage = new EditPage(_vocabularyModel);
            _editPage.ViewChanged += UpdateEditPage;
            _vocabularyModel.ModelChanged += ChangeModel;
            _dataGridViewVocabularies.AutoGenerateColumns = true;
            _bindingSourceVocabularyList.DataSource = _vocabularyModel.GetVocabularyList();
        }

        private void UpdateListPageView()
        {
            _buttonDelete.Enabled = _listPage.IsDeleteButtonEnabled;
            _buttonModify.Enabled = _listPage.IsModifyButtonEnabled;
            _buttonCancel.Enabled = _listPage.IsCancelButtonEnabled;
        }

        private void ChangeModel()
        {
            _bindingSourceVocabularyList.DataSource = _vocabularyModel.GetVocabularyList();
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
            _insertPage.ClickAddSubmitButton(vocabulary, dateTime, englishExplanation, chineseExplanation, englishExample, chineseExample, comment);
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

        private void ClickModifyButton(object sender, EventArgs e)
        {
            _listPage.ClickModifyButton();
        }

        private void ClickDeleteButton(object sender, EventArgs e)
        {
            int rowIndex = _dataGridViewVocabularies.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = _dataGridViewVocabularies.Rows[rowIndex];
            VocabularyData vocabularyData = dataGridViewRow.DataBoundItem as VocabularyData;
            String vocabularyDataDetails = GetVocabularyDetailString(vocabularyData);
            if (MessageBox.Show(vocabularyDataDetails, "Do you want to Delete?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                _listPage.ClickDeleteButton();
            }
        }

        private static string GetVocabularyDetailString(VocabularyData vocabularyData)
        {
            String vocabularyDataDetails = "";
            vocabularyDataDetails += "編號" + vocabularyData.Id + "\n";
            vocabularyDataDetails += "單字" + vocabularyData.Vocabulary + "\n";
            vocabularyDataDetails += "加入時間" + vocabularyData.AddDateTime.ToShortDateString() + "\n";
            vocabularyDataDetails += "中文解釋" + vocabularyData.ChineseExplanation + "\n";
            vocabularyDataDetails += "英文解釋" + vocabularyData.EnglishExplanation + "\n";
            vocabularyDataDetails += "英文例句" + vocabularyData.EnglishExample + "\n";
            vocabularyDataDetails += "例句中文解釋" + vocabularyData.ChineseExample + "\n";
            vocabularyDataDetails += "備註" + vocabularyData.Comment;
            return vocabularyDataDetails;
        }

        private void ClickCancelButton(object sender, EventArgs e)
        {
            _listPage.ClickCancelButton();
            ResetDataGridView();
        }

        private void ChangeVocabulariesDataGridViewCellValue(object sender, DataGridViewCellEventArgs e)
        {
            if (_listPage != null)
            {
                List<VocabularyData> vocabularyDataList = (List<VocabularyData>)_bindingSourceVocabularyList.DataSource;
                _listPage.ChangeVocabulariesDataGridViewCellValue(vocabularyDataList);
            }
        }

        private void ClickVocabulariesDataGridViewCell(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                int vocabularyId = (int)_dataGridViewVocabularies.Rows[rowIndex].Cells[0].Value;
                List<VocabularyData> vocabularyDataList = (List<VocabularyData>)_bindingSourceVocabularyList.DataSource;
                _listPage.ChangeVocabulariesDataGridViewSelection(vocabularyId, vocabularyDataList);
            }
        }

        private void ResetDataGridView()
        {
            _bindingSourceVocabularyList.DataSource = _vocabularyModel.GetVocabularyList();
        }

        private void LeaveViewVocabulariesTabPage(object sender, EventArgs e)
        {
            if (_listPage.IsModifyButtonEnabled)
            {
                MessageBox.Show("已取消您做的任何修改，如果需要修改下次請按Modify按鈕。", "Notify");
                _bindingSourceVocabularyList.DataSource = _vocabularyModel.GetVocabularyList();
                _listPage.Initialize();
            }
        }

        private void ChangeVocabularyFilterTextBoxText(object sender, EventArgs e)
        {

        }

        private void ChangeModifyVocabularyTextBoxText(object sender, EventArgs e)
        {
            _editPage.ChangeModifyVocabularyTextBoxText(_textBoxModifyVocabulary.Text);
        }

        private void ChangeModifyEnglishExplanationTextBoxText(object sender, EventArgs e)
        {
            _editPage.ChangeModifyEnglishExplanationTextBoxText(_textBoxModifyEnglishExplanation.Text);
        }

        private void ChangeModifyChineseExplanationTextBoxText(object sender, EventArgs e)
        {
            _editPage.ChangeModifyChineseExplanationTextBoxText(_textBoxModifyChineseExplanation.Text);
        }

        private void ChangeModifyEnglishExampleTextBoxText(object sender, EventArgs e)
        {
            _editPage.ChangeModifyEnglishExampleTextBoxText(_textBoxModifyEnglishExample.Text);
        }

        private void ChangeModifyChineseExampleTextBoxText(object sender, EventArgs e)
        {
            _editPage.ChangeModifyChineseExampleTextBoxText(_textBoxModifyChineseExample.Text);
        }

        private void ChangeModifyCommentTextBoxText(object sender, EventArgs e)
        {
            _editPage.ChangeModifyCommentTextBoxText(_textBoxModifyComment.Text);
        }

        private void ClickModifySubmitButton(object sender, EventArgs e)
        {
            _editPage.ClickModifySubmitButton();
        }

        private void UpdateEditPage()
        {
            _textBoxModifyVocabulary.Text = _editPage.Vocabulary;
            _textBoxModifyChineseExplanation.Text = _editPage.ChineseExplanation;
            _textBoxModifyEnglishExplanation.Text = _editPage.EnglishExplanation;
            _textBoxModifyChineseExample.Text = _editPage.ChineseExample;
            _textBoxModifyEnglishExample.Text = _editPage.EnglishExample;
            _textBoxModifyComment.Text = _editPage.Comment;
            _buttonModifySubmit.Enabled = _editPage.IsSubmitButtonEnabled;
        }

        private void ClickSelectVocabularyDataGridViewCell(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = _dataGridViewSelectVocabulary.SelectedCells[0].RowIndex;
            if (rowIndex != -1)
            {
                DataGridViewRow dataGridViewRow = _dataGridViewSelectVocabulary.Rows[rowIndex];
                VocabularyData vocabularyData = dataGridViewRow.DataBoundItem as VocabularyData;
                _editPage.ClickSelectVocabularyDataGridViewCell(vocabularyData);
            }
        }

        private void _tabPageModifyVocabulary_Leave(object sender, EventArgs e)
        {
            if (_editPage.IsSubmitButtonEnabled)
            {
                MessageBox.Show("已取消您做的任何修改，如果需要修改下次請按Modify按鈕。", "Notify");
                _bindingSourceVocabularyList.DataSource = _vocabularyModel.GetVocabularyList();
                _editPage.Initialize();
            }
        }
    }
}
