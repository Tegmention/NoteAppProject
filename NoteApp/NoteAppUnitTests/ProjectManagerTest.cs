using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NoteApp;
using Newtonsoft.Json;
using System.IO;


namespace NoteAppUnitTests
{
    [TestFixture]
    class ProjectManagerTest
    {

        private string _fileName = "../../../source/repos/NoteAppProject/NoteApp/NoteAppUnitTests/Resources/Expected.json";
        Project _project = new Project();
        [SetUp]
        public void InitNote()
        {
            _project.Notes.Clear();
            Note note = new Note();

            note.Name = "Заметка №1";
            note.Category = NotesCategory.Job;
            note.NoteText = "Текст заметки";
            note.CreationTime = DateTime.Parse("2019-11-15T13:58:56.7936768+03:00");
            note.LastModTime = DateTime.Parse("2019-11-15T13:59:38.0189603+03:00");

            Note note1 = new Note();
            note1.Name = "Заметка №2";
            note1.Category = NotesCategory.HealthAndSport;
            note1.NoteText = "Текст заметки";
            note1.CreationTime = DateTime.Parse("2019-11-15T13:59:12.7772289+03:00");
            note1.LastModTime = DateTime.Parse("2019-11-15T14:00:05.550012+03:00");

            Note note2 = new Note();

            note2.Name = "Заметка №3";
            note2.Category = NotesCategory.Finance;
            note2.NoteText = "Текст заметки";
            note2.CreationTime = DateTime.Parse("2019-11-15T13:59:23.705611+03:00");
            note2.LastModTime = DateTime.Parse("2019-11-15T14:00:18.5377638+03:00");

            _project.Notes.Add(note2);
            _project.Notes.Add(note1);
            _project.Notes.Add(note);

            _project.IndexSelectedNote = 2;
        }

        [Test(Description = "Позитивный тест метода дисериализации")]
        public void Test_LoadFromFile()
        {
            var expected = true; ;
            var actual = false;

            Project loadProject = ProjectManager.LoadFromFile(_fileName);

            for (var numberNote = 2; numberNote > -1; numberNote--)
            {
                if (
                    loadProject.Notes[numberNote].Name == _project.Notes[numberNote].Name &&
                    loadProject.Notes[numberNote].NoteText == _project.Notes[numberNote].NoteText &&
                    loadProject.Notes[numberNote].CreationTime == _project.Notes[numberNote].CreationTime &&
                    loadProject.Notes[numberNote].LastModTime == _project.Notes[numberNote].LastModTime &&
                    loadProject.Notes[numberNote].Category == _project.Notes[numberNote].Category
                )
                {
                    actual = true;
                }
            }
            Assert.AreEqual(expected, actual, "Метод не производит дисериализацию");
        }

        [Test(Description = "Позитивный тест метода сериализации")]
        public void Test_SaveToFile()
        {
            File.Delete("actualProject.json");

            ProjectManager.SaveToFile(_project, "actualProject.json");
            var actual = File.ReadAllText("actualProject.json");
            var expected = File.ReadAllText(_fileName);
            Assert.AreEqual(expected, actual, "Метод не производит сериализацию");
        }
    }
}
