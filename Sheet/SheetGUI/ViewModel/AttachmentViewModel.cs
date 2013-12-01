using GalaSoft.MvvmLight;
using OSIcon.WinAPI;
using Sheet.Facade.Notes;
using Sheet.GUI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Sheet.GUI.ViewModel
{
    public class AttachmentViewModel : CompositeViewModel
    {
        private IAttachment model;

        private Icon thumbnail = null;

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

        public ImageSource Thumbnail
        {
            get
            {
                if (thumbnail == null)
                {
                    OSIcon.WinAPI.Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
                    thumbnail = OSIcon.IconReader.GetFileIcon(Path.GetExtension(model.Name), OSIcon.IconReader.IconSize.Jumbo, false, ref shfi);
                }
                return thumbnail.ToImageSource();
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

        internal async void Delete()
        {
            await Task.Run(() => App.Bll.DeleteAttachment(model));
        }

        internal async void Save(string path)
        {
            using (Stream target = File.Open(path, FileMode.Create))
            using (Stream data = cache == null || !File.Exists(cache) ? App.Bll.DownloadAttachment(model) : File.Open(cache, FileMode.Open))
            {
                await data.CopyToAsync(target);
            }
            if (cache != null && !real && File.Exists(cache))
                File.Delete(cache);
            cache = path;
            real = true;
        }

        internal async void Open()
        {
            if (cache == null)
            {
                string path = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(model.Name));
                using (Stream target = File.Open(path, FileMode.Create))
                using (Stream data = App.Bll.DownloadAttachment(model))
                {
                    await data.CopyToAsync(target);
                }
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
