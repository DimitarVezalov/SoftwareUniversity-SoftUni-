using Andreys.ViewModels.Products;
using Andreys.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    public interface IValidator
    {
        public bool ValidateRegisterInputModel(RegisterInputModel model);

        public bool ValidateAddProductInputModel(AddProductInputModel model);

    }
}
