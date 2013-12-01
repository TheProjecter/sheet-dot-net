using GalaSoft.MvvmLight;
using Sheet.Facade.Notes;
using Sheet.GUI.Commands;
using Sheet.GUI.ModelMocks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace Sheet.GUI.ViewModel
{
    public class NoteViewModel : CompositeViewModel
    {
        private INote model;

        private bool upToDate = true;

        private ObservableCollection<LabelViewModel> labels;
        private ObservableCollection<AttachmentViewModel> attachments;

        private UpdateLabelsCommand update;

        public NoteViewModel(MainViewModel main) : base(main)
        {
            this.model = new NoteMock();
        }

        public NoteViewModel(INote model, MainViewModel main) : base(main)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            this.model = model;
            update = new UpdateLabelsCommand(this);
            main.RegisterViewModel(model, this);
            LoadViewModels();
        }

        protected override void LoadViewModels()
        {
            LabelString = string.Join(", ", model.Labels.Where(l => l.Text != "No label").Select((l) => (l.Text)));
            Labels.Clear();
            foreach (var label in model.Labels)
            {
                Labels.Add(main.GetViewModel(label));
            }

            Attachments.Clear();
            foreach (var attachment in model.Attachments)
            {
                Attachments.Add(main.GetViewModel(attachment));
            }
        }

        public ICommand Update
        {
            get { return update; }
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

                upToDate = false;

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

                upToDate = false;

                base.RaisePropertyChanged("Text");
            }
        }

        private string labelString = "";
        public string LabelString
        {
            get
            {
                return labelString;
            }
            set
            {
                if (value == labelString)
                    return;

                labelString = value;

                base.RaisePropertyChanged("LabelString");
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
                if (main.Labels.Contains(label) == false)
                {
                    main.Labels.Add(label);
                }
            }
        }

        public void Disconnect()
        {
            foreach (var label in Labels)
            {
                label.Notes.Remove(this);
                if (label.Notes.Count == 0)
                {
                    main.Labels.Remove(label);
                }
            }
        }

        public INote Model
        {
            set
            {
                if (this.model == value)
                    return;

                if (model is ModelMock)
                {
                    value.Title = model.Title;
                    value.Text = model.Text;
                }
                this.model = value;
                base.RaisePropertyChanged("");
                LoadViewModels();
            }
        }

        public void Delete()
        {
            Disconnect();
            main.UnregisterViewModel(model);
            App.Bll.DeleteNote(model);
        }

        public void Load()
        {
            Model = App.Bll.LoadNote(model);
        }

        public void Save()
        {
            if (!upToDate)
            {
                upToDate = true;
                App.Bll.SaveNote(model);
                //Task.Run(() => App.Bll.SaveNote(model));
            }
        }

        internal void UpdateLabels(string[] labels)
        {
            INote updated = App.Bll.UpdateLabels(model, labels);
            Disconnect();
            Model = updated;
            Connect();
        }
    }
}
