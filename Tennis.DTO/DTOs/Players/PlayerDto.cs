using System.ComponentModel.DataAnnotations;
using Tennis.DTO.DTOs.Country;
using Tennis.DTO.DTOs.PlayersData;

namespace Tennis.DTO.DTOs.Players;
public record PlayerDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string ShortName { get; set; }

    [Required]
    [MaxLength(1)]
    public string Sex { get; set; }

    [Required]
    public CountryDto Country { get; set; }

    [Required]
    public string Picture { get; set; }

    [Required]
    public PlayerDataDto Data { get; set; }
}
