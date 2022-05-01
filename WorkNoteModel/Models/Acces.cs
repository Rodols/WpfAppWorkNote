﻿using System;
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
        public AccesType Type { get; set; }
        public string Note { get; set; }
        public int IdSource { get; set; }
        public string Date { get; set; }
    }
}
