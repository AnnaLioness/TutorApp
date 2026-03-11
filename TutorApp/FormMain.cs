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
    }
}
