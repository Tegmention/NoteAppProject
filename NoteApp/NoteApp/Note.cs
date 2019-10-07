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
    public class Note
    {
        /// <summary>
        /// Поле хранит название заметки
        /// </summary>
        private string _name;
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
        /// Поле хранит категорию заметки 
        /// </summary>
        private NotesCategory _category;
        /// <summary>
        /// Возвращает и задает категорию заметки
        /// </summary>
        public NotesCategory Category
        {
            get { return _category; }
            set
            {
                if (value < NotesCategory.Job || value > NotesCategory.Other)
                {
                    throw new ArgumentException("Значение категории вышло за диапозон возможных значений");
                }
                else { _category = value; }
            }
        }

        /// <summary>
        /// Поле хранит текст заметки
        /// </summary>
        private string _noteText; //Доступно
        /// <summary>
        /// Возвращает и задает текст заметки
        /// </summary>
        public string NoteText
        {
            get { return _noteText; }
            set
            {
                _noteText = value;
            }
        }

        /// <summary>
        /// Поле хранит дату создания заметки
        /// </summary>
        private DateTime _creationTime;
        /// <summary>
        /// Возвращает текст заметки
        /// </summary>
        public DateTime CreationTime
        {
            get { return _creationTime; }
        }

        /// <summary>
        /// Поле хранит дату последнего изменения заметки
        /// </summary>
        private DateTime _lastModTime;
        /// <summary>
        /// Задает и возвращает время последнего изменения заметки
        /// </summary>
        public DateTime LastModTime
        {
            get { return _lastModTime; }
            set
            {
                if(_lastModTime> DateTime.Now)
                {
                    throw new ArgumentException("Дата предыдущего сохранения превышает текущую дату");
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
        public Note(int number)
        {
            _name = "Без названия";
            _category = NotesCategory.Job;
            _noteText = "Текст заметки";
            _creationTime = DateTime.Now;
            _lastModTime = DateTime.Now;
        }
    }
}
