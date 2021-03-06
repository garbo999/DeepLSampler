﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepLSampler
{
    public partial class DeepLSamplerProviderConfDialog : Form
    {
        //public static DeepLSpider deepL = null;

        public DeepLSamplerProviderConfDialog(DeepLSamplerTranslationOptions options)
        {
            Options = options;
            InitializeComponent();
            UpdateDialog(); // initialize form here!

            // attempt to open connection to DeepL if not yet established --> connection should already be opened in DeepLSamplerTranslationProvider
            DeepLSamplerTranslationProvider.OpenConnection();

            if (DeepLSamplerTranslationProvider.log != null)
            {
                DeepLSamplerTranslationProvider.log.WriteLine("DeepLSamplerProviderConfDialog instantiated", true);
            }

            // this code could go into UpdateDialog() or be deleted?
            string source_lang = "EN";
            string target_lang = "IT";

            DeepLSamplerTranslationProvider.deepL.setLanguages(source_lang, target_lang);

            textBox1.Text = "i think i hit the jackpot today";
            textBox2.Text = DeepLSamplerTranslationProvider.deepL.translateText("i think i hit the jackpot today");

        }

        public DeepLSamplerTranslationOptions Options
        {
            get;
            set;
        }

        private void UpdateDialog()
        {
            //textBox3.Text = DeepLSamplerTranslationProvider.connectionError;
            //textBox3.Text = Path.GetTempPath();
            textBox4.Text = DeepLSpider._Delay_1.ToString();
            textBox5.Text = DeepLSpider._Delay_2.ToString();
            textBox6.Text = DeepLSpider._Max_wait_count.ToString();
            textBox7.Text = DeepLSpider._DeepLURL.ToString();
            textBox8.Text = DeepLSpider._Min_target_chars.ToString();
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

        private void btn_translate_Click(object sender, EventArgs e)
        {
            textBox2.Text = DeepLSamplerTranslationProvider.deepL.translateText(textBox1.Text);
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            int numValue;
            bool parsed;

            // error checks for 3 integer values
            parsed = Int32.TryParse(textBox4.Text, out numValue);
            if (parsed) DeepLSpider._Delay_1 = numValue;

            parsed = Int32.TryParse(textBox5.Text, out numValue);
            if (parsed) DeepLSpider._Delay_2 = numValue;

            parsed = Int32.TryParse(textBox6.Text, out numValue);
            if (parsed) DeepLSpider._Max_wait_count = numValue;

            parsed = Int32.TryParse(textBox8.Text, out numValue);
            if (parsed) DeepLSpider._Min_target_chars = numValue;

            // no error checking for URL!
            DeepLSpider._DeepLURL = textBox7.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //string borrar = "checked";
            //if (!checkBox1.Checked) borrar = "NOT checked";
            //MessageBox.Show(borrar);

            // if not already checked, disable 
            if (!checkBox1.Checked)
            {
                DeepLSpider._Delays_enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;

            }
            else 
            {
                DeepLSpider._Delays_enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;

            }
        }

        private void btnShowAdvanced_Click(object sender, EventArgs e)
        {
            if (grpSpiderParams.Visible)
            {
                grpSpiderParams.Visible = false;
                btnShowAdvanced.Text = "Show advanced parameters";
            }
            else
            {
                grpSpiderParams.Visible = true;
                btnShowAdvanced.Text = "Hide advanced parameters";
            }
        }
    }
}
