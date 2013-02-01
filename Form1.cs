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
        EditPage _modifyPage;

        public Form1()
        {
            InitializeComponent();
            _vocabularyModel = new VocabularyModel();
            _insertPage = new InsertPage(_vocabularyModel);
            _insertPage.ViewChanged += UpdateInsertPageView;
            _listPage = new ListPage(_vocabularyModel);
            _listPage.ViewChanged += UpdateListPageView;
            _modifyPage = new EditPage(_vocabularyModel);
            _modifyPage.ViewChanged += UpdateModifyPage;
            _vocabularyModel.ModelChanged += ChangeModel;
            _dataGridViewVocabularies.AutoGenerateColumns = true;
            _dataGridViewSelectVocabulary.AutoGenerateColumns = true;
            _bindingSourceVocabularyList.DataSource = _vocabularyModel.GetVocabularyList();
            _dataGridViewSelectVocabulary.DataSource = _vocabularyModel.GetVocabularyList();
        }

        #region InsertPage
        /// <summary>
        /// InsertPage view updateEvent handler
        /// </summary>
        private void UpdateInsertPageView()
        {
            _textBoxAddVocabulary.Text = _insertPage.Vocabulary;
            _textBoxAddEnglishExplanation.Text = _insertPage.EnglishExplanation;
            _textBoxAddChineseExplanation.Text = _insertPage.ChineseExplanation;
            _textBoxAddEnglishExample.Text = _insertPage.EnglishExample;
            _textBoxAddChineseExample.Text = _insertPage.ChineseExample;
            _textBoxAddComment.Text = _insertPage.Comment;
            _buttonAddSubmit.Enabled = _insertPage.IsSubmitButtonEnabled;
            _errorProvider.SetError(_buttonAddSubmit, _insertPage.ErrorMessage);
        }

        //click add submit button
        private void ClickAddSubmitButton(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            _insertPage.ClickAddSubmitButton(dateTime);
            _textBoxAddVocabulary.Focus();
            _dataGridViewSelectVocabulary.DataSource = _vocabularyModel.GetFilteredVocabularyListByString(_textBoxVocabularyFilter.Text);
        }

        //change vocabulary textbox
        private void ChangeAddVocabularyTextBox(object sender, EventArgs e)
        {
            _insertPage.ChangeAddVocabularyTextBox(_textBoxAddVocabulary.Text);
        }

        //change english explanation textbox
        private void ChangeAddEnglishExplanationTextBox(object sender, EventArgs e)
        {
            _insertPage.ChangeAddEnglishExplanationTextBox(_textBoxAddEnglishExplanation.Text);
        }

        //change chinese explanation textbox
        private void ChangeAddChineseExplanationTextBox(object sender, EventArgs e)
        {
            _insertPage.ChangeAddChineseExplanationTextBox(_textBoxAddChineseExplanation.Text);
        }

        //change english example textbox
        private void ChangeAddEnglishExampleTextBox(object sender, EventArgs e)
        {
            _insertPage.ChangeAddEnglishExampleTextBox(_textBoxAddEnglishExample.Text);
        }

        //change chinese example textbox
        private void ChangeAddChineseExampleTextBox(object sender, EventArgs e)
        {
            _insertPage.ChangeAddChineseExampleTextBox(_textBoxAddChineseExample.Text);
        }

        //change comment textbox
        private void ChangeAddCommentTextBox(object sender, EventArgs e)
        {
            _insertPage.ChangeAddCommentTextBox(_textBoxAddComment.Text);
        }
        #endregion//InsertPage


        #region ListPage
        //listPage update event handler
        private void UpdateListPageView()
        {
            _buttonDelete.Enabled = _listPage.IsDeleteButtonEnabled;
            _buttonModify.Enabled = _listPage.IsModifyButtonEnabled;
            _buttonCancel.Enabled = _listPage.IsCancelButtonEnabled;
        }

        //click modify button
        private void ClickModifyButton(object sender, EventArgs e)
        {
            _listPage.ClickModifyButton();
            _dataGridViewSelectVocabulary.DataSource = _vocabularyModel.GetFilteredVocabularyListByString(_textBoxVocabularyFilter.Text);
        }

        //click delete button
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
            _dataGridViewSelectVocabulary.DataSource = _vocabularyModel.GetFilteredVocabularyListByString(_textBoxVocabularyFilter.Text);
        }

        //click cancel button
        private void ClickCancelButton(object sender, EventArgs e)
        {
            _listPage.ClickCancelButton();
            ResetDataGridView();
        }

        //change vocabularyData value
        private void ChangeVocabulariesDataGridViewCellValue(object sender, DataGridViewCellEventArgs e)
        {
            if (_listPage != null)
            {
                List<VocabularyData> vocabularyDataList = (List<VocabularyData>)_bindingSourceVocabularyList.DataSource;
                _listPage.ChangeVocabulariesDataGridViewCellValue(vocabularyDataList);
            }
        }

        //select a vocabulary
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

        //reset datagrid datasource
        private void ResetDataGridView()
        {
            _bindingSourceVocabularyList.DataSource = _vocabularyModel.GetVocabularyList();
        }

        //leave ListPage
        private void LeaveViewVocabulariesTabPage(object sender, EventArgs e)
        {
            if (_listPage.IsModifyButtonEnabled)
            {
                MessageBox.Show("已取消您做的任何修改，如果需要修改下次請按Modify按鈕。", "Notify");
                _bindingSourceVocabularyList.DataSource = _vocabularyModel.GetVocabularyList();
                _listPage.Initialize();
            }
        }
        #endregion//ListPage

        private void ChangeModel()
        {
            _bindingSourceVocabularyList.DataSource = _vocabularyModel.GetVocabularyList();
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

        #region ModifyPage
        //change vocabulary textbox
        private void ChangeModifyVocabularyTextBoxText(object sender, EventArgs e)
        {
            _modifyPage.ChangeModifyVocabularyTextBoxText(_textBoxModifyVocabulary.Text);
        }

        //change english explanation textbox
        private void ChangeModifyEnglishExplanationTextBoxText(object sender, EventArgs e)
        {
            _modifyPage.ChangeModifyEnglishExplanationTextBoxText(_textBoxModifyEnglishExplanation.Text);
        }

        //change chinese explanation textbox
        private void ChangeModifyChineseExplanationTextBoxText(object sender, EventArgs e)
        {
            _modifyPage.ChangeModifyChineseExplanationTextBoxText(_textBoxModifyChineseExplanation.Text);
        }

        //change english example textbox
        private void ChangeModifyEnglishExampleTextBoxText(object sender, EventArgs e)
        {
            _modifyPage.ChangeModifyEnglishExampleTextBoxText(_textBoxModifyEnglishExample.Text);
        }

        //change chinese example textbox
        private void ChangeModifyChineseExampleTextBoxText(object sender, EventArgs e)
        {
            _modifyPage.ChangeModifyChineseExampleTextBoxText(_textBoxModifyChineseExample.Text);
        }

        //change comment textbox
        private void ChangeModifyCommentTextBoxText(object sender, EventArgs e)
        {
            _modifyPage.ChangeModifyCommentTextBoxText(_textBoxModifyComment.Text);
        }

        //click submit button
        private void ClickModifySubmitButton(object sender, EventArgs e)
        {
            _modifyPage.ClickModifySubmitButton();
            _dataGridViewSelectVocabulary.DataSource = _vocabularyModel.GetFilteredVocabularyListByString(_textBoxVocabularyFilter.Text);
        }

        //modify update event handler
        private void UpdateModifyPage()
        {
            _textBoxModifyVocabulary.Text = _modifyPage.Vocabulary;
            _textBoxModifyChineseExplanation.Text = _modifyPage.ChineseExplanation;
            _textBoxModifyEnglishExplanation.Text = _modifyPage.EnglishExplanation;
            _textBoxModifyChineseExample.Text = _modifyPage.ChineseExample;
            _textBoxModifyEnglishExample.Text = _modifyPage.EnglishExample;
            _textBoxModifyComment.Text = _modifyPage.Comment;
            _buttonModifySubmit.Enabled = _modifyPage.IsSubmitButtonEnabled;
            _errorProvider.SetError(_buttonModifySubmit, _modifyPage.ErrorMessage);
        }

        //select vocabulary
        private void ClickSelectVocabularyDataGridViewCell(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = _dataGridViewSelectVocabulary.SelectedCells[0].RowIndex;
            if (rowIndex != -1)
            {
                DataGridViewRow dataGridViewRow = _dataGridViewSelectVocabulary.Rows[rowIndex];
                VocabularyData vocabularyData = dataGridViewRow.DataBoundItem as VocabularyData;
                _modifyPage.ClickSelectVocabularyDataGridViewCell(vocabularyData);
            }
        }

        //leave modify tabpage
        private void LeaveModifyVocabularyTabPage(object sender, EventArgs e)
        {
            if (_modifyPage.IsSubmitButtonEnabled)
            {
                MessageBox.Show("已取消您做的任何修改，如果需要修改下次請按Modify按鈕。", "Notify");
                _bindingSourceVocabularyList.DataSource = _vocabularyModel.GetVocabularyList();
                _modifyPage.Initialize();
            }
        }

        //change vocabulary filter
        private void ChangeModifyVocabularyFilterTextBoxText(object sender, EventArgs e)
        {
            _dataGridViewSelectVocabulary.DataSource = _vocabularyModel.GetFilteredVocabularyListByString(_textBoxVocabularyFilter.Text);
            _modifyPage.Initialize();
        }
        #endregion//ModifyPage


    }
}
