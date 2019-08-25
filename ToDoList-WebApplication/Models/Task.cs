using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ToDoList_WebApplication.Models
{
    public class Task
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BeginDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }        
        public bool Finished { get; set; }
        [Display(Name = "Show Finished Tasks")]
        public bool ShowFinished { get; set; }
    }
}
