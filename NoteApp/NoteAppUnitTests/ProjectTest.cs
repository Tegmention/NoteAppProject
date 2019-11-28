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

        [Test(Description = "Позитивный тест метода ListSort без входных данных ")]
        public void Test_ListSort()
        {
            var expected = true;
            var actual = false;
            var noteOne = new Note();
            noteOne.CreationTime = DateTime.Parse("30.10.2019 23:59:59");
            noteOne.LastModTime = DateTime.Parse("30.10.2019 23:59:59");
            var noteTwo = new Note();
            noteTwo.CreationTime = DateTime.Parse("25.10.2019 23:59:59");
            noteTwo.LastModTime = DateTime.Parse("25.10.2019 23:59:59");
            var noteThree = new Note();
            noteThree.CreationTime = DateTime.Parse("20.10.2019 23:59:59");
            noteThree.LastModTime = DateTime.Parse("20.10.2019 23:59:59");
            var noteFour = new Note();
            noteFour.CreationTime = DateTime.Parse("15.10.2019 23:59:59");
            noteFour.LastModTime = DateTime.Parse("15.10.2019 23:59:59");
            var noteFive = new Note();
            noteFive.CreationTime = DateTime.Parse("10.10.2019 23:59:59");
            noteFive.LastModTime = DateTime.Parse("10.10.2019 23:59:59");
            _project.Notes.Add(noteTwo);
            _project.Notes.Add(noteThree);
            _project.Notes.Add(noteFive);
            _project.Notes.Add(noteFour);
            _project.Notes.Add(noteOne);

            _project.ListSort();
            if (_project.Notes[0] == noteOne && _project.Notes[1] == noteTwo && 
                _project.Notes[2] == noteThree && _project.Notes[3] == noteFour &&
                _project.Notes[4] == noteFive)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual, "ListSort не возвращает отсортированный по дате модификации список заметок");
        }

        [Test(Description = "Позитивный тест метода ListSort с входным NotesCategory ")]
        public void Test_ListSort_Category()
        {
            var expected = true;
            var actual = false;
            var noteOne = new Note();
            noteOne.Category = NotesCategory.Other;
            var noteTwo = new Note();
            noteTwo.Category = NotesCategory.Finance;
            var noteThree = new Note();
            noteThree.Category = NotesCategory.Other;
            var noteFour = new Note();
            noteFour.Category = NotesCategory.Other;
            var noteFive = new Note();
            noteFive.Category = NotesCategory.House;

            _project.Notes.Add(noteTwo);
            _project.Notes.Add(noteOne);
            _project.Notes.Add(noteThree);
            _project.Notes.Add(noteFive);
            _project.Notes.Add(noteFour);

            _project.Notes = _project.ListSort(NotesCategory.Other);
            var expectedList = new Project();
            expectedList.Notes.Add(noteOne);
            if(_project.Notes[0]==noteOne && _project.Notes[1] == noteThree && _project.Notes[2] == noteFour)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual,"ListSort не возвращает отсортированный по дате модификации список заметок");
        }
    }
}
