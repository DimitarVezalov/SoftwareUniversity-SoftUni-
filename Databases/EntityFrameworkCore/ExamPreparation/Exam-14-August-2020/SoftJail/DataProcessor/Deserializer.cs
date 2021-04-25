namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var depDtos = JsonConvert.DeserializeObject<DepartmentImportDto[]>(jsonString);

            List<Department> validDepartments = new List<Department>();

            foreach (var depDto in depDtos)
            {
                if (!IsValid(depDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (depDto.Cells.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (depDto.Cells.Any(c => !IsValid(c)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new Department
                {
                    Name = depDto.Name
                };

                foreach (var cellDto in depDto.Cells)
                {
                    if (!cells.Any(c => c.CellNumber == cellDto.CellNumber))
                    {
                        Cell cell = new Cell
                        {
                            CellNumber = cellDto.CellNumber,
                            HasWindow = cellDto.HasWindow
                        };

                        department.Cells.Add(cell);
                    }
                }

                validDepartments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");

            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var prisonerDtos = JsonConvert.DeserializeObject<PrisonerImportDto[]>(jsonString);
            List<Prisoner> validPrisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;
                bool isIncDateParsed = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                if (!isIncDateParsed)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Prisoner prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate
                };

                DateTime releaseDate;

                if (prisonerDto.ReleaseDate != null)
                {                  
                    bool isReleaseDateParsed = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                    if (!isReleaseDateParsed)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    prisoner.ReleaseDate = releaseDate;
                }

                Cell cell = context.Cells.Find(prisonerDto.CellId);

                prisoner.Cell = cell;

                if (prisonerDto.Mails.Any(m => !IsValid(m)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var mailDto in prisonerDto.Mails)
                {
                    Mail mail = new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    };

                    prisoner.Mails.Add(mail);
                }

                validPrisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = 
                new XmlSerializer(typeof(OfficerImportDto[]), new XmlRootAttribute("Officers"));

            OfficerImportDto[] officerDtos;

            using (var reader = new StringReader(xmlString))
            {
                officerDtos = (OfficerImportDto[])serializer.Deserialize(reader);
            }

            List<Officer> validOfficers = new List<Officer>();

            foreach (var officerDto in officerDtos)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Officer officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                };

                Position position;
                bool isPositionParsed = Enum.TryParse<Position>(officerDto.Position, out position);

                if (!isPositionParsed)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                officer.Position = position;

                Weapon weapon;
                bool isWeaponParsed = Enum.TryParse<Weapon>(officerDto.Weapon, out weapon);

                if (!isWeaponParsed)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                officer.Weapon = weapon;

                Department department = context.Departments.Find(officerDto.DepartmentId);

                officer.Department = department;

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    Prisoner prisoner = context.Prisoners.FirstOrDefault(p => p.Id == prisonerDto.Id);

                    officer
                        .OfficerPrisoners
                        .Add(new OfficerPrisoner { Officer = officer, Prisoner = prisoner });
                }

                validOfficers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}