using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly IRepositoriesService repositoriesService;
        private readonly ICommitsService commitsService;
        private readonly IValidator validator;

        public CommitsController(
            IRepositoriesService repositoriesService, 
            ICommitsService commitsService,
            IValidator validator)
        {
            this.repositoriesService = repositoriesService;
            this.commitsService = commitsService;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var commits = this.commitsService.GetAllById(userId);

            return this.View(commits);
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var repositoryName = this.repositoriesService.GetRepositoryNameById(id);

            var commitViewModel = new CreateCommitViewModel
            {
                Id = id,
                Name = repositoryName
            };

            return this.View(commitViewModel);
        }

        [HttpPost]
        public HttpResponse Create(string description, string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            string errors = this.validator.ValidateCommitDescription(description);

            if (!String.IsNullOrEmpty(errors))
            {
                return this.Error(errors);
            }

            var userId = this.GetUserId();

            this.commitsService.Create(description, userId, id);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            this.commitsService.Delete(id, userId);

            return this.Redirect("/Commits/All");
        }
    }
}
