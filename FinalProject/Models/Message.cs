//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Message
    {
        public int ID { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [EmailAddress]

        public string email { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string message { get; set; }
        public DateTime DateOfSend { get; set; }
    }
}
