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
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {


        }
        List<char> letters1 = new List<char>() { 'Q','W','E', 'R', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Й', 'Ц', 'У', 'К', 'Е', 'Н', 'Г', 'Ш', 'Щ', 'З', 'Х', 'Ъ', 'Ф', 'Ы', 'В', 'А', 'П', 'Р', 'О', 'Л', 'Д', 'Ж', 'Э', 'Я', 'Ч', 'С', 'М', 'И', 'Т', 'Ь', 'Б', 'Ю', 'Ё', 'й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ', 'ф', 'ы', 'в', 'а', 'п', 'р', 'о', 'л', 'д', 'ж', 'э', 'я', 'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю', 'ё'};
        List<char> numbers1 = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        List<char> lan1 = new List<char>() { 'Q', 'W', 'E', 'R', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Й', 'Ц', 'У', 'К', 'Е', 'Н', 'Г', 'Ш', 'Щ', 'З', 'Х', 'Ъ', 'Ф', 'Ы', 'В', 'А', 'П', 'Р', 'О', 'Л', 'Д', 'Ж', 'Э', 'Я', 'Ч', 'С', 'М', 'И', 'Т', 'Ь', 'Б', 'Ю', 'Ё', 'й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ', 'ф', 'ы', 'в', 'а', 'п', 'р', 'о', 'л', 'д', 'ж', 'э', 'я', 'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю', 'ё', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        


        private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            string surname = textBox2.Text;
            string number = textBox3.Text;
            if (name != string.Empty && surname != string.Empty && number != string.Empty)
            {
                int s = 0;
                for (int i = 0; i<20; i++)
                {
                    try
                    {
                        if (letters1.Contains(textBox1.Text[i]) == true && letters1.Contains(textBox2.Text[i]) == true && numbers1.Contains(textBox3.Text[i]) == true)
                        {

                        }
                        else
                        {
                            s++;
                        }
                    }
                    catch { }
                }
                if (s != 0)
                    MessageBox.Show("Некорректное значение в полях!");
                else
                    dataGridView1.Rows.Add(name, surname, number);
            } 

            else
            {
                MessageBox.Show("Заполните все поля!");

            }


        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int ind = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(ind);
            }
            catch { }

        }

        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Stream mystr = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((mystr = openFileDialog1.OpenFile()) != null)
                {
                    StreamReader myread = new StreamReader(mystr);
                    string[] str;
                    int num = 0;
                    try
                    {
                        string[] str1 = myread.ReadToEnd().Split('\n');
                        num = str1.Count()-1;
                        dataGridView1.RowCount = num;
                        for (int i = 0; i < num; i++)
                        {
                            str = str1[i].Split('@');
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                                try
                                {
                                    {
                                        dataGridView1.Rows[i].Cells[j].Value = str[j];
                                    }
                                }
                                catch { }

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myread.Close();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter myWritet = new StreamWriter(myStream);
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                myWritet.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "@");

                            }
                            myWritet.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myWritet.Close();
                    }
                    myWritet.Close();
                }
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != string.Empty)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox4.Text))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                }
            }

            else
            {
                MessageBox.Show("Заполните полe!");

            }
        }





private void button4_Click(object sender, EventArgs e)
        {

            {
                try
                {
                    int ind = dataGridView1.CurrentRow.Index;
                    int ind2 = dataGridView1.CurrentCell.ColumnIndex;
                    DataGridViewTextBoxCell txtxCell = (DataGridViewTextBoxCell)dataGridView1.Rows[ind].Cells[ind2];
                    if (textBox5.Text != string.Empty)
                    {
                        if (ind2 == 2)
                        {
                            if (textBox5.Text.Length < 13)
                            {
                                int s = 0;
                                for (int i = 0; i < 20; i++)
                                {
                                    try
                                    {
                                        if (numbers1.Contains(textBox5.Text[i]) == true)
                                        {

                                        }
                                        else
                                        {
                                            s++;
                                        }
                                    }
                                    catch { }
                                }
                                if (s != 0)
                                    MessageBox.Show("Некорректное значение в поле!");

                                else
                                    txtxCell.Value = textBox5.Text;
                            }
                            else
                                MessageBox.Show("Номер должен содержать не более 12-и цифр!");
                        }
                        else
                        {
                            int s = 0;
                            for (int i = 0; i < 20; i++)
                            {
                                try
                                {
                                    if (letters1.Contains(textBox5.Text[i]) == true)
                                    {

                                    }
                                    else
                                    {
                                        s++;
                                    }
                                }
                                catch { }
                            }
                            if (s != 0)
                                MessageBox.Show("Некорректное значение в полe!");
                            else
                                txtxCell.Value = textBox5.Text;
                        }
                    }

                    else
                    {
                        MessageBox.Show("Заполните поле!");

                    }
                }
                catch { }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.AllowUserToAddRows = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
