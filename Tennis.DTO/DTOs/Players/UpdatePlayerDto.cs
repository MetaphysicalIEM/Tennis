using System.ComponentModel.DataAnnotations;
using Tennis.DTO.DTOs.PlayersData;
using Tennis.DTO.Helper;

namespace Tennis.DTO.DTOs.Players;
public record UpdatePlayerDto
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string ShortName { get; set; }

    [Required]
    public Gender Sex { get; set; }

    [Required]
    [MaxLength(3)]
    public string CountryCode { get; set; }

    [Required]
    public PlayerDataDto Data { get; set; }
}
