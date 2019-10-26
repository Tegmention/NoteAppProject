using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NoteApp());
            //Project project = new Project();
            //Note note = new Note();
            //note.Name = "Заметка 1";
            //note.Category = NotesCategory.Documentation;
            //note.NoteText = "Текст 1 заметки";
            //project.Notes.Add(note);
            //note = new Note();
            //note.Name = "Заметка 2";
            //note.Category = NotesCategory.Documentation;
            //note.NoteText = "Текст 2 заметки";
            //project.Notes.Add(note);
            //project.Notes.RemoveAt(0);
            //ProjectManager.SaveToFile(project);
            //project.Notes.Clear();
            //project = ProjectManager.LoadFromFile();
            //MessageBox.Show(project.Notes[0].Name);
            //project.Notes.Clear();
        }
    }
}
