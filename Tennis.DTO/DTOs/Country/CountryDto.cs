using System.ComponentModel.DataAnnotations;

namespace Tennis.DTO.DTOs.Country;
public record CountryDto
{
    [Required]
    public string Picture { get; set; }
    [Required]
    [MaxLength(3)]
    public string Code { get; set; }
}