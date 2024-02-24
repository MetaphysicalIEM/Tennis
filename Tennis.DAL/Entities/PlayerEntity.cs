namespace Tennis.DAL.Entities;
public class PlayerEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ShortName { get; set; }
    public int Sex { get; set; }
    public string CountryCode { get; set; }
    public int Rank { get; set; }
    public int Points { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public int Age { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
}