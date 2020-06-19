using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private Button Button1;
        private Button Button2;
        private Label Label1;
        private Timer Timer1;
        private int[] Pics;
        private int State;
        private int Pic1_id;
        private int Pic2_id;
        private int PairRest;
        private bool Init;
        private DateTime TimeStart;

        public Form1()
        {
            Pics = new int[16];
            Load += (a, b) =>
            {
                int index = 0;
                do
                {
                    Pics[index] = index / 2;
                    checked { ++index; }
                }
                while (index <= 15);
                IEnumerator enumerator;
                try
                {
                    enumerator = Controls.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
                        if (Operators.CompareString(objectValue.GetType().Name, "PictureBox", false) == 0)
                            ((Control)objectValue).Click += new EventHandler(PicClick);
                    }
                }
                finally{}
            };
            Initialize();
        }

        private void PicClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            switch (State)
            {
                case 0:
                    Pic1_id = Conversions.ToInteger(Strings.Mid(pictureBox.Name, 11));
                    pictureBox.Image = Image.FromFile(Pics[Pic1_id] + ".jpg");
                    State = 1;
                    break;
                case 1:
                    Pic2_id = Conversions.ToInteger(Strings.Mid(pictureBox.Name, 11));
                    if (Pic1_id != Pic2_id)
                    {
                        pictureBox.Image = Image.FromFile(Pics[Pic2_id] + ".jpg");
                        State = 2;
                        Timer1.Interval = Pics[Pic1_id] != Pics[Pic2_id] ? 1000 : 100;
                        Timer1.Enabled = true;
                    }
                    break;
            }
        }

        private void Initialize()
        {
            CreateForm();
            CreateButton1();
            CreateButton2();
            CreateLabel();
            CreateTimer();
            CreatePictureBox();
        }

        private void CreateForm()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Image.FromFile("ekb.jpg");
            BackgroundImageLayout = ImageLayout.Stretch;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ClientSize = new Size(445, 509);
            Text = "Парные картинки";
            ResumeLayout(false);
        }

        private void CreatePictureBox()
        {
            var box = new PictureBox[4, 4];
            for (int i = 0; i < box.GetLength(0); i++)
                for (int j = 0; j < box.GetLength(1); j++)
                {
                    box[i,j] = new PictureBox();
                    ((ISupportInitialize)box[i, j]).BeginInit();
                    box[i, j].Location = new Point(i * 109 + 13, j * 106 + 14);
                    box[i, j].Size = new Size(100, 100);
                    box[i, j].BackgroundImage = Image.FromFile("back.jpg");
                    box[i, j].BorderStyle = BorderStyle.FixedSingle;
                    box[i, j].TabIndex = 0;
                    box[i, j].TabStop = false;
                    box[i, j].Visible = false;
                    Controls.Add(box[i, j]);
                    ((ISupportInitialize)box[i, j]).EndInit();
                }
            box[0, 0].Name = "PictureBox0";
            box[1, 0].Name = "PictureBox1";
            box[2, 0].Name = "PictureBox2";
            box[3, 0].Name = "PictureBox3";
            box[0, 1].Name = "PictureBox4";
            box[1, 1].Name = "PictureBox5";
            box[2, 1].Name = "PictureBox6";
            box[3, 1].Name = "PictureBox7";
            box[0, 2].Name = "PictureBox8";
            box[1, 2].Name = "PictureBox9";
            box[2, 2].Name = "PictureBox10";
            box[3, 2].Name = "PictureBox11";
            box[0, 3].Name = "PictureBox12";
            box[1, 3].Name = "PictureBox13";
            box[2, 3].Name = "PictureBox14";
            box[3, 3].Name = "PictureBox15";
        }

        private void CreateTimer()
        {
            Timer1 = new Timer();
            Timer1.Interval = 1000;
            Timer1.Tick += (a, b) =>
            {
                if (Init)
                {
                    IEnumerator enumerator;
                    try
                    {
                        enumerator = Controls.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
                            if (Operators.CompareString(objectValue.GetType().Name, "PictureBox", false) == 0)
                                ((PictureBox)objectValue).Image = (Image)null;
                        }
                    }
                    finally{}
                    TimeStart = DateTime.Now;
                    Init = false;
                }
                else if (Pics[Pic1_id] == Pics[Pic2_id])
                {
                    Controls["PictureBox" + Pic1_id].Visible = false;
                    Controls["PictureBox" + Pic2_id].Visible = false;
                    checked { --PairRest; }
                    if (PairRest == 0)
                    {
                        BackgroundImage = Image.FromFile("salute.jpg");
                        long num = DateAndTime.DateDiff(DateInterval.Second, TimeStart, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
                        string Expression = Conversions.ToString(num % 60L);
                        if (Strings.Len(Expression) < 2)
                            Expression = "0" + Expression;
                        Label1.Text = "Поздавляю!\r\nВремя: " + Conversions.ToString(num / 60L) + ":" + Expression;
                    }
                }
                else
                {
                    ((PictureBox)Controls["PictureBox" + Pic1_id]).Image = (Image)null;
                    ((PictureBox)Controls["PictureBox" + Pic2_id]).Image = (Image)null;
                }
                Timer1.Enabled = false;
                State = 0;
            };
        }

        private void CreateLabel()
        {
            Label1 = new Label();
            Label1.Location = new Point(135, 448);
            Label1.Size = new Size(183, 52);
            Label1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            Label1.ForeColor = Color.SaddleBrown;
            Label1.TabIndex = 2;
            Label1.BackColor = Color.Transparent;
            Label1.Text = "Екатеринбург";
            Label1.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(Label1);
        }

        private void CreateButton2()
        {
            Button2 = new Button();
            Button2.Location = new Point(331, 459);
            Button2.Size = new Size(100, 31);
            Button2.TabIndex = 1;
            Button2.Text = "Выход";
            Button2.UseVisualStyleBackColor = true;
            Button2.Click += (a, b) =>
            {
                Close();
            };
           
            Controls.Add(Button2);
        }

        private void Shuffle(ref int[] List, int min, int max)
        {
            var rnd = new Random();
            int num1 = min;
            int num2 = checked(max - 1);
            int index1 = num1;
            while (index1 <= num2)
            {
                var index2 = checked((int)Math.Round(Math.Floor(unchecked(checked(max - index1 + 1) * rnd.NextDouble() + index1))));
                int num3 = List[index2];
                List[index2] = List[index1];
                List[index1] = num3;
                checked { ++index1; }
            }
        }

        private void CreateButton1()
        {
            Button1 = new Button();
            Button1.Location = new Point(13, 459); 
            Button1.Size = new Size(100, 31);
            Button1.TabIndex = 1;
            Button1.Text = "Новая игра";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += (a, b) =>
            {
                Label1.Text = "";
                BackgroundImage = (Image)null;
                Shuffle(ref Pics, 0, 15);
                IEnumerator enumerator;
                try
                {
                    enumerator = Controls.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
                        if (Operators.CompareString(objectValue.GetType().Name, "PictureBox", false) == 0)
                        {
                            PictureBox pictureBox = (PictureBox)objectValue;
                            pictureBox.Visible = true;
                            pictureBox.Image = Image.FromFile(Pics[Conversions.ToInteger(Strings.Mid(pictureBox.Name, 11))] + ".jpg");
                        }
                    }
                }
                finally { }
                State = 2;
                PairRest = 8;
                Timer1.Interval = 3000;
                Timer1.Enabled = true;
                Init = true;
            };
            Controls.Add(Button1);
        }
    }
}
