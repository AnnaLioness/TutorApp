using Microsoft.Extensions.DependencyInjection;

namespace TutorApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Students_Click(object sender, EventArgs e)
        {
            try
            {
                var levelsForm = Program.ServiceProvider.GetRequiredService<FormStudents>();
                levelsForm.Show(); // Открываем модально

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lessons_Click(object sender, EventArgs e)
        {
            try
            {
                var lessonsForm = Program.ServiceProvider.GetRequiredService<FormLessons>();
                lessonsForm.Show(); // Открываем модально

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonMaterials_Click(object sender, EventArgs e)
        {
            try
            {
                var materialsForm = Program.ServiceProvider.GetRequiredService<FormMaterials>();
                materialsForm.Show(); // Открываем модально

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
