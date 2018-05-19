using System;
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
        //public DeepLSamplerProviderConfDialog()
        public DeepLSamplerProviderConfDialog(DeepLSamplerTranslationOptions options)

        {
            Options = options;
            InitializeComponent();
            UpdateDialog();

        }

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
    }
}
