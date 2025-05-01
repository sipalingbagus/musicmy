using System;
using System.Windows.Forms;

namespace MyMusicApp
{
    public partial class CRUDForm : Form
    {
        public CRUDForm()
        {
            InitializeComponent();
        }

        private void CRUDForm_Load(object sender, EventArgs e)
        {
            // Optional: Initialize default UI or load data here
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Create operation triggered.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Read operation triggered.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update operation triggered.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete operation triggered.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
