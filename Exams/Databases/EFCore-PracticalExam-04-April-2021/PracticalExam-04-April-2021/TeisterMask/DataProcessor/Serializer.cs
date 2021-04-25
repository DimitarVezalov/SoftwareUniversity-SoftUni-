namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .Where(p => p.Tasks.Count > 0)
                .ToArray()
                .Select(p => new ProjectExportModel
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate != null ? "Yes" : "No",
                    Tasks = p.Tasks
                    .ToArray()
                    .Select(t => new TaskExportModel
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()

                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            XmlSerializer serializer =
                new XmlSerializer(typeof(ProjectExportModel[]), new XmlRootAttribute("Projects"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, projects, namespaces);
            }

            string output = sb.ToString().TrimEnd();

            output = output.Replace("utf-16", "utf-8");

            return output;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
             .ToList()
             .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
             .Select(e => new
             {
                 Username = e.Username,
                 Tasks = e.EmployeesTasks
                 .ToList()
                 .Where(et => et.Task.OpenDate >= date)
                 .OrderByDescending(x => x.Task.DueDate)
                 .ThenBy(x => x.Task.Name)
                 .Select(t => new
                 {
                     TaskName = t.Task.Name,
                     OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                     DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                     LabelType = t.Task.LabelType.ToString(),
                     ExecutionType = t.Task.ExecutionType.ToString()
                 })
                 .ToList()
             })
             .OrderByDescending(x => x.Tasks.Count)
             .ThenBy(x => x.Username)
             .Take(10)
             .ToList();

            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return json;
        }
    }
}