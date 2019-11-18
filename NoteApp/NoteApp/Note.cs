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
    public class Note : ICloneable
    {
        /// <summary>
        /// Поле хранит название заметки
        /// </summary>
        private string _name;

        /// <summary>
        /// Поле хранит текст заметки
        /// </summary>
        private string _noteText;

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
        public string Name //4 теста
        {
            get { return _name; } //1 тест
            set
            {
                if (value.Length > 50)// 1 тест
                {
                    throw new ArgumentException("Длинна названия заметки не должна превышать 50 символов");
                }
                else
                {
                    if (value.Length != 0)//1 тест
                    {
                        _name = value.Substring(0, 1).ToUpper() + (value.Length > 1 ? value.Substring(1) : "");
                    }
                    else//1 тест
                    {
                        throw new ArgumentException("Длинна названия заметки не должна ровнятся 0 символов");
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает и задает категорию заметки
        /// </summary>
        public NotesCategory Category //2 теста
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        } 

        /// <summary>
        /// Возвращает и задает текст заметки
        /// </summary>
        public string NoteText //2 теста
        {
            get
            {
                return _noteText;
            }
            set
            {
                _noteText = value;
            }
        } 

        /// <summary>
        /// Задает и возвращает время время создания заметки
        /// </summary>
        public DateTime CreationTime //2 теста
        {
            get
            {
                return _creationTime;
            }
            set
            {
                _creationTime = value;
            }
        }

        /// <summary>
        /// Задает и возвращает время последнего изменения заметки
        /// </summary>
        public DateTime LastModTime //4 теста
        {
            get { return _lastModTime; } //1 тест
            set
            {
                if(value> DateTime.Now) //1 тест
                {
                    throw new ArgumentException("Дата сохранения превышает текущую дату");
                }
                if(value <_creationTime) //1 тест
                {
                    throw new ArgumentException("Дата сохранения меньше даты создания заметки");

                }
                else //1 тест
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
            _noteText = "Текст заметки";
            _creationTime = DateTime.Now;
            _lastModTime = DateTime.Now;
        }

        /// <summary>
        /// Метод возвращает копию текущего экземпляра объекта
        /// </summary>
        /// <returns></returns>
        public object Clone() //1 тест
        {
            return new Note { Name = this.Name, NoteText = this.NoteText,
                Category = this.Category, CreationTime = this.CreationTime,
                LastModTime = this.LastModTime };
        }
    }
}
