using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels.Repositories
{
    public class RepositoryListViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string CreatedOn { get; set; }

        public int CommitsCount { get; set; }
    }
}
