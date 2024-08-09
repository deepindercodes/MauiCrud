using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCrud.Models
{
    public class Articles
    {
        public string pk { get; set; }
        public List<Article> articles { get; set; }
    }
}
