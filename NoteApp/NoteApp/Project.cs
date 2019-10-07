using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс проект, содержащий список всех заметок 
    /// с возможностью добавления, удаления,получения заметки по индексу,
    /// очистка, загрузка и сохранение списка из файла
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Поле содержит список всех заметок проекта
        /// </summary>
        private List<Note> _listNotes = new List<Note>();
        /// <summary>
        /// Метод добавления новой заметки в начало списка
        /// </summary>
        /// <param name="NewNote">Принимает новую заметку. Объект класса Note</param>
        public void AddNote(Note NewNote)
        {
            _listNotes.Add(NewNote);
        }
        /// <summary>
        /// Метод для удаления заметки
        /// </summary>
        /// <param name="DeleteNote">Принимает удаляемую заметку. Объект класса Note</param>
        public void RemoveNote(Note DeleteNote)
        {
            _listNotes.Remove(DeleteNote);
        }
        /// <summary>
        /// Метод поиска заметку по индексу
        /// </summary>
        /// <param name="number">Принимает номер заметки в списке</param>
        /// <returns>Возвращает заметку. Объект Note</returns>
        public Note AttNote( int number)
        {
            return _listNotes.ElementAt(number);
        }
        /// <summary>
        /// Метод для очистки списка
        /// </summary>
        public void ClearNote()
        {
            _listNotes.Clear();
        }
        /// <summary>
        /// Метод для сохранения текущего состояния списка в файл
        /// путем сиреализации
        /// </summary>
        public void SaveProject()
        {
            ProjectManager.SaveToFile(_listNotes);
        }
        /// <summary>
        /// Метод для загрузки списка хранящегося в файле
        /// путем дисиреализации
        /// </summary>
        public void LoadProject()
        {
            _listNotes = ProjectManager.LoadFromFile();
        }
    }
}
