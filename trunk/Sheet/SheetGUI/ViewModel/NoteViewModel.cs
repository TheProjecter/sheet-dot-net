using GalaSoft.MvvmLight;
using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace Sheet.GUI.ViewModel
{
    public class NoteViewModel : CompositeViewModel
    {
        private INote model;

        private ObservableCollection<LabelViewModel> labels;
        private ObservableCollection<AttachmentViewModel> attachments;

        public NoteViewModel(INote model, ViewModelFactory factory) : base(factory)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            this.model = model;
            factory.RegisterViewModel(model, this);
            LoadViewModels();
        }

        protected override void LoadViewModels()
        {
            Labels.Clear();
            foreach (var label in model.Labels)
            {
                Labels.Add(factory.GetViewModel(label));
            }

            Attachments.Clear();
            foreach (var attachment in model.Attachments)
            {
                Attachments.Add(factory.GetViewModel(attachment));
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

        public string Text
        {
            get
            {
                return model.Text;
            }
            set
            {
                if (value == model.Text)
                    return;

                this.model.Text = value;

                base.RaisePropertyChanged("Text");
            }
        }

        public ObservableCollection<LabelViewModel> Labels
        {
            get
            {
                if (labels == null)
                    labels = new ObservableCollection<LabelViewModel>();
                return labels;
            }
        }

        public ObservableCollection<AttachmentViewModel> Attachments
        {
            get
            {
                if (attachments == null)
                    attachments = new ObservableCollection<AttachmentViewModel>();
                return attachments;
            }
        }

        public void Connect()
        {
            foreach (var label in Labels)
            {
                label.Notes.Add(this);
            }
        }

        public void Disconnect()
        {
            foreach (var label in Labels)
            {
                label.Notes.Remove(this);
            }
        }

        public INote Model
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

        public void Delete()
        {
            Disconnect();
            factory.UnregisterViewModel(model);
            App.Bll.DeleteNote(model);
        }

        public void Load()
        {
            Model = App.Bll.LoadNote(model);
        }
    }
}
