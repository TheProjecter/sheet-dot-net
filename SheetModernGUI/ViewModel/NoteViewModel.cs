using GalaSoft.MvvmLight;
using Sheet.ModernGUI.Commands;
using Sheet.ModernGUI.SheetServiceReference;
//using Sheet.ModernGUI.Commands;
//using Sheet.GUI.ModelMocks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sheet.ModernGUI.ViewModel
{
    public class NoteViewModel : CompositeViewModel
    {
        private Note model;

        private bool upToDate = true;

        private ObservableCollection<LabelViewModel> labels;
        //private ObservableCollection<AttachmentViewModel> attachments;

        //private UpdateLabelsCommand update;
        //private NewAttachmentCommand newAttachment;
        //private DeleteAttachmentCommand deleteAttachment;
        private SaveNoteCommand saveNote;
        private DeleteNoteCommand deleteNote;
        

        public NoteViewModel(MainViewModel main) : base(main)
        {
            this.model = new Note();
        }

        public NoteViewModel(Note model, MainViewModel main) : base(main)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            this.model = model;
            //update = new UpdateLabelsCommand(this);
            //newAttachment = new NewAttachmentCommand(this);
            //deleteAttachment = new DeleteAttachmentCommand(this);
            saveNote = new SaveNoteCommand(this);
            deleteNote = new DeleteNoteCommand(this);

            main.RegisterViewModel(model, this);
            LoadViewModels();
        }

        protected override void LoadViewModels()
        {
            LabelString = string.Join(", ", model.Labels.Select(l => l.Text));
            Labels.Clear();
            foreach (Label label in model.Labels)
            {
                Labels.Add(main.GetViewModel(label));
            }

            //Attachments.Clear();
            //foreach (var attachment in model.Attachments)
            //{
            //    Attachments.Add(main.GetViewModel(attachment));
            //}
        }

        //public ICommand Update
        //{
        //    get { return update; }
        //}

        //public ICommand NewAttachment
        //{
        //    get { return newAttachment; }
        //}

        //public ICommand DeleteAttachment
        //{
        //    get { return deleteAttachment; }
        //}

        public ICommand SaveNote
        {
            get { return saveNote; }
        }

        public ICommand DeleteNote
        {
            get { return deleteNote; }
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

        //public ObservableCollection<AttachmentViewModel> Attachments
        //{
        //    get
        //    {
        //        if (attachments == null)
        //        {
        //            attachments = new ObservableCollection<AttachmentViewModel>();
        //            var itemsView = (IEditableCollectionView)CollectionViewSource.GetDefaultView(attachments);
        //            itemsView.NewItemPlaceholderPosition = NewItemPlaceholderPosition.AtEnd;
        //        }
        //        return attachments;
        //    }
        //}
        
        public void Connect()
        {
            if (Labels.Count == 0)
            {
                if (main.NoLabel.Notes.Count == 0 && !main.Labels.Contains(main.NoLabel))
                    main.Labels.Insert(0, main.NoLabel);
                main.NoLabel.Notes.Add(this);
            }
            else
            {
                foreach (var label in Labels)
                {
                    if (label.Notes.Contains(this) == false)
                        label.Notes.Add(this);
                    if (main.Labels.Contains(label) == false)
                    {
                        main.Labels.Add(label);
                    }
                }
            }
        }

        public void Disconnect()
        {
            if (Labels.Count == 0)
            {
                main.NoLabel.Notes.Remove(this);
                if (main.NoLabel.Notes.Count == 0 && main.Labels.Contains(main.NoLabel))
                    main.Labels.Remove(main.NoLabel);
            }
            else
            {
                foreach (var label in Labels)
                {
                    if (label.Notes.Contains(this))
                        label.Notes.Remove(this);
                    if (label.Notes.Count == 0)
                    {
                        main.Labels.Remove(label);
                    }
                }
            }
        }

        public Note Model
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
            main.UnregisterViewModel(model);
            App.Bll.DeleteNote(model);
        }

        public async void Load()
        {
            Model = await App.Bll.LoadNote(model);
        }

        public async void Save()
        {
            await App.Bll.SaveNote(model);
        }

        internal async void UpdateLabels()
        {
            string[] split = {" ", ",", ";"};
            var labels = LabelString.Split(split, StringSplitOptions.RemoveEmptyEntries);
            Note updated = await App.Bll.UpdateLabels(model, labels);
            ICollection<Note> allnotes = await App.Bll.GetNotes();
            updated = allnotes.Single(n => n.ID == model.ID);
            Disconnect();
            Model = updated;
            Connect();
        }

        //internal async void AddNewAttachment(System.IO.Stream stream, string fileName)
        //{
        //    this.Model = await App.Bll.AddAttachment(model, stream, fileName);
        //}
    }
}
