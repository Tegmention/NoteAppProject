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
    public class NoteTest
    {
        private Note _note;
        [SetUp]
        public void InitNote()
        {
            _note = new Note();
        }

        [Test(Description = "Позитивный тест сеттера Name")]
        public void Test_Name_Set_CorrectValue()
        {
            var expected = "Заметка №1";
            _note.Name = expected;
            Assert.AreEqual(expected, _note.Name, "Сеттер Name присваивает неправильное название заметки");
        }

        [Test(Description ="Позитивный тест геттера Name")]
        public void Test_Name_Get_CorrectValue()
        {
            var expected = "Заметка №1";
            _note.Name = expected;
            var actual = _note.Name;
            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильное название заметки");
        }

        [Test(Description = "Позитивный тест сеттера Category")]
        public void Test_Category_Set_CorrectValue()
        {
            var expected = NotesCategory.Documentation;
            _note.Category = expected;
            Assert.AreEqual(expected, _note.Category, "Сеттер Category присваивает неправильную категорию заметки");
        }

        [Test(Description = "Позитивный тест геттера Category")]
        public void Test_Category_Get_CorrectValue()
        {
            var expected = NotesCategory.Documentation;
            _note.Category = expected;
            var actual = _note.Category;
            Assert.AreEqual(expected, actual, "Геттер Category возвращает неправильную категорию заметки");
        }

        [Test(Description = "Позитивный тест сеттера NoteText")]
        public void Test_NoteText_Set_CorrectValue()
        {
            var expected = "Текст заметки №1";
            _note.NoteText = expected;
            Assert.AreEqual(expected, _note.NoteText, "Сеттер NoteText присваивает неправильный текст заметки");
        }

        [Test(Description = "Позитивный тест геттера NoteText")]
        public void Test_NoteText_Get_CorrectValue()
        {
            var expected = "Текст новой заметки";
            _note.NoteText = expected;
            var actual = _note.NoteText;
            Assert.AreEqual(expected, actual, "Геттер NoteText возвращает неправильный текст заметки");
        }

        [Test(Description = "Позитивный тест сеттера CreationTime")]
        public void Test_CreationTime_Set_CorrectValue()
        {
            var expected = DateTime.Now;
            _note.CreationTime = expected;
            Assert.AreEqual(expected, _note.CreationTime, "Сеттер CreationTime присваивает неправильное время создания заметки");
        }

        [Test(Description = "Позитивный тест геттера CreationTime")]
        public void Test_CreationTime_Get_CorrectValue()
        {
            var expected = DateTime.Now;
            _note.CreationTime = expected;
            var actual = _note.CreationTime;
            Assert.AreEqual(expected, actual, "Геттер CreationTime возвращает неправильное время создания заметки");
        }

        [Test(Description = "Позитивный тест сеттера LastModTime")]
        public void Test_LastModTime_Set_CorrectValue()
        {
            var expected = DateTime.Now;
            _note.LastModTime = expected;
            Assert.AreEqual(expected, _note.LastModTime, "Сеттер LastModTime присваивает неправильное время изменения заметки");
        }

        [Test(Description = "Позитивный тест геттера LastModTime")]
        public void Test_LastModTime_Get_CorrectValue()
        {
            var expected = DateTime.Now;
            _note.LastModTime = expected;
            var actual = _note.LastModTime;
            Assert.AreEqual(expected, actual, "Геттер LastModTime возвращает неправильное время изменения заметки");
        }

        /// <summary>
        /// Требует доработки
        /// </summary>
        [Test(Description = "Позитивный тест интерфейса ICloneable")]
        public void Test_Interface_ICloneable()
        {
            var expected = true;
            var actual = _note.Equals((Note)_note.Clone());
            Assert.AreEqual(expected, actual, "Метод Clone не возвращает копию заметки");
        }

        [TestCase("31.12.9999 23:59:59", "Должно возникать исключение если, дата сохранения больше текущей даты",
            TestName = "Присвоение даты сохранения больше текущей даты")]
        [TestCase("01.01.0001 00:00:00", "Должно возникать исключение если, дата сохранения меньше даты создания",
            TestName = "Присвоение даты сохранения меньше даты создания")]
        public void TestLastModTimeSet_ArgumentException(string wrongLastModTime, string messege)
        {
            Assert.Throws<ArgumentException>(() => { _note.LastModTime = DateTime.Parse(wrongLastModTime); }, messege);
        }

        [TestCase("Заметка №1Заметка №1Заметка №1Заметка №1Заметка №1Заметка №1",
            "Должно возникать исключение если, название заметки > 50 символов",
            TestName = "Присвоение названия заметки больше 50 символов")]
        [TestCase("", "Должно возникать исключение если, название заметки пустая строка",
            TestName = "Присвоение пустой строки в качестве названия заметки")]
        public void TestName_ArgumentException(string wrongName, string messege)
        {
            Assert.Throws<ArgumentException>(() => { _note.Name = wrongName; }, messege);
        }
    }
}
