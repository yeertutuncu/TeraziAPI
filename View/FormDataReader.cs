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

namespace MESAPI.View
{
    public partial class FormDataReader : Form
    {
        public FormDataReader()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            List<string> liste = new List<string>();
            List<string> decimalListe = new List<string>();

            try
            {
                string[] okunanArr = File.ReadAllLines(@"okunanVeri.txt");
                IEnumerable<string> okunanListe = (from d in okunanArr select d).Distinct();

                foreach (string line in okunanListe)
                {
                    if (line.Contains("US,NT,-"))
                        continue;

                    if (line.Contains("US,NT") && line.Split(',').Length == 4)
                    {
                        if (!string.IsNullOrEmpty(line.Split(',')[2]))
                        {
                            if (line.Split(',')[2].Split('.').Length > 2)
                                continue;

                            decimal d = Convert.ToDecimal(line.Split(',')[2].Replace("+000", "").Replace("+00", "").Replace("+0", "").Replace(".", ","));
                            liste.Add(d.ToString());

                            if (d > 0)
                            {
                                if(!decimalListe.Contains(d.ToString()))
                                decimalListe.Add(d.ToString());
                            }

                            //dataGridView1.Rows.Add(new[] { line.Split(',')[2] });
                        }
                    }
                }
                IEnumerable<string> yeniListe = (from d in liste select d).Distinct();
                IEnumerable<string> yeniDecimalListe = (from d in decimalListe select d).Distinct();

                foreach (string item in yeniDecimalListe)
                {
                    dataGridView1.Rows.Add(new[] { item });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
        }
    }
}
