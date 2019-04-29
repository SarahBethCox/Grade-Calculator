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
			textBox8.ReadOnly = true;
			textBox9.ReadOnly = true;
			textBox10.ReadOnly = true;

		}

		//calculates letter grade based on average
		public string findGrade(decimal avg)
		{
			string letterGrade = "";

			if (avg >= 90)
			{
				letterGrade = "A";
			}
			else if (avg >= 80)
			{
				letterGrade = "B";
			}
			else if (avg >= 70)
			{
				letterGrade = "C";
			}
			else if (avg >= 60)
			{
				letterGrade = "D";
			}
			else
			{
				letterGrade = "F";
			}

			return letterGrade;
		}

		//determines if the given grade is valid (0-100)
		private Boolean isValid(decimal[] scores)
		{
			Boolean status = true;
			for (int i = 0; i < scores.Length; i++)
			{
				if (scores[i] < 0 || scores[i] > 100)
				{
					MessageBox.Show(scores[i] + " is invalid");
					status = false;
				}
			}
			return status;
		}

		//calucaltes average of an array
		private decimal computeAverage(decimal[] scores)
		{
			decimal avg = 0;
			decimal sum = 0;

			//adds all the scores together
			for (int i = 0; i < 5; i++)
			{
				sum = sum + scores[i];
			}

			avg = sum / scores.Length;
			return avg;
		}

		//finds the minimum of an array
		private decimal findMin(decimal[] scores)
		{
			decimal min = scores[0];

			for (int i = 1; i < scores.Length; i++)
			{
				if (min > scores[i])
					min = scores[i];
			}

			return min;
		}

		//finds the maximum of an array
		private decimal findMax(decimal[] scores)
		{
			decimal max = scores[0];

			for (int i = 1; i < scores.Length; i++)
			{
				if (max < scores[i])
					max = scores[i];
			}

			return max;
		}

		//finds the median of an array
		private decimal findMed(decimal[] scores)
		{
			//do later
			decimal med = 0;
			return med;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//an array to hold all the scores
			decimal[] scores = new decimal[5];
			Boolean flg = true;

			//populating the array
			scores[0] = Decimal.Parse(textBox1.Text);
			scores[1] = Decimal.Parse(textBox2.Text);
			scores[2] = Decimal.Parse(textBox3.Text);
			scores[3] = Decimal.Parse(textBox4.Text);
			scores[4] = Decimal.Parse(textBox5.Text);

			flg = isValid(scores);

			if (flg == true)
			{
				decimal avg = computeAverage(scores);
				textBox7.Text = avg.ToString();

				string grade = findGrade(avg);
				textBox6.Text = grade;

				decimal min = findMin(scores);
				textBox8.Text = min.ToString();

				decimal med = findMed(scores);
				textBox9.Text = med.ToString();

				decimal max = findMax(scores);
				textBox10.Text = max.ToString();
			}
			else
			{
				MessageBox.Show("Error");
			}
		}
	}
}
