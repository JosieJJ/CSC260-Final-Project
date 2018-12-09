using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notebook__Final_
{
    public partial class Notebook : Form
    {
        private string path;

        public Notebook()
        {
            InitializeComponent();
        }


        private void exutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("For assistance, contact me at my email. \r\n Notebook 2018.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MainRichTextBox.Text.Length > 0)
            {
                undoToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;

                boldToolStripMenuItem.Enabled = true;
                italicToolStripMenuItem.Enabled = true;
                underlineToolStripMenuItem.Enabled = true;
                strikeThroughToolStripMenuItem.Enabled = true;
                normalToolStripMenuItem.Enabled = true;
            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;

                boldToolStripMenuItem.Enabled = false;
                italicToolStripMenuItem.Enabled = false;
                underlineToolStripMenuItem.Enabled = false;
                strikeThroughToolStripMenuItem.Enabled = false;
                normalToolStripMenuItem.Enabled = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Text = "";
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Redo();
            undoToolStripMenuItem.Enabled = true;
            redoToolStripMenuItem.Enabled = false;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Text = MainRichTextBox.Text + DateTime.Now;
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Underline);
        }

        private void strikeThroughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Strikeout);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Regular);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        path = ofd.FileName;
                        Task<string> text = sr.ReadToEndAsync();
                        MainRichTextBox.Text = text.Result;
                    }
                }
            }
        }

    }
}
