using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeData.Models
{
    public class EmployeeViewModel
    {
       
        public int Id { get; set; }
      
        [DisplayName("First Name")]
        public string First_Name { get; set; }
        
        [DisplayName("Last Name")]
        public string Last_Name { get; set; }

        [DisplayName(" DateOfBirth ")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName(" E-mail ")]
        public string Email { get; set; }

        public Double Salary { get; set; }

        [DisplayName(" Name ")]
        public string FullName
        {
            get { return First_Name + " " + Last_Name; }
        }
    }
}
