using System;
using Contacts.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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
    }
}
