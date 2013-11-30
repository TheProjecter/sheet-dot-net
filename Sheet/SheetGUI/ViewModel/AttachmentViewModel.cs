using GalaSoft.MvvmLight;
using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ViewModel
{
    public class AttachmentViewModel : CompositeViewModel
    {
        private IAttachment model;

        private ObservableCollection<MetainfoViewModel> metadata = new ObservableCollection<MetainfoViewModel>();

        public AttachmentViewModel(IAttachment model, ViewModelFactory factory) : base(factory)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            this.model = model;
            factory.RegisterViewModel(model, this);
            LoadViewModels();
        }

        protected override void LoadViewModels()
        {
            Metadata.Clear();
            foreach (var metainfo in model.Metadata)
            {
                Metadata.Add(factory.GetViewModel(metainfo));
            }
        }

        public string Name
        {
            get { return this.model.Name; }
            set
            {
                if (this.model.Name == value)
                    return;

                this.model.Name = value;

                base.RaisePropertyChanged("Name");
            }
        }

        public ObservableCollection<MetainfoViewModel> Metadata
        {
            get
            {
                if (metadata == null)
                    metadata = new ObservableCollection<MetainfoViewModel>();
                return metadata;
            }
        }

        public IAttachment Model
        {
            set
            {
                if (this.model == value)
                    return;

                this.model = value;
                base.RaisePropertyChanged("");
                LoadViewModels();
            }
        }
    }
}
