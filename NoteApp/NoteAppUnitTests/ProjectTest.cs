using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NoteApp;

namespace NoteAppUnitTests
{
    [TestFixture]
    class ProjectTest
    {
        private Project _project;

        [SetUp]
        public void InitNotesAndExpected()
        {
            _project = new Project();
        }

        [Test(Description = "Позитивный тест сеттера Notes")]
        public void Test_Notes_Set_CorrectValue()
        {
            var expected = new List<Note>();
            var note = new Note();
            expected.Add(note);
            _project.Notes = expected;
            Assert.AreEqual(expected, _project.Notes, "Сеттер Notes присваивает неправильный список заметок");
        }

        [Test(Description = "Позитивный тест геттера Notes")]
        public void Test_Notes_Get_CorrectValue()
        {
            var expected = new List<Note>();
            var note = new Note();
            expected.Add(note);
            _project.Notes = expected;
            var actual = _project.Notes;
            Assert.AreEqual(expected, actual, "Геттер Notes возвращает неправильный список заметок");
        }
        [Test(Description = "Позитивный тест сеттера IndexSelectedNote")]
        public void Test_IndexSelectedNote_Set_CorrectValue()
        {
            var expected = 1;
            _project.IndexSelectedNote = expected;
            Assert.AreEqual(expected, _project.IndexSelectedNote, "Сеттер IndexSelectedNote присваивает неправильный индекс текущей заметки");

        }
        [Test(Description = "Позитивный тест геттера IndexSelectedNote")]
        public void Test_IndexSelectedNote_Get_CorrectValue()
        {
            var expected = 1;
            _project.IndexSelectedNote = expected;
            var actual = _project.IndexSelectedNote;
            Assert.AreEqual(expected, actual, "Геттер IndexSelectedNote возвращает неправильный индекс текущей заметки");

        }

    }
}
