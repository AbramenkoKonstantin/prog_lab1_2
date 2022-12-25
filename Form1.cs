using System;
using System.IO;
using System.Windows.Forms;

namespace Prog_lab1_2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Start(object sender, EventArgs e)
        {
            try
            {
                if (btnMultipclitaion.Checked == true)
                {
                    FrameMultiplication frameMultiplication = new FrameMultiplication();
                    frameMultiplication.Print(textBox, textBoxResult);
                }
                else if (btnEqual.Checked == true)
                {
                    FrameEqual frameEqual = new FrameEqual();
                    frameEqual.Print(textBox, textBoxResult);
                }
                else if (btnPlus.Checked == true)
                {
                    FramePlus framePlus = new FramePlus();
                    framePlus.Print(textBox, textBoxResult);
                }
                this.Width = textBoxResult.Width + 30;
            }
            catch
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    MessageBox.Show("Поле для ввода пустое");
                }
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                if (!fileName.Contains(".txt"))
                {
                    MessageBox.Show("Выбран файл неправильного формата");
                    return;
                }
                string text = File.ReadAllText(fileName);
                textBox.Text = text;
                textBox.SelectionStart = textBox.Text.Length;
                textBox.ScrollToCaret();
                saveFileBtn.Enabled = true;
            }
        }

        private void SafeFile(object sender, EventArgs e)
        {
            string fileName = "";
            if (textBox.Text.Length == 0)
            {
                if (fileName == String.Empty)
                {
                    MessageBox.Show("Файл не открыт");
                    return;
                }
                else
                {
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить пустой файл", "Предупреждение", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        fileName = openFileDialog.FileName;
                        File.WriteAllText(fileName, textBox.Text);
                        MessageBox.Show($"Файл {Path.GetFileName(fileName)} сохранен");
                    }
                    else return;
                }
            }
            else if (openFileDialog.FileName == String.Empty)
            {
                MessageBox.Show("Файл не открыт");
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Вы хотите сохранить текст с рамкой?", "Сохранить", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    fileName = openFileDialog.FileName;
                    File.WriteAllText(fileName, textBoxResult.Text);
                    MessageBox.Show($"Файл {Path.GetFileName(fileName)} сохранен с рамкой");
                }
                else if (dialogResult == DialogResult.No)
                {
                    fileName = openFileDialog.FileName;
                    File.WriteAllText(fileName, textBox.Text);
                    MessageBox.Show($"Файл {Path.GetFileName(fileName)} сохранен без рамки");
                }
                
            }
        }
    }
}
