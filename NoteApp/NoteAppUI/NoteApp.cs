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
        /// Поле хранит текущий проект приложения
        /// </summary>
        private Project _project = new Project();
        /// <summary>
        /// Поле хранит текущий список заметок(Доп)
        /// </summary>
        private List<Note> _notes = new List<Note>();

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
            _project.ListSort();
            WriteListBox(_project.Notes);
            //Доп
            _notes = _project.Notes;

            NameNotesListBox.SelectedIndex = _project.IndexSelectedNote;
            //При загрузке отображены все категории
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
                //Доп
                var note = _notes[NameNotesListBox.SelectedIndex];

                //Note note = notes[NameNotesListBox.SelectedIndex];
                //Отображаем данные о заметке
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
            //Сохраняем в проект индекс текущей заметки 
            _project.IndexSelectedNote = NameNotesListBox.SelectedIndex;
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
                //Выставлям в начало, чтобы последне измененные были выше
                _project.Notes.Insert(0, NewNote);
                if ((string)CategoryComboBox.SelectedItem == null || (string)CategoryComboBox.SelectedItem == "All")
                {
                    NameNotesListBox.Items.Insert(0, NewNote.Name);
                }
                else
                {
                    var category = (NotesCategory)Enum.Parse(typeof(NotesCategory), (string)CategoryComboBox.SelectedItem);
                    _notes = _project.ListSort(category);
                    NameNotesListBox.Items.Clear();
                    WriteListBox(_notes);
                }
                NameNotesListBox.SelectedIndex = 0;
                //Сохраняем список заметок в файл
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
                //Вызов диалогового окна подтверждения удаления заметки
                var result = MessageBox.Show("Удалить заметку?", "Подтвердите действие", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    var SelectedIndex = NameNotesListBox.SelectedIndex;
                    _project.Notes.Remove(_notes[SelectedIndex]);
                    if ((string)CategoryComboBox.SelectedItem == null || (string)CategoryComboBox.SelectedItem == "All")
                    {
                        NameNotesListBox.Items.RemoveAt(SelectedIndex);
                    }
                    else
                    {
                        var category = (NotesCategory)Enum.Parse(typeof(NotesCategory), (string)CategoryComboBox.SelectedItem);
                        _notes = _project.ListSort(category);
                        NameNotesListBox.Items.Clear();
                        WriteListBox(_notes);
                    }
                    ProjectManager.SaveToFile(_project);
                }
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
                var NewNote = _notes[SelectedIndex].Clone();
                var edit = new EditNote();
                edit.Note = (Note)NewNote;
                var reply = edit.ShowDialog();
                if (reply == DialogResult.OK)
                {
                    _project.Notes.Remove(_notes[SelectedIndex]);
                    _project.Notes.Insert(0, edit.Note);

                    if ((string)CategoryComboBox.SelectedItem == null || (string)CategoryComboBox.SelectedItem == "All")
                    {
                        NameNotesListBox.Items.RemoveAt(SelectedIndex);
                        NameNotesListBox.Items.Insert(0, edit.Note.Name);
                    }
                    else
                    {
                        var category = (NotesCategory)Enum.Parse(typeof(NotesCategory), (string)CategoryComboBox.SelectedItem);
                        _notes = _project.ListSort(category);
                        NameNotesListBox.Items.Clear();
                        WriteListBox(_notes);
                    }
                    NameNotesListBox.SelectedIndex = 0;
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

        /// <summary>
        /// Вызывает удаление заметки при нажатии клавиши Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteApp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && NameNotesListBox.SelectedIndex != -1)
            {
                //Вызов удаления заметки
                RemovePictureBox_Click(sender, e);
            }
        }

        /// <summary>
        /// Запись названий заметок из списка notes в ListBox 
        /// </summary>
        /// <param name="notes"></param>
        private void WriteListBox(List<Note> notes)
        {
            for (var i = 0; i < notes.Count; i++)
            {
                NameNotesListBox.Items.Add(notes[i].Name);
            }
        }

        private void CategoryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            NameNotesListBox.Items.Clear();
            if ((string)CategoryComboBox.SelectedItem == "All")
            {
                WriteListBox(_project.Notes);
                NameNotesListBox.SelectedIndex = -1;
                _notes = _project.Notes;
            }
            else
            {
                //Получаем категорию для сортировки
                var category = (NotesCategory)Enum.Parse(typeof(NotesCategory), (string)CategoryComboBox.SelectedItem);
                _notes = _project.ListSort(category);
                WriteListBox(_notes);
            }
            NameNotesListBox.SelectedIndex = -1;
        }
    }
}
