using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Ticket")]
    public class TicketInputModel
    {
        public int ProjectionId { get; set; }

        public decimal Price { get; set; }
    }
}
