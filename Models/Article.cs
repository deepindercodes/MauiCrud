using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCrud.Models
{
    public class Article
    {
        public string? id { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string articletitle { get; set; }

        [Display(Name = "Author")]
        [Required]
        public string articleauthor { get; set; }

        [Display(Name = "Body")]
        [Required]
        public string articlebody { get; set; }

        public string? articleimage { get; set; }
        public string? createdonutc { get; set; }
        public string? modifiedonutc { get; set; }
        public string? status { get; set; }
    }
}
