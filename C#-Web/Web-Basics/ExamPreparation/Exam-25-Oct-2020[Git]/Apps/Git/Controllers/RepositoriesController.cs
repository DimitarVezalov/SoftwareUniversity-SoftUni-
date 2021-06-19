using Git.Services;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;
        private readonly IValidator validator;

        public RepositoriesController(IRepositoriesService repositoriesService, IValidator validator)
        {
            this.repositoriesService = repositoriesService;
            this.validator = validator;
        }

        public HttpResponse All()
        {

            var repositories = this.repositoriesService.GetAllPublic();

            return this.View(repositories);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepositoryInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var errors = this.validator.ValidateCreateRepositoryInputModel(input);

            if (!String.IsNullOrEmpty(errors))
            {
                return this.Error(errors);
            }

            var userId = this.GetUserId();

            this.repositoriesService.Create(input.Name, input.RepositoryType, userId);

            return this.Redirect("/Repositories/All");
        }
    }
}
