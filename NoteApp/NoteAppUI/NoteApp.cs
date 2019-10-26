using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{   /// <summary>
    /// Главная форма приложеня, хранит список заметок
    /// Позволяет просматривать заметки,
    /// вызывать форму для добавления и редактирования заметок,
    /// удалять заметки. 
    /// Реализован вызов методов 2 способами
    /// </summary>
    public partial class NoteApp : Form
    {
        /// <summary>
        /// Поле хранит список заметок приложения
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Иницилизация формы
        /// </summary>
        public NoteApp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загружается список заметок из файла
        /// Через цикл имена заметок переносятся
        /// в ListBox. Указатель устанавливается на 1 
        /// элемент списка ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteApp_Load(object sender, EventArgs e)
        {
            _project = ProjectManager.LoadFromFile();
            for (var i = 0; i < _project.Notes.Count; i++)
            {
                NameNotesListBox.Items.Add(_project.Notes[i].Name);
            }
            NameNotesListBox.SelectedIndex = 0;
            ShowNote();
        }

        /// <summary>
        /// Выводит данные о заметке в главном окне
        /// Если список пуст, то данные не отображаются
        /// </summary>
        /// <param name="note"></param>
        private void ShowNote ()
        {
            if(NameNotesListBox.SelectedIndex == -1)
            {
                TitleNoteLabel.Text = "";
                CategoryNoteLabel.Text = "Category: ";
                CreatedDateTimePicker.Value = DateTime.Now;
                ModifiedDateTimePicker.Value = DateTime.Now;
                TextNoteRichTextBox.Text = "";
            }
            else
            {
                Note note = _project.Notes[NameNotesListBox.SelectedIndex];
                TitleNoteLabel.Text = note.Name;
                CategoryNoteLabel.Text = "Category: " + note.Category;
                CreatedDateTimePicker.Value = note.CreationTime;
                ModifiedDateTimePicker.Value = note.LastModTime;
                TextNoteRichTextBox.Text = note.NoteText;
            }

        }

        /// <summary>
        /// Вызывает отображение даных заметки
        /// при изменении выделенного элемента в ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameNotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowNote();
        }

        /// <summary>
        /// При нажатии на клавишу About в меню
        /// вызывается форма About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.Show();
        }

        /// <summary>
        /// Закрывает форму при нажатии на кнопку Exit
        /// в меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Создает новую заметку и отправляет все данные 
        /// в форму для редактирования.
        /// Если форма была закрыта с результатом 
        /// DialogResult.Ok, то новая заметка добавляется 
        /// в списки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPictureBox_Click(object sender, EventArgs e)
        {
            var NewNote = new Note();
            var edit = new EditNote();
            edit.Note = NewNote;
            var reply = edit.ShowDialog();
            if (reply == DialogResult.OK)
            {
                NewNote = edit.Note;
                _project.Notes.Add(NewNote);
                NameNotesListBox.Items.Add(NewNote.Name);
                ProjectManager.SaveToFile(_project);
            }
        }
       
        /// <summary>
        /// Удаляет заметку из списков по индексу
        /// выделенного элемента в ListBox.
        /// Сохраняет измененный список
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemovePictureBox_Click(object sender, EventArgs e)
        {
            if (NameNotesListBox.Items.Count == 0)
            {
                MessageBox.Show("Список заметок пуст!");
            }
            else
            {
                var SelectedIndex = NameNotesListBox.SelectedIndex;
                NameNotesListBox.Items.RemoveAt(SelectedIndex);
                _project.Notes.RemoveAt(SelectedIndex);
                ProjectManager.SaveToFile(_project);
            }
        }

        /// <summary>
        /// Создает копию выбранной в ListBox заметки
        /// и отправляет ее в форму редактирования.
        /// Получает отредактированные данные и если 
        /// пришел ответ DialogResult.Ok сохраняет новые данные 
        /// в список заметок. Обновляется список ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditPictureBox_Click(object sender, EventArgs e)
        {
            if (NameNotesListBox.Items.Count == 0)
            {
                MessageBox.Show("Список заметок пуст!");
            }
            else
            {
                var SelectedIndex = NameNotesListBox.SelectedIndex;
                var NewNote = _project.Notes[SelectedIndex].Clone();
                var edit = new EditNote();
                edit.Note = (Note)NewNote;
                var reply = edit.ShowDialog();
                if (reply == DialogResult.OK)
                {
                    _project.Notes[SelectedIndex] = edit.Note;
                    NameNotesListBox.Items[SelectedIndex] = edit.Note.Name;
                }
            }
        }

        /// <summary>
        /// Сохраняет список заметок в файл
        /// при закрытии главного окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectManager.SaveToFile(_project);
        }
    }
}
