//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HD_Task_Attempt_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Vehicle
    {
        public Vehicle()
        {
            this.Repairs = new HashSet<Repair>();
        }

        [Required(ErrorMessage = "Vehicle Identification Number Required")]
        public string VIN { get; set; }

        [Required(ErrorMessage = "Vehicle Required")]
        public string vehMake { get; set; }

        [Required(ErrorMessage = "Vehicle Model Required")]
        public string vehModel { get; set; }

        [Required(ErrorMessage = "Vehicle Year Required")]
        public string vehYear { get; set; }

        [Required(ErrorMessage = "Vehicle Trim Required")]
        public string vehTrim { get; set; }

        [Required(ErrorMessage = "Vehicle Cost Required")]
        public decimal vehCost { get; set; }

        [Required(ErrorMessage = "Vehicle Price Required")]
        public decimal vehPrice { get; set; }

        [Required(ErrorMessage = "Vehicle Quantity Required")]
        public int vehQuantity { get; set; }
        public Nullable<int> ManID { get; set; }
    
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Repair> Repairs { get; set; }
    }
}