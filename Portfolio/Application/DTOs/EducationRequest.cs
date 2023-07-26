using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    internal class EducationRequest
    {
        public Guid Id { get; set; }
        public string Degree { get; set; }
               
        public string FieldOfStudy { get; set; }
               
        public string School { get; set; }
               
        public string StartYear { get; set; }
               
        public string EndYear { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
