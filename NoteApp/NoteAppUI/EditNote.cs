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
{
    /// <summary>
    /// Класс формы редактирования заметки,
    /// принимает информацию о заметке,
    /// получает информацию о заметке от пользователя,
    /// отправляет полученные данные по запросу
    /// </summary>
    public partial class EditNote : Form
    {
        /// <summary>
        /// Поле хранит информацию о заметке
        /// </summary>
        private Note _note;

        /// <summary>
        /// Возвращает и задает информацию о заметке
        /// </summary>
        public Note Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }

        /// <summary>
        /// Отображает информацию о заметке при 
        /// загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditNote_Load(object sender, EventArgs e)
        {
            TitleTextBox.Text = _note.Name;
            CategoryComboBox.SelectedItem = _note.Category;
            CategoryComboBox.Text = _note.Category.ToString();
            CreatedNoteDateTimePicker.Value = _note.CreationTime;
            ModifiedNoteDateTimePicker.Value = _note.LastModTime;
            NoteRichTextBox.Text = _note.NoteText;
        }

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public EditNote()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Созраняет заголовок заметки,
        /// при изменении пользователем поля TitleTextBox
        /// и изменяет дату последнего редактирования заметки
        /// Изменяет цвет поля TitleTextBox,
        /// при символов > 50, красный,  
        /// иначе белый
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleTextBox_TextChanged_1(object sender, EventArgs e)
        {   
            _note.Name = TitleTextBox.Text;
            _note.LastModTime = DateTime.Now;
            ///Окрашивает поле TitleTextBox в красный и скрывает кнопку SaveButton если
            ///символов > 50 и < 1
            if (TitleTextBox.Text.Length > 50 || TitleTextBox.Text.Length == 0)
            {
                TitleTextBox.BackColor = Color.Red;
                SaveButton.Visible = false;
                ErrorLable.Visible = true;
            }
            if (TitleTextBox.BackColor == Color.Red & TitleTextBox.Text.Length < 50 & TitleTextBox.Text.Length > 0)
            {
                TitleTextBox.BackColor = Color.White;
                SaveButton.Visible = true;
                ErrorLable.Visible = false;
            }
        }

        /// <summary>
        /// Сохраняет текст заметки при потере 
        /// фокуса полем NoteRichTextBox
        /// и измеяет дату последнего редактирования 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteRichTextBox_Leave(object sender, EventArgs e)
        {
            _note.NoteText = NoteRichTextBox.Text;
            _note.LastModTime = DateTime.Now;
        }

        /// <summary>
        /// Закрывает окно редактирования
        /// и отправляет DialogResult.Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Закрывает форму при клике по 
        /// кнопке Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RevokeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Сохраняет значение категории заметки 
        /// при его изменении и обновляет дату
        /// последнего редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _note.Category = (NotesCategory)Enum.Parse(typeof(NotesCategory),(string)CategoryComboBox.SelectedItem);
            _note.LastModTime = DateTime.Now;
        }
    }
}
