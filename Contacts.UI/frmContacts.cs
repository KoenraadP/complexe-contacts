using Contacts.Bll;
using Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Contacts.UI
{
    public partial class frmContacts : Form
    {
        // globals
        // pad moet op verschillende plaatsen gebruikt worden
        // lege lijst voor objecten van type Person aanmaken
        // hoofdletter omdat het een global variabele is
        #region globals
        List<Person> LstPeople = new List<Person>();
        #endregion

        public frmContacts()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            // venster tonen om bestand te openen
            ofd.ShowDialog();
        }

        // code die uitgevoer wordt wanneer
        // het bestand gekozen werd uit de openfile dialog
        private void Ofd_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // pad van het gekozen bestand opslaan in variabele
            string fullPath = ofd.FileName;

            // LoadContacts methode uit BLL uitvoeren
            // met het gekozen bestand
            PersonBll.LoadContacts(fullPath, LstPeople);
        }
    }
}
