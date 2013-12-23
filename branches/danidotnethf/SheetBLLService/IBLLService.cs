using Sheet.BLLService.Entities;
using Sheet.Facade.Notes;
using Sheet.Facade.Queries.ComplexQueries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Sheet.BLLService
{
    [ServiceKnownType(typeof(Note))]
    [ServiceKnownType(typeof(Metainfo))]
    [ServiceKnownType(typeof(Label))]
    [ServiceKnownType(typeof(Attachment))]
    [ServiceKnownType(typeof(AttachmentInfo))]
    [ServiceContract]
    public interface IBLLService
    {
        [OperationContract]
        ICollection<Note> GetNotes();
        [OperationContract]
        ICollection<Note> GetNotesByLabel(ILabel label);
        [OperationContract]
        ICollection<Note> SearchNote(string expression);
        [OperationContract]
        ICollection<Note> SearchNoteQuery(ComplexQuery query);
        [OperationContract]
        Note LoadNote(INote note);
        [OperationContract]
        Note UpdateLabels(INote note, IEnumerable<string> labels);
        [OperationContract]
        void AddAttachment(AttachmentInfo attachmentInfo);
        [OperationContract]
        Stream DownloadAttachment(IAttachment attachment);
        [OperationContract]
        Note NewNote();
        [OperationContract]
        void SaveNote(INote note);
        [OperationContract]
        void DeleteNote(INote note);
        [OperationContract]
        void DeleteAttachment(IAttachment attachment);

    }
}
