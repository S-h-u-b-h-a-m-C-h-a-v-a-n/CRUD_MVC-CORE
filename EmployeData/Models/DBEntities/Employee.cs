using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeData.Models.DBEntities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
        
        [Column(TypeName ="varchar(50)")]
        public string First_Name { get; set; }
       
        
        public string Last_Name { get; set; }
       
        
        public DateTime DateOfBirth { get; set; }
        
        public string Email { get; set; }
        
        public Double Salary { get; set; }
    }
}
