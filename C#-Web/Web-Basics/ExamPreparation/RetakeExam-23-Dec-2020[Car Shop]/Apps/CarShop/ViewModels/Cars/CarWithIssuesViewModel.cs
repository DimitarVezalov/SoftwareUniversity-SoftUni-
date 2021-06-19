using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.ViewModels.Cars
{
    public class CarWithIssuesViewModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public List<IssueListViewModel> Issues { get; set; }
    }
}
