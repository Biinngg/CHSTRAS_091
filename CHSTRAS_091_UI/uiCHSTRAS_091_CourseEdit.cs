using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CHSTRAS_091_BT;
using System.IO;

namespace CHSTRAS_091_UI
{
    public partial class uiCHSTRAS_091_CourseEdit : SHF_UI.uiSHF_CourseBase
    {
        private PictureBox[] pictureBox;
        private TextBox[] textBox;
        private Button[] button;
        private CheckBox[] checkBox;
        private btCHSTRAS_091_CourseEdit edit;
        private btCHSTRAS_091_CourseEdit.Content[] content;
        private btCHSTRAS_091_File file;

        public uiCHSTRAS_091_CourseEdit()
        {
            InitializeComponent();
            file = new btCHSTRAS_091_File();
            edit = new btCHSTRAS_091_CourseEdit();
            checkBox = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4,
                checkBox5, checkBox6, checkBox7, checkBox8};
            pictureBox = new PictureBox[]{pictureBox1, pictureBox2, pictureBox3,
                pictureBox4, pictureBox8, pictureBox7, pictureBox6, pictureBox5};
            textBox = new TextBox[]{textBox1, textBox2, textBox3, textBox25, textBox6,
                textBox5, textBox4, textBox28, textBox9, textBox8, textBox7, textBox29,
                textBox12, textBox11, textBox10, textBox30, textBox24, textBox23, textBox22,
                textBox31, textBox21, textBox20, textBox19, textBox32, textBox18, textBox17,
                textBox16, textBox33, textBox15, textBox14, textBox13, textBox34};
            button = new Button[] { button1, button2, button3, button4,
                button8, button7, button6, button5 };
        }

        private void updateCheckedList()
        {
            int index = comboBox5.SelectedIndex;
            content = edit.getCheckedListItems(5, index);
            listBox1.Items.Clear();
            foreach (btCHSTRAS_091_CourseEdit.Content cont in content)
            {
                listBox1.Items.Add(cont.title);
            }
            updateContentType();
        }

        private void updateContentType()
        {
            clean();
            int length = content[0].image.Length;
            for (int i = 0; i < 8; i++)
            {
                if (i < length)
                {
                    pictureBox[i].Enabled = true;
                    button[i].Enabled = true;
                    for (int n = 0; n < 4; n++)
                    {
                        textBox[4 * i + n].Enabled = true;
                    }
                }
                else
                {
                    pictureBox[i].Enabled = false;
                    button[i].Enabled = false;
                    for (int n = 0; n < 4; n++)
                    {
                        textBox[4 * i + n].Enabled = false;
                    }
                }
            }
        }

        private void clean()
        {
            textBox26.Text = null;
            textBox27.Text = null;
            for (int i = 0; i < 8; i++)
            {
                checkBox[i].Checked = false;
                pictureBox[i].Image = null;
            }
            for (int i = 0; i < 32; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        textBox[i].Text = "图片地址...";
                        break;
                    case 1:
                        textBox[i].Text = "显示名称";
                        break;
                    case 2:
                        textBox[i].Text = "正确名称或序号";
                        break;
                    case 3:
                        textBox[i].Text = "待选答案";
                        break;
                }
            }
        }

        private void updateContent(int index)
        {
            clean();
            btCHSTRAS_091_CourseEdit.Content cont = content[index];
            textBox26.Text = cont.title;
            textBox27.Text = "" + cont.score;
            for (int i = 0; i < cont.image.Length; i++)
            {
                pictureBox[i].Image = file.getImage(cont.image[i]);
                textBox[4 * i].Text = cont.image[i];
                if (cont.mark != null)
                    checkBox[i].Checked = cont.mark[i];
                if (cont.disName != null)
                    textBox[4 * i + 1].Text = cont.disName[i];
                if (cont.corName != null)
                    textBox[4 * i + 2].Text = cont.corName[i];
                if (cont.optName != null)
                    textBox[4 * i + 3].Text = cont.optName[i];
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(edit.getComboItems(1, index));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox2.SelectedIndex;
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(edit.getComboItems(2, index));
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox3.SelectedIndex;
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(edit.getComboItems(3, index));
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox4.SelectedIndex;
            comboBox5.Items.Clear();
            comboBox5.Items.AddRange(edit.getComboItems(4, index));
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex > -1)
            {
                updateCheckedList();
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            edit.setType(comboBox6.SelectedIndex);
            if (comboBox5.SelectedIndex > -1)
            {
                updateCheckedList();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateContent(listBox1.SelectedIndex);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fName = openFileDialog1.FileName;
                String name = openFileDialog1.SafeFileName;
                File.Copy(fName, "..\\..\\..\\SHFDB\\Image\\" + name);
                textBox1.Text = name;
                pictureBox[0].Image = file.getImage(name);
            }
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fName = openFileDialog1.FileName;
                String name = openFileDialog1.SafeFileName;
                File.Copy(fName, "..\\..\\..\\SHFDB\\Image\\" + name);
                textBox6.Text = name;
                pictureBox[1].Image = file.getImage(name);
            }
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fName = openFileDialog1.FileName;
                String name = openFileDialog1.SafeFileName;
                File.Copy(fName, "..\\..\\..\\SHFDB\\Image\\" + name);
                textBox9.Text = name;
                pictureBox[2].Image = file.getImage(name);
            }
        }

        private void textBox12_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fName = openFileDialog1.FileName;
                String name = openFileDialog1.SafeFileName;
                File.Copy(fName, "..\\..\\..\\SHFDB\\Image\\" + name);
                textBox12.Text = name;
                pictureBox[3].Image = file.getImage(name);
            }
        }

        private void textBox24_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fName = openFileDialog1.FileName;
                String name = openFileDialog1.SafeFileName;
                File.Copy(fName, "..\\..\\..\\SHFDB\\Image\\" + name);
                textBox24.Text = name;
                pictureBox[4].Image = file.getImage(name);
            }
        }

        private void textBox21_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fName = openFileDialog1.FileName;
                String name = openFileDialog1.SafeFileName;
                File.Copy(fName, "..\\..\\..\\SHFDB\\Image\\" + name);
                textBox21.Text = name;
                pictureBox[5].Image = file.getImage(name);
            }
        }

        private void textBox18_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fName = openFileDialog1.FileName;
                String name = openFileDialog1.SafeFileName;
                File.Copy(fName, "..\\..\\..\\SHFDB\\Image\\" + name);
                textBox18.Text = name;
                pictureBox[6].Image = file.getImage(name);
            }
        }

        private void textBox15_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fName = openFileDialog1.FileName;
                String name = openFileDialog1.SafeFileName;
                File.Copy(fName, "..\\..\\..\\SHFDB\\Image\\" + name);
                textBox15.Text = name;
                pictureBox[7].Image = file.getImage(name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox6_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox9_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox12_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox24_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox21_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox18_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox15_Click(sender, e);
        }
    }
}
