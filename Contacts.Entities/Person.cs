namespace Contacts.Entities
{
    public class Person
    {
        // de vier properties die ik ook in mijn tekstbestand
        // voorzien heb, je kunt dit zien als de aparte 
        // kolommen per rij data
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // constructor om een persoon aan te maken
        public Person(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        // override om de naam van de persoon weer te geven
        // in de combobox
        public override string ToString()
        {
            // we willen de naam van de persoon weergeven
            // in de combobox, dus moeten we de naam
            // samenstellen uit de properties
            // alternatief: LastName + " " + FirstName
            return $"{LastName} {FirstName}";
        }
    }
}
