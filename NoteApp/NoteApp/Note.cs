using System;
using NoteApp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс заметки, хранящий информацию о 
    /// названии заметки, категории заметки, тексте заметки,
    /// времени создания и времени последнего изменения.
    /// </summary>
    public class Note: ICloneable
    {
        /// <summary>
        /// Поле хранит название заметки
        /// </summary>
        private string _name;

        /// <summary>
        /// Поле хранит категорию заметки 
        /// </summary>
        private NotesCategory _category;

        /// <summary>
        /// Поле хранит дату создания заметки
        /// </summary>
        private DateTime _creationTime;

        /// <summary>
        /// Поле хранит дату последнего изменения заметки
        /// </summary>
        private DateTime _lastModTime;

        /// <summary>
        /// Возвращает и задает название заметки
        /// Длинна имени не больше 50 символов
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длинна названия заметки не должна превышать 50 символов");
                }
                else
                {
                    _name = value.Substring(0,1).ToUpper()+(value.Length>1? value.Substring(1): "");
                }
            }
        }

        /// <summary>
        /// Возвращает и задает категорию заметки
        /// </summary>
        public NotesCategory Category
        {
            get { return _category; }
            set { _category = value; }
        }

        /// <summary>
        /// Возвращает и задает текст заметки
        /// </summary>
        public string NoteText { get; set; }

        /// <summary>
        /// Возвращает текст заметки
        /// </summary>
        public DateTime CreationTime
        {
            get { return _creationTime; }
            set
            {
                _creationTime = value;
            }
        }

        /// <summary>
        /// Задает и возвращает время последнего изменения заметки
        /// </summary>
        public DateTime LastModTime
        {
            get { return _lastModTime; }
            set
            {
                if(value> DateTime.Now)
                {
                    throw new ArgumentException("Дата сохранения превышает текущую дату");
                }
                if(value <_creationTime)
                {
                    throw new ArgumentException("Дата сохранения меньше даты создания заметки");
                }
                else
                {
                    _lastModTime = value;
                }
            }
        }
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="number"></param>
        public Note()
        {
            _name = "Без названия";
            _category = NotesCategory.Job;
            NoteText = "Текст заметки";
            _creationTime = DateTime.Now;
            _lastModTime = DateTime.Now;
        }

        /// <summary>
        /// Метод возващает копию текущего экземпляра объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Note { Name = this.Name, NoteText = this.NoteText,
                Category = this.Category, CreationTime = this.CreationTime,
                LastModTime = this.LastModTime };
        }
    }
}
