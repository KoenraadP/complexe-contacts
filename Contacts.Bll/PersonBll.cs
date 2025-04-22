using System;
using Contacts.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Contacts.Bll
{
    // public omdat ik deze class wil
    // gebruiken in andere projecten
    // static omdat ik gewoon de methodes
    // eruit wil gebruiken
    public static class PersonBll
    {
        // methode om rijen uit een tekstbestand
        // te halen, deze om te zetten naar personen
        // en deze personen aan een list toe te voegen
        // fullPath is het volledige pad naar het bestand
        // bijvoorbeeld: C:\contacten\creo.txt
        // de list is de lijst waarin de personen
        // opgeslagen worden en gebruikt worden in de form
        public static void LoadContacts(string fullPath, List<Person> lstPeople)
        {
            // list opnieuw leeg maken in geval
            // het bestand opnieuw ingeladen wordt
            lstPeople.Clear();

            // array voor string elementen aanmaken
            // en de data uit mijn tekst bestand
            // hierin opslaan, rij per rij
            string[] lines = File.ReadAllLines(fullPath);

            // testen of de data correct in de array zit
            // door te controleren wat er momenteel op de eerste
            // plaats in de array zit
            // dit zou MOETEN alle data van de eerste persoon zijn
            // Debug.WriteLine(lines[0]);

            // alle lijntjes in de array
            // omzetten naar Person objects
            foreach (string line in lines)
            {
                // iedere lijn bevat het ; teken om de aparte
                // properties/kolommen te scheiden van elkaar
                // dus moeten we deze lijn splitsen
                string[] personData = line.Split(';');

                // testen of de data correct in de array zit
                // Debug.WriteLine(personData[1]);

                // nieuwe Person aanmaken met de data
                // uit de array
                Person p = new Person(Convert.ToInt32(personData[0]),
                    personData[1], personData[2], personData[3]);

                // de nieuwe persoon toevoegen aan de lijst
                lstPeople.Add(p);
            }
        }

        // methode om combobox te vullen met nieuwe data
        // we zullen hiervoor de list gebruiken
        // ComboBox komt uit System.Windows.Forms --> eventueel zelf reference leggen (bij Assemblies)
        // en ook bovenaan vermelden bij de using statements
        public static void UpdateBox(List<Person> lstPeople, ComboBox comboBox)
        {
            // eerst inhoud combobox 'resetten'
            comboBox.Items.Clear();

            // alle aparte personen uit de list
            // in de combobox plaatsen
            foreach (Person p in lstPeople)
            {
                comboBox.Items.Add(p);
            }
        }
        
        // methode om de gegevens van een persoon
        // aan te passen
        // we willen de aangepaste persoon ook in de list
        // opslaan daarom geven we de list ook mee als parameter
        // index = op welke plaats in de list staat de persoon
        public static void UpdatePerson(Person person, 
            List<Person> lstPeople, string firstName, 
            string lastName, string email, int index)
        {
            // waarden van person aanpassen
            person.FirstName = firstName;
            person.LastName = lastName;
            person.Email = email;

            // persoon in list aanpassen
            lstPeople[index] = person;
        }

        // methode om de list opnieuw in het tekstbestand op te slaan
        // fullpath --> directory en bestandsdnaam om in op te slaan
        public static void SaveContacts(string fullPath, List<Person> lstPeople)
        {
            // string array aanmaken
            // om de data in op te slaan
            // omdat we uiteindelijk weer via een array alles naar het tekstbestand schrijven
            // de array moet even 'groot' zijn als de list
            string[] lines = new string[lstPeople.Count];

            // alle personen in de list
            // omzetten naar een string van type:
            // id;firstName;lastName;email
            for (int i = 0; i < lstPeople.Count; i++)
            {
                Person currentPerson = lstPeople[i];
                // alternatief: currentPerson.Id + ";" + currentPerson.FirstName + ";" ...
                lines[i] = $"{currentPerson.Id};{currentPerson.FirstName};" +
                    $"{currentPerson.LastName};{currentPerson.Email}";
            }

            // de array met strings opslaan in het tekstbestand
            File.WriteAllLines(fullPath, lines);
        }
    }
}
