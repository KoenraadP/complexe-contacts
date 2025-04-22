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
            Debug.WriteLine(lines[0]);
        }
    }
}
