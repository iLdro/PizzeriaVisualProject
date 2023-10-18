internal class Clerk
{
    public Clerk() { } // Constructeur par défaut

    public Clerk(int id, string name, string surname, string restaurant, string phoneNumber)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Restaurant = restaurant;
        PhoneNumber = phoneNumber;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Restaurant { get; set; }
    public string PhoneNumber { get; set; }
}

