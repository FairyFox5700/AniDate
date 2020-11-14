using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Account.API.Entities
{
    public class Image
    {  
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        public string ImageFileName { get; set; }
        public string ImageUri { get; set; }
        public  string Extension { get; set; }
    }
}