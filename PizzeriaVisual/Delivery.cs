internal class Delivery
{
	public Delivery() {	}

	public Delivery(int id,string name, string surname, string address, string phoneNumber)
	{
		Id = id;
		Name = name;
		Surname = surname;
		Address = address;
		PhoneNumber = phoneNumber;	
	}
    public int Id { get; set; }
    public string Name { get; set; }
	public string Surname { get; set;}
	public string Address { get; set;}
	public string PhoneNumber { get; set;}

}
