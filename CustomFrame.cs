using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Prog_lab1_2
{
    internal class CustomFrame
    {
        public string symbol { get; set; }
        public CustomFrame() {}

        public void Print(System.Windows.Forms.TextBox textBox, System.Windows.Forms.TextBox textBoxResult)
        {
            int resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Width;
            textBoxResult.Text = "";
            string firstAndLastLine = "";
            int[] linesLength = new int[textBox.Lines.Length];
            string thisLine = "";
            List<string> allLinesResult = new List<string>();

            for (int i = 0; i < textBox.Lines.Length; ++i)
            {
                linesLength[i] = textBox.Lines[i].Length;
            }
            for (int i = 0; i < linesLength.Max() + 2; ++i)
            {
                firstAndLastLine += symbol;
            }
            allLinesResult.Add(firstAndLastLine);     
            
            if ((linesLength.Max() + 2) * (220 / 27)  < resolution - 30)
            {
                while ((linesLength.Max() + 2) * (220 / 27) < textBoxResult.Width - 20 && textBoxResult.Width > 240)
                {
                    textBox.Width += -1;
                    textBoxResult.Width = textBoxResult.Width + -1;
                }
                while ((linesLength.Max() + 2) * (220 / 27) > textBoxResult.Width - 20)
                {
                    textBox.Width += 1;
                    textBoxResult.Width = textBoxResult.Width + 1;
                }
                foreach (var line in textBox.Lines)
                {
                    thisLine = symbol + line;
                    for (int i = 0; i < linesLength.Max() - line.Length; i++)
                    {
                        thisLine += " ";
                    }
                    thisLine += symbol;
                    allLinesResult.Add(thisLine);
                }
                allLinesResult.Add(firstAndLastLine);

                foreach (var line in allLinesResult)
                {
                    textBoxResult.Text += line;
                    textBoxResult.Text += Environment.NewLine;
                }
            }
            else
            {
                MessageBox.Show("Вы ввели слишком длинную строку");
            }
        }
    }
}