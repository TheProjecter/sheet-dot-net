using Sheet.Facade.Queries.ComplexQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.GUI.ViewModel
{
    public class ComplexSearchViewModel : SheetViewModelBase
    {
        private static string[] separators = new string[]{" ", ",", ";"};

        private string titleContains = "";
        private string titleContainsExact = "";
        private string textContains = "";
        private string textContainsExact = "";
        private string labels = "";
        private DateTime before = DateTime.Now;
        private DateTime after = DateTime.Now.Subtract(new TimeSpan(365, 0, 0, 0));
        private bool hasImage;
        private bool hasText;
        private bool hasAudio;
        private bool hasVideo;
        private bool hasAny;
        private string titleContainsAny = "";
        private string textContainsAny = "";
        private string attachmentNames = "";

        public ComplexSearchViewModel(MainViewModel main) : base(main)
        {

        }

        public string TitleContains
        {
            get { return titleContains; }
            set
            {
                if (titleContains == value)
                    return;

                titleContains = value;

                RaisePropertyChanged("TitleContains");
            }
        }

        public string TitleContainsExact
        {
            get { return titleContainsExact; }
            set
            {
                if (titleContainsExact == value)
                    return;

                titleContainsExact = value;

                RaisePropertyChanged("TitleContainsExact");
            }
        }

        public string TitleContainsAny
        {
            get { return titleContainsAny; }
            set
            {
                if (titleContainsAny == value)
                    return;

                titleContainsAny = value;

                RaisePropertyChanged("TitleContainsAny");
            }
        }

        public string TextContains
        {
            get { return textContains; }
            set
            {
                if (textContains == value)
                    return;

                textContains = value;

                RaisePropertyChanged("TextContains");
            }
        }

        public string TextContainsExact
        {
            get { return textContainsExact; }
            set
            {
                if (textContainsExact == value)
                    return;

                textContainsExact = value;

                RaisePropertyChanged("TextContainsExact");
            }
        }

        public string TextContainsAny
        {
            get { return textContainsAny; }
            set
            {
                if (textContainsAny == value)
                    return;

                textContainsAny = value;

                RaisePropertyChanged("TextContainsAny");
            }
        }

        public string Labels
        {
            get { return labels; }
            set
            {
                if (labels == value)
                    return;

                labels = value;

                RaisePropertyChanged("Labels");
            }
        }

        public bool HasImage
        {
            get { return hasImage; }
            set
            {
                if (hasImage == value)
                    return;

                hasImage = value;

                RaisePropertyChanged("HasImage");
            }
        }

        public bool HasText
        {
            get { return hasText; }
            set
            {
                if (hasText == value)
                    return;

                hasText = value;

                RaisePropertyChanged("HasText");
            }
        }

        public bool HasAudio
        {
            get { return hasAudio; }
            set
            {
                if (hasAudio == value)
                    return;

                hasAudio = value;

                RaisePropertyChanged("HasAudio");
            }
        }

        public bool HasVideo
        {
            get { return hasVideo; }
            set
            {
                if (hasVideo == value)
                    return;

                hasVideo = value;

                RaisePropertyChanged("HasVideo");
            }
        }

        public bool HasAny
        {
            get { return hasAny; }
            set
            {
                if (hasAny == value)
                    return;

                hasAny = value;

                RaisePropertyChanged("HasAny");
            }
        }

        public string AttachmentNames
        {
            get { return attachmentNames; }
            set
            {
                if (attachmentNames == value)
                    return;

                attachmentNames = value;

                RaisePropertyChanged("AttachmentNames");
            }
        }

        public DateTime Before
        {
            get { return before; }
            set
            {
                if (before == value)
                    return;

                before = value;

                RaisePropertyChanged("Before");
            }
        }

        public DateTime After
        {
            get { return after; }
            set
            {
                if (after == value)
                    return;

                after = value;

                RaisePropertyChanged("After");
            }
        }

        public async void Search()
        {
            ComplexQuery query = new ComplexQuery();

            List<string> titleQuery = new List<string>(titleContains.Split(separators, StringSplitOptions.RemoveEmptyEntries));
            if (!string.IsNullOrWhiteSpace(titleContainsExact))
                titleQuery.Add(titleContainsExact);
            query.TitleQuery = titleQuery;

            List<string> titleAny = new List<string>(titleContainsAny.Split(separators, StringSplitOptions.RemoveEmptyEntries));
            query.TitleAny = titleAny;

            List<string> textQuery = new List<string>(textContains.Split(separators, StringSplitOptions.RemoveEmptyEntries));
            if (!string.IsNullOrWhiteSpace(textContainsExact))
                textQuery.Add(textContainsExact);
            query.TextQuery = textQuery;

            List<string> textAny = new List<string>(textContainsAny.Split(separators, StringSplitOptions.RemoveEmptyEntries));
            query.TextAny = textAny;

            List<string> labelQuery = new List<string>(labels.Split(separators, StringSplitOptions.RemoveEmptyEntries));
            query.LabelQuery = labelQuery;

            query.Before = before;
            query.After = after;

            query.HasAttachment = hasAny;

            if (hasAny)
            {
                List<ContentType> attachmentOfType = new List<ContentType>();
                if (hasText)
                    attachmentOfType.Add(ContentType.Text);
                if (hasImage)
                    attachmentOfType.Add(ContentType.Image);
                if (hasAudio)
                    attachmentOfType.Add(ContentType.Audio);
                if (hasVideo)
                    attachmentOfType.Add(ContentType.Video);
                query.AttachmentOfType = attachmentOfType;

                query.AttachmentNameQuery = new List<string>(this.attachmentNames.Split(separators, StringSplitOptions.RemoveEmptyEntries));
            }

            var results = await App.Bll.SearchNote(query);
            main.SearchResultsVisibility = System.Windows.Visibility.Visible;
            main.SearchResults.Clear();
            foreach (var note in results)
            {
                main.SearchResults.Add(main.GetViewModel(note));
            }
        }
    }
}
