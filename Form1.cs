using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentGrades
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			dgv1.ColumnCount = 11;

			//statistics are read only
			textBox6.ReadOnly = true;
			textBox7.ReadOnly = true;
			textBox8.ReadOnly = true;
			textBox9.ReadOnly = true;
			textBox10.ReadOnly = true;

			//sets the name and header of all the columns in the datagridview
			dgv1.Columns[0].Name = "Col 1";
			dgv1.Columns[0].HeaderText = "Name";
			dgv1.Columns[1].Name = "Col 2";
			dgv1.Columns[1].HeaderText = "Subject 1";
			dgv1.Columns[2].Name = "Col 3";
			dgv1.Columns[2].HeaderText = "Subject 2";
			dgv1.Columns[3].Name = "Col 4";
			dgv1.Columns[3].HeaderText = "Subject 3";
			dgv1.Columns[4].Name = "Col 5";
			dgv1.Columns[4].HeaderText = "Subject 4";
			dgv1.Columns[5].Name = "Col 6";
			dgv1.Columns[5].HeaderText = "Subject 5";
			dgv1.Columns[6].Name = "Col 7";
			dgv1.Columns[6].HeaderText = "Average";
			dgv1.Columns[7].Name = "Col 8";
			dgv1.Columns[7].HeaderText = "Letter Grade";
			dgv1.Columns[8].Name = "Col 9";
			dgv1.Columns[8].HeaderText = "Min";
			dgv1.Columns[9].Name = "Col 10";
			dgv1.Columns[9].HeaderText = "Med";
			dgv1.Columns[10].Name = "Col 11";
			dgv1.Columns[10].HeaderText = "Max";
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

		//checks if the student is already stored in the datagridview
		private bool findDuplicates()
		{
			DataGridViewRowCollection allrows = dgv1.Rows;

			foreach(DataGridViewRow rw in allrows)
			{
				//Cells[0] is first column in dgv, which is the name
				if(rw.Cells[0].Value != null)
				{
					string name = rw.Cells[0].Value.ToString();
					string studentName = textBox11.Text;

					if(name == studentName)
					{
						MessageBox.Show(name + " is already in use.");
						return true;
					}
				}
			}
			return false;
		}

		//this code executes when the compute button is clicked
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

		//stores info into the datagridview
		private void button2_Click(object sender, EventArgs e)
		{
			//if name is not used
			if(findDuplicates() == false)
			{
				//string array to hold stats
				string[] row = new string[11];

				//populating the array
				row[0] = textBox11.Text;
				row[1] = textBox1.Text;
				row[2] = textBox2.Text;
				row[3] = textBox3.Text;
				row[4] = textBox4.Text;
				row[5] = textBox5.Text;
				row[6] = textBox6.Text;
				row[7] = textBox7.Text;
				row[8] = textBox8.Text;
				row[9] = textBox9.Text;
				row[10] = textBox10.Text;

				//pushing the row to the datagridview Row
				dgv1.Rows.Add(row);
			}
		}
	}
}
