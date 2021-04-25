namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer =
                new XmlSerializer(typeof(ProjectImportModel[]), new XmlRootAttribute("Projects"));

            ProjectImportModel[] projectDtos;

            using (var reader = new StringReader(xmlString))
            {
                projectDtos = (ProjectImportModel[])serializer.Deserialize(reader);
            }

            foreach (var dto in projectDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;
                bool isValidOpenDate = DateTime.TryParseExact(dto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                if (!isValidOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Project project = new Project
                {
                    Name = dto.Name,
                    OpenDate = openDate
                };

                if (dto.DueDate != null)
                {
                    DateTime dueDate;
                    bool isDueDateParsed = DateTime.TryParseExact(dto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDate);

                    if (isDueDateParsed)
                    {
                        project.DueDate = dueDate;
                    }
                }

                foreach (var taskDto in dto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    bool isParsedOpenDate = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    DateTime taskDueDate;
                    bool isParsedDueDate = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isParsedOpenDate || !isParsedDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < project.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (project.DueDate != null)
                    {
                        if (taskDueDate > project.DueDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    Task task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = Enum.Parse<ExecutionType>(taskDto.ExecutionType.ToString()),
                        LabelType = Enum.Parse<LabelType>(taskDto.LabelType.ToString())
                    };

                    project.Tasks.Add(task);
                }

                context.Projects.Add(project);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var employeeDtos = JsonConvert.DeserializeObject<EmployeeImportModel[]>(jsonString);

            foreach (var dto in employeeDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Phone = dto.Phone
                };

                foreach (var task in dto.Tasks.Distinct())
                {
                    if (!context.Tasks.Select(t => t.Id).Contains(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task currentTask = context.Tasks.FirstOrDefault(t => t.Id == task);

                    EmployeeTask employeeTask = new EmployeeTask
                    {
                        Employee = employee,
                        Task = currentTask
                    };

                    employee.EmployeesTasks.Add(employeeTask);
                }

                context.Employees.Add(employee);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username,
                    employee.EmployeesTasks.Count));
            }
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}