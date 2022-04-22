using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace weddingPlanner.Models
{
    public class Wedding{
    [Key]
    public int WeddingId {get;set;}
    [Required]
    public string WedOne {get;set;}
    [Required]
    public string WedTwo {get;set;}
    [Required]
    [DataType(DataType.Date)]
    [ValidateWeddingDate(ErrorMessage ="Wedding date must be after today")]
    public DateTime WedDate {get;set;}
    [Required]
    public string Address {get;set;}
    public List<Event> Attendees {get;set;}
    public int UserId {get;set;}
    public User User {get;set;}
    public DateTime CreatedAt{get;set;}
    public DateTime UpdatedAt{get;set;}
    }

}