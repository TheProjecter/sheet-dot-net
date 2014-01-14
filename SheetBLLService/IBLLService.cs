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
    //[ServiceKnownType(typeof(Attachment))]
    //[ServiceKnownType(typeof(AttachmentInfo))]
    //[ServiceKnownType(typeof(Metainfo))]
    //[ServiceKnownType(typeof(Note))]
    //[ServiceKnownType(typeof(Label))]
    //[ServiceKnownType(typeof(Note[]))]
    //[ServiceKnownType(typeof(Label[]))]
    [ServiceContract]
    public interface IBLLService
    {
        [OperationContract]
        ICollection<Note> GetNotes();
        [OperationContract]
        ICollection<Note> GetNotesByLabel(Label label);
        //[OperationContract]
        //ICollection<Note> SearchNote(string expression);
        //[OperationContract]
        //ICollection<Note> SearchNoteQuery(ComplexQuery query);
        [OperationContract]
        Note LoadNote(Note note);
        [OperationContract]
        Note UpdateLabels(Note note, IEnumerable<string> labels);
        //[OperationContract]
        //void AddAttachment(AttachmentInfo attachmentInfo);
        //[OperationContract]
        //Stream DownloadAttachment(Attachment attachment);
        [OperationContract]
        Note NewNote();
        [OperationContract]
        void SaveNote(Note note);
        [OperationContract]
        void DeleteNote(Note note);
        //[OperationContract]
        //void DeleteAttachment(Attachment attachment);

    }
}
