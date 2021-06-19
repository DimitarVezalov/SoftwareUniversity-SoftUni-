using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string description, string userId, string repositoryId)
        {
            var commit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
                RepositoryId = repositoryId
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }

        public void Delete(string id, string userId)
        {
            var commit = this.db.Commits
                .Where(c => c.Id == id && c.CreatorId == userId)
                .FirstOrDefault();

            this.db.Remove(commit);
            this.db.SaveChanges();
        }

        public ICollection<AllCommitsViewModel> GetAllById(string userId)
        {
            var commits = this.db.Commits
                .Where(c => c.CreatorId == userId)
                .Select(c => new AllCommitsViewModel 
                {
                    Id = c.Id,
                    RepositoryName = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToShortDateString()
                })
                .ToList();

            return commits;
        }


    }
}
