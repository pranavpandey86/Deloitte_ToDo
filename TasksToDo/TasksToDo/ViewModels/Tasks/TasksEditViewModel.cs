using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.ViewModels
{
    public class TasksEditViewModel : AddOrEditSingleEntityViewModelBase
    {
        [Required(ErrorMessage = "Please provide a description")]
        [StringLength(500, ErrorMessage = "The description cannot be longer than 500 characters")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }


        public bool IsComplete { get; private set; }

    }
}
