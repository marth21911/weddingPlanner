using System;
using System.ComponentModel.DataAnnotations;
namespace weddingPlanner.Models
{
    public class Event
    {
        [Key]
        public int EventId {get;set;}
        public int UserId {get;set;}
        public int WeddingId {get;set;}
        public User User {get;set;}
        public Wedding Wedding {get;set;}
    }
}