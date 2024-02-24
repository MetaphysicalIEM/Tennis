using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Tennis.DTO.DTOs.PlayerData;
using Tennis.DTO.Helper;

namespace Tennis.DTO.DTOs.Player;
public record UpdatePlayerDto
{
    [Required]
    public string Firstname { get; set; }

    [Required]
    public string Lastname { get; set; }

    [Required]
    public string Shortname { get; set; }

    [Required]
    public Gender Sex { get; set; }

    [Required]
    [MaxLength(3)]
    public string CountryCode { get; set; }

    [Required]
    public PlayerDataDto Data { get; set; }
}
