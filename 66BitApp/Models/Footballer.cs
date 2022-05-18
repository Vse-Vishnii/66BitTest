using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace _66BitApp.Models
{
    public class Footballer : DbEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [BindProperty, Required] 
        public Sex Sex { get; set; }
        [DataType(DataType.Date)]
        [Required, BindProperty]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string TeamName { get; set; }
        [BindProperty, Required]
        public Country Country { get; set; }
    }

    public enum Sex
    {
        Male,
        Female
    }

    public enum Country
    {
        Russia,
        USA,
        Italy
    }
}
