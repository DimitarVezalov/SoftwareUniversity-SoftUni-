using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        ICollection<RepositoryListViewModel> GetAllPublic();

        void Create(string name, string isPublic, string userId);

        string GetRepositoryNameById(string id);
    }
}
