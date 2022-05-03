using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkNoteModel.Models
{
    public class Acces
    {
        public int IdAcces { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Adrees { get; set; }
        public int IdType { get; set; }
        public string AccesType { get; set; }
        public string Note { get; set; }
        public int IdSource { get; set; }
        public string Source { get; set; }
        public DateTime Date { get; set; }
    }
}
