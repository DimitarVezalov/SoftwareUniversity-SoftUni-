using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerImportDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Weapon { get; set; }

        public int DepartmentId { get; set; }

        public OfficerPrisionerImportDto[] Prisoners { get; set; }
    }

    /*•	Id – integer, Primary Key
•	FullName – text with min length 3 and max length 30 (required)
•	Salary – decimal (non-negative, minimum value: 0) (required)
•	Position - Position enumeration with possible values: “Overseer, Guard, Watcher, Labour” (required)
•	Weapon - Weapon enumeration with possible values: “Knife, FlashPulse, ChainRifle, Pistol, Sniper” (required)
•	DepartmentId - integer, foreign key (required)
•	Department – the officer's department (required)
•	OfficerPrisoners - collection of type OfficerPrisoner
*/
}
