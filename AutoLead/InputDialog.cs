using System;
using System.Windows.Forms;

namespace AutoLeadX
{
    public partial class InputDialog : Form
    {
        string input;

        public InputDialog()
        {
            InitializeComponent();
        }

        public void setName(string name)
        {
            this.lbName.Text = name;
        }

        public string getInput()
        {
            return this.tbInput.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            input = this.tbInput.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public static string showInputDialog(string description)
        {
            InputDialog inputDlg = new InputDialog();
            inputDlg.setName(description);
            if (DialogResult.OK == inputDlg.ShowDialog())
            {
                return inputDlg.getInput();
            }
            else
                return null;
        }
    }
}
