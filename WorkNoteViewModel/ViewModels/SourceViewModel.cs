using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkNoteModel.Models;
using WorkNoteViewModel.Core;
using WorkNoteViewModel.Core.Commands;

namespace WorkNoteViewModel
{
    public class SourceViewModel : IGeneric
    {
        DataAcces dataAcces = new DataAcces();

        #region Propertie
        private string _Name;
        private string _Description;
        private List<Source> _SourceList = new List<Source>();


        public string Name
        {
            get { return _Name; }
            set {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return _Description; }
            set {
                _Description = value;
                RaisePropertyChanged("Description");
            }
        }

        public List<Source> SourceList
        {
            get { return _SourceList; }
            set
            {
                _SourceList = value;
                RaisePropertyChanged("SourceList");
            }
        }
        #endregion

        #region Commands
        private RelayCommand _BtnSaveSource;

        public RelayCommand BtnSaveSource
        {
            get {
                if (_BtnSaveSource == null) {
                    _BtnSaveSource = new RelayCommand(SaveSource);
                }
                return _BtnSaveSource;
            }
        }
        #endregion

        private void SaveSource()
        {
            Source source = new Source();
            source.Name = Name;
            source.Description = Description;
            dataAcces.AddSource(source);
            SourceList = dataAcces.GetSource();
        }

        public SourceViewModel()
        {
            SourceList = dataAcces.GetSource();
        }
    }
}
