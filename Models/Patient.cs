
public class Patient
{
    public int Id { get; set; }
    public string Document { get; set; } = null!;
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }




    public Patient(int id, string? document, string? name, int age, string? phone, string? email)
    {
        Id = id;
        Document = document ?? throw new ArgumentNullException(nameof(document));
        Name = name;
        Age = age;
        Phone = phone;
        Email = email;
    }
    

    

}
