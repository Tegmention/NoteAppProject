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
        public List<Note> Notes //2 теста
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
        public int IndexSelectedNote //2 теста
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

        /// <summary>
        /// Сортирует список по дате последнего изменения
        /// </summary>
        public void ListSort() //1 тест
        {
            NoteComparer sort = new NoteComparer();
            _notes.Sort(sort);
        }
        /// <summary>
        /// Возвращает часть списка _notes соответствующей категории
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<Note> ListSort(NotesCategory category) //1тест
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
