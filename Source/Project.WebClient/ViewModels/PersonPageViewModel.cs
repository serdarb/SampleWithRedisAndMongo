using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebClient.ViewModels
{
    public class PersonPageViewModel
    {
        public List<PersonViewModel> Items { get; set; }

        public PersonPageViewModel()
        {
            Items = new List<PersonViewModel>();
        }
    }
}