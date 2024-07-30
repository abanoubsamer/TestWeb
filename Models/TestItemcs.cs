using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc; // Use this namespace for Remote validation

namespace TestWeb.Models
{
    public class TestItemcs
    {
        

        [Key]
        public int Id { get; set; }
       
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime CreateDate { get; set; }
        
        [ForeignKey("Categorys")]
        public int CategoryId { get; set; }

        public Category? Categorys { get; set; }
    }
}
