using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment01
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			//average and grade are read only
			textBox6.ReadOnly = true;
			textBox7.ReadOnly = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//an array to hold all the scores
			decimal[] scores = new decimal[5];

			//populating the array
			scores[0] = Decimal.Parse(textBox1.Text);
			scores[1] = Decimal.Parse(textBox2.Text);
			scores[2] = Decimal.Parse(textBox3.Text);
			scores[3] = Decimal.Parse(textBox4.Text);
			scores[4] = Decimal.Parse(textBox5.Text);

			for(int j = 0; j < 5; j++)
			{
				//checks if the subject score is valid
				if(scores[j] < 0 || scores[j] > 100)
				{
					//Prompts the user to enter in a valid score
					if (scores[j] == scores[0])
						MessageBox.Show("Please enter a valid score for subject 1.");
					if (scores[j] == scores[1])
						MessageBox.Show("Please enter a valid score for subject 2.");
					if (scores[j] == scores[2])
						MessageBox.Show("Please enter a valid score for subject 3.");
					if (scores[j] == scores[3])
						MessageBox.Show("Please enter a valid score for subject 4.");
					if (scores[j] == scores[4])
						MessageBox.Show("Please enter a valid score for subject 5.");
				}

				else
				{
					decimal avg = 0;
					decimal sum = 0;

					if(scores[j] <= 100)
					{
						//adds all the scores together
						for(int i = 0; i < 5; i++)
						{
							sum = sum + scores[i];
						}

						//calculates average, populates textbox
						avg = sum / scores.Length;
						textBox6.Text = avg.ToString();

						string letterGrade;

						//calculates the letter grade
						if(avg >= 90)
						{
							letterGrade = "A";
							textBox7.Text = letterGrade;
						}
						else if(avg >= 80)
						{
							letterGrade = "B";
							textBox7.Text = letterGrade;
						}
						else if(avg >= 70)
						{
							letterGrade = "C";
							textBox7.Text = letterGrade;
						}
						else if(avg >= 60)
						{
							letterGrade = "D";
							textBox7.Text = letterGrade;
						}
						else
						{
							letterGrade = "F";
							textBox7.Text = letterGrade;
						}
					}
				}
			}

		}
	}
}
