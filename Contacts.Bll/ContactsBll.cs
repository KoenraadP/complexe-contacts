using Contacts.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Contacts.Bll
{
    public static class ContactsBll
    {
        public static void LoadContacts(string fullPath, List<Person> lstPeople)
        {            
            string[] lines = File.ReadAllLines(fullPath);
            Debug.WriteLine(lines[0]);
        }
    }
}
