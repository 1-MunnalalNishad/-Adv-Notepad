using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        private object printPreviewDialog1;
        private object printDocument1;

        public Form1()
        {
            InitializeComponent();
        }

        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void OnOpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
            this.Text = op.FileName;
        }

        private void OnSaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Text Document(*.txt)|*.txt|all files(*.*)";
            if (sv.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
            this.Text = sv.FileName;

        }

        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnCutToolStripMenuItemClick(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void OnCopyToolStripMenuItemClick(object sender, EventArgs e)
        {
            richTextBox1.Copy();

        }

        private void OnPasteToolStripMenuItemClick(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void OnUndoToolStripMenuItemClick(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void OnRedoToolStripMenuItemClick(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void OnFontToolStripMenuItem1Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richTextBox1.SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = fd.Font;
        }

        private void OnBackgroundColorToolStripMenuItemClick(object sender, EventArgs e)
        {
            ColorDialog cr = new ColorDialog();
            if (cr.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = cr.Color;
            }
        }

        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            MessageBox.Show("ver 1.0.0\n Created by Er Mnnalal nishad");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.SelectAll();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += Convert.ToString(DateTime.Now);
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Text = "Cols" + richTextBox1.Text.Length;
        }

        private void backgroundColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog cr = new ColorDialog();
            if (cr.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = cr.Color;
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == false)

            {

                wordWrapToolStripMenuItem.Checked = true;

                richTextBox1.WordWrap = true;

            }

            else

            {

                wordWrapToolStripMenuItem.Checked = false;

                richTextBox1.WordWrap = false;

            }
        }

        private void addBulletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //putting bullets into richtextbox        

            try

            {

                richTextBox1.BulletIndent = 10;

                richTextBox1.SelectionBullet = true;

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message.ToString(), "Error");

            }
        }

        private void removeBulletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //removing bullets        

            try

            {

                richTextBox1.SelectionBullet = false;

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message.ToString(), "Error");

            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog2.Document = printDocument2;

            printPreviewDialog2.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument2;

            if (printDialog1.ShowDialog() == DialogResult.OK)

            {

                printDocument2.Print();
            }
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document = printDocument2;

            pageSetupDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)

        {

            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 100, 100);

        }
    }
}



