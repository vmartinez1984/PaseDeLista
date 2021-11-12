using System;
using System.ComponentModel.DataAnnotations;

namespace RollCall.Persistence.Entities
{
  public class Config
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public string Value { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [Required]
    public DateTime DateRegistration { get; set; }
  }
}