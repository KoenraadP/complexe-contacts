using Contacts.Bll;
using Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Contacts.UI
{
    public partial class frmContacts : Form
    {

        #region globals
        string FullPath;
        List<Person> LstPeople = new List<Person>();
        #endregion

        public frmContacts()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();
        }

        private void Ofd_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FullPath = ofd.FileName;
            ContactsBll.LoadContacts(FullPath, LstPeople);
        }
    }
}
