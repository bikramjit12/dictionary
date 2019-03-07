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

namespace dictionary
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> DictionaryWords = new Dictionary<string,
string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //make a counter that shows how many words are loaded (really just something to look at)
            int count = 0;
            //a great way of loading each line of a file into your program
            foreach (string line in File.ReadLines(@"C:\Users\vicky\source\repos\dictionary\dictionary\bin\Debug\dict1.txt"))
            {
                //create the counter, show it on the top of the form
                count++;
                this.Text = count.ToString();
                //if the dictionary doesn't have the word then load it. Otherwise it crashes when it finds a conflict with an existing word
                if (DictionaryWords.ContainsKey(line) == false)
                {
                    //add key / value with both the same word
                    DictionaryWords.Add(line, line);
                }
            } //shows when the words are loaded
            this.Text = "Words Loaded";
        }
        private void btnSearch_Click(object sender, EventArgs e)
        { 
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            //input the search word
            string SearchWord = txtInputWord.Text;
            //if the word is in the dictionary
            if (DictionaryWords.ContainsKey(SearchWord))
            {
                this.Text = SearchWord + " is found";
                lbxWords.Items.Add(SearchWord + " is found");
            }
            else
            { //the word isn't in the dictionary
                this.Text = SearchWord + " does not exist";
                lbxWords.Items.Add(SearchWord + " does not exist");

            }
        }
    }
}