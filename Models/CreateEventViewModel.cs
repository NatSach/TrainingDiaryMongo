using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainigDiaryMongo.Models
{
    public class CreateEventViewModel
    {
        public Event NewEvent { get; set; } 

        [Display(Name = "Event type")]
        public string SelectedType { get; set; }

        [Display(Name = "Types")]
        public List<SelectListItem> EventTypes { get; set; }
    }
}
