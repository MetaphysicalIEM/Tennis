using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.DTO.DTOs.Country;
using Tennis.DTO.DTOs.PlayerData;
using Tennis.DTO.Helper;

namespace Tennis.DTO.DTOs.Player;
public record class CreatePlayerDto
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

