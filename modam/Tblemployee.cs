using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace corevipul1.Models;

public partial class Tblemployee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public int? Salary { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Datetime { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Gender { get; set; }

    public string? Hobbies { get; set; }
    
    public int? Country { get; set; }
    
    public int? State { get; set; }
    
    public int? City { get; set; }
    [NotMapped]
    public string? CountryName { get; set; }
    [NotMapped]
    public string? StateName { get; set; }
    [NotMapped]
    public string? CityName { get; set; }
    [NotMapped]
    public string? Photo { get; set; }   // Photo name for database

    [NotMapped]
    public IFormFile? UploadFile { get; set; }  // For uploading purpose
}
