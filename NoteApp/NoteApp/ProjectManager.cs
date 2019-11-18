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
    /// содерж методы сериализации 
    /// и дисериализации
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Путь для хранения файла со списком заметок
        /// </summary>
        //private static string _fileName =
        //    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        //    + @"/NoteApp.notes";

        /// <summary>
        /// Статический метод сохранения данных (сиреализации)
        /// </summary>
        /// <param name="project">Список хранящий все заметки</param>
        public static void SaveToFile(Project project,string fileName)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Статический метод загрузки данных (дисериализация)
        /// </summary>
        /// <returns>Возвращает список заметок объект Project </returns>
        public static Project LoadFromFile(string fileName)
        {
            Project project = null;
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(fileName))
            using (JsonReader reader = new JsonTextReader(sr))
            {
               return project = (Project)serializer.Deserialize<Project>(reader);
            }
        }
    }
}
