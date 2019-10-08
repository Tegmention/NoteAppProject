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
            Application.Run(new Form1());
            Note note = new Note();
            Project project = new Project();
            project.Notes.Add(note);
            note = new Note();
            project.Notes.Add(note);
            ProjectManager.SaveToFile(project);
            //project.ClearNote();
            //project.LoadProject();
            //Console.WriteLine(project.AttNote(0).Name);
            //MessageBox.Show(project.AttNote(0).Name);
            project.Notes.Clear();
        }
    }
}
