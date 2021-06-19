using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string repositoryType, string userId)
        {
            var repository = new Repository
            {
                Name = name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = repositoryType.ToLower() == "public" ? true : false,
                OwnerId = userId
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public ICollection<RepositoryListViewModel> GetAllPublic()
        {
            var repos = this.db.Repositories
                .Where(r => r.IsPublic)
                .Select(r => new RepositoryListViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToShortDateString(),
                    CommitsCount = r.Commits.Count()
                })
                .ToList();

            return repos;
        }

        public string GetRepositoryNameById(string id)
        {
            var name = this.db.Repositories
                .Where(r => r.Id == id)
                .Select(r => r.Name)
                .FirstOrDefault();

            return name;
        }
    }
}
