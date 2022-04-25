using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkNoteModel.Models;

namespace WorkNoteViewModel
{

    public class AccesViewModel
    {
        DataAcces data = new DataAcces();
        public List<Acces> AccesList = new List<Acces>();
        public List<AccesType> TypeList = new List<AccesType>();

    public AccesViewModel()
        {
            AccesList = data.GetAcces();
            TypeList = data.GetType();
        }

    }
}
