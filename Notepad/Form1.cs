using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtbText.Focus();

            rtbText.Font = new Font("Arial", 12.0f, FontStyle.Regular);

            

        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(rtbText.Text))
            {

            }
            else
            {

                DialogResult result = MessageBox.Show("Do you want to save your file?", "Save", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    saveFileDialog1.FileName = "Untitled";
                    saveFileDialog1.Title = "Save";
                    saveFileDialog1.Filter = "Text Document (*.txt) | *.txt";

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        Stream fileStream = saveFileDialog1.OpenFile();
                        StreamWriter sw = new StreamWriter(fileStream);

                        sw.WriteLine(rtbText.Text);
                        sw.Flush();
                        sw.Close();
                    }
                    else
                    {
                        rtbText.Text = "";
                    }


                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Text Document (*.txt) | *.txt";
            openFileDialog1.Title = "Open";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                rtbText.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.FileName = "Untitled";
            saveFileDialog1.Title = "Save";
            saveFileDialog1.Filter = "Text Document (*.txt) | *.txt";
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                Stream fileStream = saveFileDialog1.OpenFile();
                StreamWriter sw = new StreamWriter(fileStream);

                sw.WriteLine(rtbText.Text);
                sw.Flush();
                sw.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.FileName = "Untitled";
            saveFileDialog1.Title = "Save As";
            saveFileDialog1.Filter = "Text Document (*.txt) | *.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                Stream fileStream = saveFileDialog1.OpenFile();
                StreamWriter sw = new StreamWriter(fileStream);

                sw.WriteLine(rtbText.Text);
                sw.Flush();
                sw.Close();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
    
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

         
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.Undo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbText.SelectAll();
        }

        private void dateAndTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            rtbText.AppendText(rtbText.SelectionCharOffset + d.ToString());
           
            
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (wordWrapToolStripMenuItem.Checked == true)
            {
                rtbText.WordWrap = false;
                wordWrapToolStripMenuItem.Checked = false;

            }
            else
            {
                rtbText.WordWrap = true;
                wordWrapToolStripMenuItem.Checked = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1 = new FontDialog();

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                rtbText.Font = fontDialog1.Font;
            }
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked)
            {
                statusStrip1.Visible = false;
                statusBarToolStripMenuItem.Checked = false;
            }
            else
            {
                statusStrip1.Visible = true;
                statusBarToolStripMenuItem.Checked = true;
            }
            
        }

        private void rtbText_TextChanged(object sender, EventArgs e)
        {
            int pos = rtbText.SelectionStart;
            int line = rtbText.GetLineFromCharIndex(pos) + 1;
            int col = pos - rtbText.GetFirstCharIndexOfCurrentLine() + 1;

            showColRows.Text = "Ln " + line + ", Col " + col;
        }

        private void textHighlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (rtbText.SelectionBackColor == Color.Yellow)
            {
                rtbText.SelectionBackColor = Color.White;
            }
            else
            {
                rtbText.SelectionBackColor = Color.Yellow;
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FindForm f = new FindForm();

            if (f.ShowDialog() == DialogResult.OK)
            {
               if (f.clickResult() == true)
                {
                    int start = rtbText.Find(f.searchedText);
                    if (start != -1)
                    {
                        rtbText.SelectionStart = start;
                        rtbText.SelectionLength = f.searchedText.Length;
                        rtbText.SelectionBackColor = Color.LightBlue;
                    }
                    else
                    {
                        MessageBox.Show("Can't find word");
                    }
                 
                }
            }


        }

        private void rtbText_MouseClick(object sender, MouseEventArgs e)
        {

            int pos = rtbText.SelectionStart;
            int line = rtbText.GetLineFromCharIndex(pos) + 1;
            int col = pos - rtbText.GetFirstCharIndexOfCurrentLine() + 1;

            showColRows.Text = "Ln " + line + ", Col " + col;
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
