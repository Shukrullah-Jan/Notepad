using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notepad.operations;

namespace Notepad
{
    public partial class FindForm : Form
    {
        Form1 mainForm;
        EditOperation editOpertion;
        FindNextSearch qry = new FindNextSearch();

        public RichTextBox Editor { get; internal set; }

        public FindNextSearch Qry
        {
            get
            {
                return qry;
            }

            set
            {
                qry = value;
            }
        }

        public FindForm(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            btnFindNext.Enabled = false;
            editOpertion = mainForm.EditOperation;
            qry.Success = false;
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            btnFindNext.Enabled = (txtFind.Text.Length > 0) ? true : false;
            UpdateSearchQuery();
        }

        public void UpdateSearchQuery()
        {
            qry.SearchString = tbSearch.Text;
            qry.Content = Editor.Text;
            qry.Position = Editor.SelectionStart;
        }

        private void chkMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchQuery();
        }

        private void oUp_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchQuery();
        }

        private void FormFind_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            UpdateSearchQuery();
            FindNextResult result = editOpertion.FindNext(qry);
            if (result.SearchStatus)
                Editor.Select(result.SelectionStart, txtFind.Text.Length);
        }
    }

}
}
