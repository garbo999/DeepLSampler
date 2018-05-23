﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepLSampler
{
    public partial class DeepLSamplerProviderConfDialog : Form
    {
        public static DeepLSpider deepL;
        //public static DeepLSpider deepL = new DeepLSpider();

        //public DeepLSamplerProviderConfDialog()
        public DeepLSamplerProviderConfDialog(DeepLSamplerTranslationOptions options)
        {
            Options = options;
            InitializeComponent();
            UpdateDialog();

            // attempt to open connection to DeepL
            try
            {
                deepL = new DeepLSpider();
            }
            catch (Exception e)
            {
                //throw;
                textBox3.Text = e.Message;
                return;
            }

            string source_lang = "EN";
            string target_lang = "IT";

            deepL.setLanguages(source_lang, target_lang);
            //deepL.setLanguages("FR", "PL");
            //deepL.setLanguages("IT", "ES");
            //deepL.setLanguages("EN", "DE");

            //Console.WriteLine("translation is: " + deepL.translateText("i think i hit the jackpot today"));
            //Console.WriteLine("translation is: " + deepL.translateText("i have to go pick up my kids at school right now"));
            //Console.WriteLine("translation is: " + deepL.translateText("i just got back from picking up my kids at school and now i have to go to the optometrist"));

            textBox1.Text = "i think i hit the jackpot today";
            textBox2.Text = deepL.translateText("i think i hit the jackpot today");


        }

        //public DeepLSpider DeepL { get; set; }

        public DeepLSamplerTranslationOptions Options
        {
            get;
            set;
        }

        private void UpdateDialog()
        {
            //txt_ListFile.Text = Options.ListFileName;
            //combo_Delimiter.Text = Options.Delimiter;
        }

        private void DeepLSamplerProviderConfDialog_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = deepL.translateText(textBox1.Text);
        }
    }
}
