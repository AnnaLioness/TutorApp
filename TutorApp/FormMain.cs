using Microsoft.Extensions.DependencyInjection;

namespace TutorApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            // Создаем свою панель-шапку
            Panel titleBar = new Panel();
            titleBar.Height = 40;
            titleBar.Dock = DockStyle.Top;
            titleBar.BackColor = Color.RoyalBlue; // Ваш цвет


            // Добавляем кнопку закрытия
            Button closeBtn = new Button();
            closeBtn.Text = "X";
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.BackColor = Color.Transparent;
            closeBtn.ForeColor = Color.White;
            closeBtn.Size = new Size(40, 40);
            closeBtn.Dock = DockStyle.Right;
            closeBtn.Click += (s, e) => this.Close();

            // Добавляем заголовок
            Label titleLabel = new Label();
            titleLabel.Text = this.Text;
            titleLabel.ForeColor = Color.White;
            titleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            titleLabel.Location = new Point(10, 10);
            titleLabel.AutoSize = true;

            // Добавляем возможность перетаскивать окно
            bool dragging = false;
            Point startPoint = Point.Empty;

            titleBar.MouseDown += (s, e) => {
                dragging = true;
                startPoint = new Point(e.X, e.Y);
            };

            titleBar.MouseMove += (s, e) => {
                if (dragging)
                {
                    Point p = PointToScreen(e.Location);
                    this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
                }
            };
 
           

        titleBar.MouseUp += (s, e) => dragging = false;

            titleBar.Controls.Add(closeBtn);
            titleBar.Controls.Add(titleLabel);
            this.Controls.Add(titleBar);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Рисуем рамку вокруг формы
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                using (Pen pen = new Pen(Color.RoyalBlue, 5))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                }
            }
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

        private void ButtonReport_Click(object sender, EventArgs e)
        {
            try
            {
                var reportForm = Program.ServiceProvider.GetRequiredService<FormReport>();
                reportForm.Show(); // Открываем модально

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonVkSettings_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<FormVkSetup>())
            {
                form.ShowDialog();
            }
        }

        private void ButtonPublications_Click(object sender, EventArgs e)
        {
            try
            {
                var publForm = Program.ServiceProvider.GetRequiredService<FormPublications>();
                publForm.Show(); // Открываем модально

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
