using System;
using System.Windows.Forms;

namespace NewApiBrowser
{
    public partial class FormInputDialog : Form
    {
        public FormInputDialog(string title, string prompt)
        {
            InitializeComponent();
            this.Text = title;
            this.InputPrompt = prompt;
        }

        public string InputText
        {
            get { return textBoxInput.Text; }
            set { textBoxInput.Text = value; }
        }

        public string InputPrompt
        {
            get { return labelInputPrompt.Text; }
            set { labelInputPrompt.Text = value; }
        }
    }
}
