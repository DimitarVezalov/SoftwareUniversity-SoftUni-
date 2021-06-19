using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Services
{
    public interface IIssuesService
    {
        void CreateIssue(string description, string carId);

        CarWithIssuesViewModel GetCarIssuesByCarId(string carId);

        void FixIssue(string issueId, string carId);

        void DeleteIssue(string issueId, string carId);

    }
}
