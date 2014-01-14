using Sheet.BLLService.Entities;
using Sheet.Facade.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheet.BLLService
{
    public partial class BLLService
    {
        private static ICollection<Note> TransformNotes(ICollection<INote> facadeNotes)
        {
            ICollection<Note> result = new List<Note>();
            Dictionary<int, ILabel> facadeLabels = getLabelDictionary(facadeNotes);

            foreach (INote note in facadeNotes)
            {
                result.Add(new Note(note));
            }
            TransformLabels(result, facadeLabels);
            return result;
        }

        private static Note TransformNote(INote facadeNote)
        {
            ICollection<INote> noteCollection = new List<INote>();
            noteCollection.Add(facadeNote);
            return TransformNotes(noteCollection).FirstOrDefault();
        }

        private static void TransformLabels(ICollection<Note> notes, Dictionary<int, ILabel> facadeLabels)
        {
            foreach (ILabel facadeLabel in facadeLabels.Values)
            {
                Label label = new Label(facadeLabel);
                foreach (Note note in notes)
                {
                    if (facadeLabel.Notes.Select(n => n.ID).Contains(note.ID))
                    {
                        if (!label.Notes.Contains(note))
                        {
                            label.Notes.Add(note);
                        }
                        if (!note.Labels.Contains(label))
                        {
                            note.Labels.Add(label);
                        }
                    }
                }
            }
        }

        private static Dictionary<int, ILabel> getLabelDictionary(ICollection<INote> facadeNotes)
        {
            Dictionary<int, ILabel> facadeLabels = new Dictionary<int, ILabel>();
            foreach (INote note in facadeNotes)
            {
                foreach (ILabel label in note.Labels)
                {
                    if (!facadeLabels.ContainsKey(label.ID))
                    {
                        facadeLabels.Add(label.ID, label);
                    }
                }
            }
            return facadeLabels;
        }
    }
}
