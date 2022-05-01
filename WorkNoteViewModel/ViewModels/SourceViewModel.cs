using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkNoteModel.Models;

namespace WorkNoteViewModel
{
    public class SourceViewModel
    {
        DataAcces dataAcces = new DataAcces();

        #region Propertie
        private string _Name;
        private string _Description;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        #endregion

        public SourceViewModel()
        {

        }
    }
}
