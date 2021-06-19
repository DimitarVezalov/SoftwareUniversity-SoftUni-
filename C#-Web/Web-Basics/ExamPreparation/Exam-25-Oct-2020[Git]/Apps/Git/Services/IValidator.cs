using Git.ViewModels.Repositories;
using Git.ViewModels.Users;


namespace Git.Services
{
    public interface IValidator
    {
        string ValidateUserRegistrationModel(RegisterInputModel model);

        public string ValidateCreateRepositoryInputModel(CreateRepositoryInputModel model);

        public string ValidateCommitDescription(string description);
    }
}
