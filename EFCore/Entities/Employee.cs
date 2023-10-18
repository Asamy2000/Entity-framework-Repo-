using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Entities /*DomainModels - POCOClasses*/
{
    //POCO Class 
    //Plain OLD CLR Object
    //Classes without Functionality

    #region Convention-Based Mapping
    //1.Convention-Based Mapping

    //internal class Employee
    //{
    //    //public numeric prop Named as ['Id' | EntityNameId "EmployeeId"]
    //    public int Id { get; set; } //PK
    //    public string Name { get; set; } //col of Nvarchar(Max) allow null
    //    //public string Name { get; set; } //col of Nvarchar(Max) not allow null
    //    public decimal Salary { get; set; } //col of decimal (18,2)
    //    public int? Age { get; set; }       //col of int allow null [optional]
    //    //public int Age { get; set; }       //col of int not allow null [required]
    //} 
    #endregion

    #region Data Annotation
    //2.Data Annotation [System.ComponentModel.DataAnnotations;] 'DataValidation'
    //[Table("Employess")]
    internal class Employee
    {
        [Key] /*set Id as PK*/
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] /* identity(1,1)*/
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] /* remove identity*/
        public int EmpId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)] /* validate string length max - min */
        //[MaxLength(50)]
        [Column(TypeName = "VarChar")]  /*validate dataType*/
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Range(22, 60)]
        public int? Age { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        //represents FK in the Table
        [ForeignKey("Department")]
         public int? DepartmentDeptId { get; set; }
        //Navigational Prop
        public  Department Department { get; set; }
        //[ForeignKey("Car")]
        //public int? CarId { get; set; }
        //public Car Car { get; set; }
        //[NotMapped]
        //public int NotMapped { get; set; }



    }
    #endregion


}
