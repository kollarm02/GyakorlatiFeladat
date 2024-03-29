using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book
{
    public partial class Form1 : Form
        
    {
        List<Book> konyvlista = new List<Book>();
        public Form1()

        {


            InitializeComponent();

            
            string[] sor = File.ReadAllLines("books.txt");
            foreach (var item in sor)
            {
                string[] adatok = item.Split(',');
                Book konyvek = new Book(adatok[0], adatok[1], adatok[2], adatok[3], adatok[4]);
                konyvlista.Add(konyvek);
            }
            int osszdb = 0;
            foreach (var item in konyvlista)
            {

                osszdb += item.darab;


            }
            label1.Text=($"Az összes darabszám: {osszdb} db");
            List<Book> legdragabb = new List<Book>(); 
            Book legdrágább = konyvlista[0];
            legdragabb.Add(legdrágább); 

            foreach (var termek in konyvlista)
            {
                if (termek.ar > legdrágább.ar)
                {
                    
                    legdrágább = termek;
                    legdragabb.Clear(); 
                    legdragabb.Add(legdrágább);
                }
                else if (termek.ar == legdrágább.ar)
                {
                    legdragabb.Add(termek);
                }
            }
            foreach (var legdrágábbTermek in legdragabb)
            {
                dataGridView1.Rows.Add(legdrágábbTermek.kategoria, legdrágábbTermek.cim,  legdrágábbTermek.ar);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedCategory = comboBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                var selectedProducts = konyvlista.Where(t => t.kategoria.Equals(selectedCategory)).ToList();
                listBox1.Items.Clear();

                foreach (var termek in selectedProducts)
                {
                    listBox1.Items.Add($"Cím: {termek.cim}, Ár: {termek.ar}, Darabszám: {termek.darab}");
                }
            }
        }
    }
   }
