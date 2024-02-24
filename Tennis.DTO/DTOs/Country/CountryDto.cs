using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.DTO.DTOs.Country;
public record class CountryDto
{
    [Required]
    public string Picture { get; set; }

    [Required]
    [MaxLength(3)]
    public string Code { get; set; }
}
