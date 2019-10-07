using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace NoteApp
{
    /// <summary>
    /// Статический класс для управления проектом, 
    /// содержит методы сериализации 
    /// и дисериализации
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Путь для хранения файла со списком заметок
        /// </summary>
        private static string FileName = "C:/Users/User/Documents/NoteApp.notes";

        /// <summary>
        /// Статический метод сохранения данных (сиреализации)
        /// </summary>
        /// <param name="List">Список хранящий все заметки</param>
        public static void SaveToFile(List<Note> List)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(FileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, List);
            }
        }

        /// <summary>
        /// Статический метод загрузки данных (дисериализация)
        /// </summary>
        /// <returns>Возвращает список заметок объект List<Note> </returns>
        public static List<Note> LoadFromFile()
        {
            List<Note> List = null;
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(FileName))
            using (JsonReader reader = new JsonTextReader(sr))
            {
               return List = (List<Note>)serializer.Deserialize<List<Note>>(reader);
            }
        }
    }
}
