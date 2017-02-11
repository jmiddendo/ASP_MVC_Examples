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

    public partial class Manufacturer
    {

        

        public Manufacturer()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }
    
        public int ManID { get; set; }

        [Required(ErrorMessage = "Manufacturer Name Required")]
        public string ManName { get; set; }

        [Required(ErrorMessage = "Contact's First Name Required")]
        public string contactFName { get; set; }

        [Required(ErrorMessage = "Contact's Last Name Required")]
        public string contactLName { get; set; }

        [Required(ErrorMessage = "Manufacturer's Street Address Required")]
        public string ManStreet { get; set; }

        [Required(ErrorMessage = "Manufacturer's Suburb Required")]
        public string ManSuburb { get; set; }

        [Required(ErrorMessage = "Manufacturer's State Required")]
        public string ManState { get; set; }

        [Required(ErrorMessage = "Manufacturer's Postcode Required")]
        [StringLength(4,ErrorMessage="Postcode Must Be Four Characters")]
        public string ManPost { get; set; }

        [Required(ErrorMessage = "Manufacturer's Phone Required")]
        public string ManPhone { get; set; }

        [Required(ErrorMessage = "Manufacturer's Email Required")]
        [RegularExpression(".+@.+\\..+",ErrorMessage = "Invalid Email")]
        public string ManEmail { get; set; }
    
        

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
