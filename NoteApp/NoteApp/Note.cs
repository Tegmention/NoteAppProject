using System;
using NoteApp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Новый комментарий
namespace NoteApp
{
    public class Note
    {
        private string _name;//Доступно
        public string Name
        {
            get { return _name; }
            set
            {
                //1 Буква заглавная, и если нет, делать её заглавной
                //Длинна не больше 50
                _name = value;
            }
        }

        private NotesCategory _category;//Доступно
        public NotesCategory Category
        {
            get { return _category; }
            set
            {
                //На всякий случай проверить, чтобы не вылетало за граници
                _category = value;
            }
        }

        private string _noteText; //Доступно
        public string NoteText
        {
            get { return _noteText; }
            set
            {
                _noteText = value;
            }
        }

        private DateTime _creationTime;
        public DateTime CreationTime
        {
            get { return _creationTime; }
            set
            {
                _creationTime = value;
            }
        }

        private DateTime _lastModTime;
        public DateTime LastModTime
        {
            get { return _lastModTime; }
            set
            {
                //Чтобы время не было раньше предыдущего;
                _lastModTime = value;
            }
        }
    }
}
