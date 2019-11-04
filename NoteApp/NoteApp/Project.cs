using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс проект, содержащий список всех заметок 
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Поле содержит список всех заметок проекта
        /// </summary>
        private List<Note> _notes = new List<Note>();
        private int _indexSelectedNote;

        /// <summary>
        /// Возвращает и задает список заметок
        /// </summary>
        public List<Note> Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }
               
        }

        /// <summary>
        /// Возвращает и задает индекс текущей заметки
        /// </summary>
        public int IndexSelectedNote
        {
            get
            {
                return _indexSelectedNote;
            }
            set 
            {
                _indexSelectedNote = value;
            }
        }

        public void ListSort()
        {
            NoteComparer sort = new NoteComparer();
            _notes.Sort(sort);
        }
        public List<Note> ListSort(NotesCategory category)
        {
            return _notes.FindAll(
                delegate (Note note)
                {
                    return note.Category == category;
                }
                );
        }
    }
}
