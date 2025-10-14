public class Doctor
{
    public int Id { get; set; }
    public string Document { get; set; } = null!;
    public string? Name { get; set; }
    public string? Specialty { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public Doctor(int id, string? document, string? name, string? specialty, string? phone, string? email)
    {
        Id = id;
        Document = document ?? throw new ArgumentNullException(nameof(document));
        Name = name;
        Specialty = specialty;
        Phone = phone;
        Email = email;
    }

    
}