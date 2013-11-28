﻿using GalaSoft.MvvmLight;
using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ViewModel
{
    public class NoteViewModel : ViewModelBase
    {
        private INote model;

        private ObservableCollection<LabelViewModel> labels = new ObservableCollection<LabelViewModel>();

        public NoteViewModel(INote model)
        {
            this.model = model;
        }

        public ObservableCollection<LabelViewModel> Labels
        {
            get { return labels; }
        }

        internal void LoadLabelViewModels(IDictionary<int, LabelViewModel> labelViewModels)
        {
            foreach (var label in model.Labels)
            {
                labels.Add(labelViewModels[label.ID]);
            }
        }

        public string Title
        {
            get
            {
                return model.Title;
            }
            set
            {
                if (value == model.Title)
                    return;

                this.model.Title = value;

                base.RaisePropertyChanged("Title");
            }
        }

        public void Load()
        {
            App.Bll.LoadNote(model);
        }
    }
}
