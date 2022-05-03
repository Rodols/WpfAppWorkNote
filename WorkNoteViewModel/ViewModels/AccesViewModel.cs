using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkNoteModel.Models;
using WorkNoteViewModel.Core;
using WorkNoteViewModel.Core.Commands;

namespace WorkNoteViewModel
{

    public class AccesViewModel :IGeneric
    {
        DataAcces data = new DataAcces();
        
        #region Properties
        private List<Acces> _accesList = new List<Acces>();
        private List<AccesType> _typeList = new List<AccesType>();
        private List<Source> _sourceList = new List<Source>();
        private string _Name="";
        private string _Ip="";
        private string _Adrees="";
        private int _IdTypeAcces=0;
        private string _Note="";
        private int _IdSource=0;

        public string Name
        {
            get { return _Name; }
            set {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Ip
        {
            get { return _Ip; }
            set { 
                _Ip = value;
                RaisePropertyChanged("Ip");
            }
        }

        public string Adrees
        {
            get { return _Adrees; }
            set {
                _Adrees = value;
                RaisePropertyChanged("Adrees");
            }
        }

        public int IdTypeAcces
        {
            get { return _IdTypeAcces; }
            set {
                _IdTypeAcces = value;
                RaisePropertyChanged("IdTypeAcces");
            }
        }

        public int IdSource
        {
            get { return _IdSource; }
            set {
                _IdSource = value;
                RaisePropertyChanged("IdSource");
            }
        }

        public string Note
        {
            get { return _Note; }
            set {
                _Note = value;
                RaisePropertyChanged("Note");
            }

        }

        public List<Source> SourceList
        {
            get { return _sourceList; }
            set {
                _sourceList = value;
                RaisePropertyChanged("SourceList");
            }
        }
        public List<AccesType> TypeList
        {
            get { return _typeList; }
            set { 
                _typeList = value;
                RaisePropertyChanged("TypeList");
            }
        }

        public List<Acces> AccesList
        {
            get { return _accesList; }
            set { 
                _accesList = value;
                RaisePropertyChanged("AccesList");
            }
        }

        #endregion

        #region Commands
        private RelayCommand _BtnSaveAcces;

        public RelayCommand BtnSaveAcces
        {
            get
            {
                if (_BtnSaveAcces == null)
                {
                    _BtnSaveAcces = new RelayCommand(SaveAcces);
                }
                return _BtnSaveAcces;
            }
        }

        #endregion

        #region Methods
        private void SaveAcces()
        {
            Acces acces = new Acces();
            acces.Name = Name;
            acces.Ip = Ip;
            acces.Adrees = Adrees;
            acces.IdType = IdTypeAcces;
            acces.Note = Note;
            acces.IdSource = IdSource;

            data.AddAcces(acces);
            AccesList = data.GetAcces();
        }
        #endregion

        public AccesViewModel()
        {
            AccesList = data.GetAcces();
            TypeList = data.GetAccesType();
            SourceList = data.GetSource();
        }



    }
}
