using Models.Models;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorApp
{
    public partial class FormSubjects : Form
    {
        private readonly DictionaryService _dictionaryService;
        private List<SubjectModel> _subjects = new();
        public FormSubjects(DictionaryService dictionaryService)
        {
            InitializeComponent();
            _dictionaryService = dictionaryService;

            // Настраиваем DataGridView
            SetupDataGridView();

            // Загружаем уровни
            LoadSubjectsAsync();
        }
        private void SetupDataGridView()
        {
            // Настраиваем колонки вручную, так как AutoGenerateColumns может быть включено
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            // Колонка ID (скрытая)
            var idColumn = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            };
            dataGridView.Columns.Add(idColumn);

            // Колонка Название уровня
            var nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "SubjectName",
                DataPropertyName = "SubjectName",
                HeaderText = "Название предмета",
                Width = 300,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridView.Columns.Add(nameColumn);
        }
        private async Task LoadSubjectsAsync()
        {
            _subjects = (await _dictionaryService.GetAllSubjects()).ToList();
            dataGridView.DataSource = _subjects.Select(p => new
            {
                p.SubjectName
            }).ToList();
            ClearInputFields();
        }
        private void ClearInputFields()
        {
            textBox1.Clear();
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            string subjectName = textBox1.Text.Trim();

            await _dictionaryService.CreateSubject(subjectName);
            LoadSubjectsAsync();
        }

        private async void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.Index < 0) return;
            int index = dataGridView.CurrentRow.Index;
            if (index >= _subjects.Count) return;
            var id = _subjects[index].Id;

            string newSubjectName = textBox1.Text.Trim();


            await _dictionaryService.UpdateSubject(id, newSubjectName);
            LoadSubjectsAsync();
        }

        private async void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            int index = dataGridView.CurrentRow.Index;
            if (index >= _subjects.Count) return;

            var id = _subjects[index].Id;

            var result = MessageBox.Show("Удалить выбранный уровень?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                await _dictionaryService.DeleteSubject(id);
                await LoadSubjectsAsync();

            }

        }
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.Index < 0) return;
            int index = dataGridView.CurrentRow.Index;
            if (index >= _subjects.Count) return;

            var selected = _subjects[index];
            textBox1.Text = selected.SubjectName;
        }
    }
}
