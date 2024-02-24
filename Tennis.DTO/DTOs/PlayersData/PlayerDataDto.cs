using System.ComponentModel.DataAnnotations;

namespace Tennis.DTO.DTOs.PlayersData;
public record PlayerDataDto
{
    [Required]
    public int Rank { get; set; }

    [Required]
    public int Points { get; set; }

    [Required]
    public int Weight { get; set; }

    [Required]
    public int Height { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public int[] Last { get; set; }
}