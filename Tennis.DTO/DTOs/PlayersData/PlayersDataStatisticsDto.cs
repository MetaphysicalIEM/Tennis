using System.ComponentModel.DataAnnotations;

namespace Tennis.DTO.DTOs.PlayersData;
public record PlayersDataStatisticsDto
{
    [Required]
    public double CountryWithHighestWinRatio { get; set; }

    [Required]
    public double AverageBMI { get; set; }

    [Required]
    public int MedianPlayerHeight { get; set; }
}