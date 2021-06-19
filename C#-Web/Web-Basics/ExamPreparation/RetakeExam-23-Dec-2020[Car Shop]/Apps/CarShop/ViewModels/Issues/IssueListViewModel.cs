using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.ViewModels.Issues
{
    public class IssueListViewModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public bool IsFixed { get; set; }

        public string IsFixedAsString => this.IsFixed ? "Yes" : "Not yet";
    }
}
