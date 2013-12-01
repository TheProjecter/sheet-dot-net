using GalaSoft.MvvmLight;
using Sheet.Facade.Notes;
using Sheet.GUI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sheet.GUI.ViewModel
{
    public class AttachmentViewModel : CompositeViewModel
    {
        private IAttachment model;

        private string cache = null;
        private bool real = false;

        private ObservableCollection<MetainfoViewModel> metadata = new ObservableCollection<MetainfoViewModel>();

        private OpenAttachmentCommand openAttachment;
        private SaveAttachmentCommand saveAttachment;

        public AttachmentViewModel(IAttachment model, MainViewModel main) : base(main)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            this.model = model;
            openAttachment = new OpenAttachmentCommand(this);
            saveAttachment = new SaveAttachmentCommand(this);
            main.RegisterViewModel(model, this);
            LoadViewModels();
        }

        protected override void LoadViewModels()
        {
            Metadata.Clear();
            foreach (var metainfo in model.Metadata)
            {
                Metadata.Add(main.GetViewModel(metainfo));
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

        public ICommand OpenAttachment
        {
            get { return openAttachment; }
        }

        public ICommand SaveAttachment
        {
            get { return saveAttachment; }
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

        internal void Delete()
        {
            App.Bll.DeleteAttachment(model);
        }

        internal void Save(string path)
        {
            Stream target = File.Open(path, FileMode.Create);
            Stream data = cache == null && File.Exists(cache) ? App.Bll.DownloadAttachment(model) : File.Open(cache, FileMode.Open);
            data.CopyToAsync(target);
            if (cache != null && !real && File.Exists(cache))
                File.Delete(cache);
            cache = path;
            real = true;
        }

        internal void Open()
        {
            if (cache == null)
            {
                string path = Path.GetTempFileName();
                Stream target = File.Open(path, FileMode.Create);
                Stream data = App.Bll.DownloadAttachment(model);
                data.CopyToAsync(target);
                cache = path;
                real = false;
            }
            try
            {
                Process.Start(cache);
            }
            catch (Exception e)
            {
                SaveAttachment.Execute(null);
            }
        }
    }
}
