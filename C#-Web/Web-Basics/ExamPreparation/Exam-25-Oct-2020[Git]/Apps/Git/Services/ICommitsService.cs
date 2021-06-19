using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService 
    {
        void Create(string description, string userId, string repositoryId);

        ICollection<AllCommitsViewModel> GetAllById(string userId);

        void Delete(string id, string userId);

    }
}
