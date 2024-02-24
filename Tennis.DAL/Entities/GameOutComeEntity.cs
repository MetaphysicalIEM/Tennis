namespace Tennis.DAL.Entities;
public class GameOutcomeEntity
{
    public int Id { get; set; }
    public int IdWinner { get; set; }
    public int IdLoser { get; set; }
    public DateTime DateStartGame { get; set; }
    public DateTime DateEndGame { get; set; }
}