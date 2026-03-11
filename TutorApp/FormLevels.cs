using Models.Models;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TutorApp
{
    public partial class FormLevels : Form
    {
        private readonly DictionaryService _dictionaryService;
        private List<LevelModel> _levels = new();
        public FormLevels(DictionaryService dictionaryService)
        {
            InitializeComponent();
            _dictionaryService = dictionaryService;

            // Настраиваем DataGridView
            SetupDataGridView();

            // Загружаем уровни
            LoadLevelsAsync();

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
                Name = "LevelName",
                DataPropertyName = "LevelName",
                HeaderText = "Название уровня",
                Width = 300,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridView.Columns.Add(nameColumn);

        }

        private async Task LoadLevelsAsync()
        {
            _levels = (await _dictionaryService.GetAllLevels()).ToList();
            dataGridView.DataSource = _levels.Select(p => new
            {
                p.LevelName
            }).ToList();
            ClearInputFields();
        }


        private void ClearInputFields()
        {
            textBox1.Clear();
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            string levelName = textBox1.Text.Trim();

            await _dictionaryService.CreateLevel(levelName);
            LoadLevelsAsync();
        }

        private async void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.Index < 0) return;
            int index = dataGridView.CurrentRow.Index;
            if (index >= _levels.Count) return;
            var id = _levels[index].Id;

            string newLevelName = textBox1.Text.Trim();


            await _dictionaryService.UpdateLevel(id, newLevelName);
            LoadLevelsAsync();
        }

        private async void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            int index = dataGridView.CurrentRow.Index;
            if (index >= _levels.Count) return;

            var id = _levels[index].Id;

            var result = MessageBox.Show("Удалить выбранный уровень?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                await _dictionaryService.DeleteLevel(id);
                await LoadLevelsAsync();

            }
          
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.Index < 0) return;
            int index = dataGridView.CurrentRow.Index;
            if (index >= _levels.Count) return;

            var selected = _levels[index];
            textBox1.Text = selected.LevelName;
        }
    }
}
