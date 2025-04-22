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
        // FullPath globaal omdat we het in verschillende methodes nodig hebben
        #region globals
        List<Person> LstPeople = new List<Person>();
        private string FullPath;
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
            FullPath = ofd.FileName;

            // LoadContacts methode uit BLL uitvoeren
            // met het gekozen bestand
            PersonBll.LoadContacts(FullPath, LstPeople);

            // UpdateBox methode uit Bll uitvoeren
            // om alle personen in de combobox te plaatsen
            PersonBll.UpdateBox(LstPeople, cbxContacts);

            // eerste item uit combobox 'actief' zetten
            // zodat de naam van de eerste persoon al onmiddellijk zichtbaar is
            cbxContacts.SelectedIndex = 0;
        }

        // code die uitgevoerd wordt wanneer we een
        // item uit de combobox kiezen
        // we willen de data van de persoon in de textboxes zien
        private void CbxContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // de (Person) is een soort expliciete 'cast' (vergelijkbaar met conversie)
            // om te zorgen dat we het geselecteerde item als een Person
            // kunnen gebruiken
            Person selectedPerson = (Person)cbxContacts.SelectedItem;

            // de textboxes vullen met de data van de geselecteerde persoon
            // we gebruiken de properties van de class Person
            // om de data in de textboxes te zetten
            txtId.Text = selectedPerson.Id.ToString();
            txtFirstName.Text = selectedPerson.FirstName;
            txtLastName.Text = selectedPerson.LastName;
            txtEmail.Text = selectedPerson.Email;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // nodige data voor UpdatePerson methode in variabelen steken
            Person selectedPerson = (Person)cbxContacts.SelectedItem;
            int index = cbxContacts.SelectedIndex;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;

            // UpdatePerson uit Bll uitvoeren
            PersonBll.UpdatePerson(selectedPerson, LstPeople, firstName, 
                                    lastName, email, index);

            // UpdateBox uit Bll uitvoeren
            PersonBll.UpdateBox(LstPeople, cbxContacts);

            // de combobox opnieuw op de juiste index zetten
            cbxContacts.SelectedIndex = index;

            // SaveContacts methode uitvoeren om ook de file te updaten
            PersonBll.SaveContacts(FullPath, LstPeople);
        }
    }
}
