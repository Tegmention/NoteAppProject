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
        private List<Note> _notes;
        private List<Note> _expectedNotes;

        [SetUp]
        public void InitNotesAndExpected()
        {
            _notes = new List<Note>();

            var notes = new List<Note>();
            var note = new Note();
            notes.Add(note);
            _expectedNotes = notes;

        }

        [Test(Description = "Позитивный тест сеттера Notes")]
        public void Test_Notes_Set_CorrectValue()
        {
            _notes = _expectedNotes;
            Assert.AreEqual(_expectedNotes, _notes, "Сеттер Notes присваивает неправильный список заметок");
        }

        [Test(Description = "Позитивный тест геттера Notes")]
        public void Test_Notes_Get_CorrectValue()
        {
            _notes = _expectedNotes;
            var actual = _notes;
            Assert.AreEqual(_expectedNotes, actual, "Геттер Notes возвращает неправильный список заметок");
        }
    }
}
