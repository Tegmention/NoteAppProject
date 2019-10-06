using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    public class Project
    {
        private List<Note> ListNotes;
        public void AddNote(Note NewNote)
        {
            ListNotes.Add(NewNote);
        }
        public void RemoveNote(Note DeleteNote)
        {
            ListNotes.Remove(DeleteNote);
        }
        public void LoadList()
        {

        }
        public void SendList()
        {

        }
    }
}
