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
    }
}
