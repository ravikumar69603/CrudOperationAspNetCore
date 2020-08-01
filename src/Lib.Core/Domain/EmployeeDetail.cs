using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lib.Core.Domain
{
    public partial class EmployeeDetail
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Emplyoee { get; set; }

        [Required]
        [DisplayName("Email Id")]
        [DataType(DataType.EmailAddress)]
        public string Emailid { get; set; }

        [Required]
        [DisplayName("Department")]
        public string Departmet { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? LastupdateOn { get; set; }
    }
}
