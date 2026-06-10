using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FlaUI.Core;
using Xunit;
using App = FlaUI.Core.Application;
using FlaButton = FlaUI.Core.AutomationElements.Button;

namespace TestProject
{
    public class UiNavigationTests : IDisposable
    {
        private readonly App _app;
        private readonly UIA3Automation _automation;
        private readonly Window _mainWindow;

        public UiNavigationTests()
        {
            // Путь к твоему приложению
            var projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent;
            var appPath = Path.Combine(projectDir.FullName, "TutorApp", "bin", "Debug", "net8.0-windows", "TutorApp.exe");

            if (!File.Exists(appPath))
                throw new FileNotFoundException($"Не найден файл приложения: {appPath}");

            _app = App.Launch(appPath);
            _automation = new UIA3Automation();
            _mainWindow = _app.GetMainWindow(_automation);
            Thread.Sleep(3000);
        }

        private FlaButton GetButton(string automationId)
        {
            var button = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(automationId))?.AsButton();
            if (button == null)
                throw new Exception($"Кнопка с ID '{automationId}' не найдена.");
            return button;
        }

        // Вспомогательный метод для поиска окна по заголовку
        private Window FindWindowByTitle(string title)
        {
            var desktop = _automation.GetDesktop();
            // Упрощённый поиск — ищем все окна, потом фильтруем
            var allWindows = desktop.FindAllDescendants(cf => cf.ByControlType(FlaUI.Core.Definitions.ControlType.Window));
            foreach (var element in allWindows)
            {
                var window = element.AsWindow();
                if (window.Title == title)
                    return window;
            }
            return null;
        }

        [Fact]
        public void Test_Открыть_Ученики()
        {
            var button = GetButton("Students");
            button.Click();
            Thread.Sleep(2000);

            var childWindow = FindWindowByTitle("Ученики");
            Assert.NotNull(childWindow);
        }

        [Fact]
        public void Test_Открыть_Уроки()
        {
            var button = GetButton("Lessons");
            button.Click();
            Thread.Sleep(2000);

            var childWindow = FindWindowByTitle("Уроки");
            Assert.NotNull(childWindow);
        }

        [Fact]
        public void Test_Открыть_Материалы()
        {
            var button = GetButton("ButtonMaterials");
            button.Click();
            Thread.Sleep(2000);

            var childWindow = FindWindowByTitle("Материалы");
            Assert.NotNull(childWindow);
        }

        [Fact]
        public void Test_Открыть_Отчёт()
        {
            var button = GetButton("ButtonReport");
            button.Click();
            Thread.Sleep(2000);
        }

        [Fact]
        public void Test_Открыть_Публикации()
        {
            var button = GetButton("ButtonPublications");
            button.Click();
            Thread.Sleep(2000);

            var childWindow = FindWindowByTitle("Управление публикациями");
            Assert.NotNull(childWindow);
        }

        [Fact]
        public void Test_Открыть_НастройкиVK()
        {
            var button = GetButton("ButtonVkSettings");
            button.Click();
            Thread.Sleep(2000);

            var childWindow = FindWindowByTitle("Настройка ВКонтакте");
            Assert.NotNull(childWindow);
        }
        [Fact]
        public void Test_Ученики_Открыть_Форму_Добавления()
        {
            // Открываем форму учеников
            var studentsButton = GetButton("Students");
            studentsButton.Click();
            Thread.Sleep(2000);

            var studentsWindow = FindWindowByTitle("Ученики");
            Assert.NotNull(studentsWindow);

            // Находим кнопку "Добавить ученика"
            var addButton = studentsWindow.FindFirstDescendant(cf => cf.ByAutomationId("ButtonAdd"))?.AsButton();
            Assert.NotNull(addButton);

            addButton.Click();
            Thread.Sleep(2000);

            // Проверяем, что открылась форма добавления ученика (заголовок "Ученик")
            var studentEditWindow = FindWindowByTitle("Ученик");
            Assert.NotNull(studentEditWindow);
        }
        [Fact]
        public void Test_Ученики_Добавить_Открыть_Форму_Уровней()
        {
            // 1. Открываем форму учеников
            var studentsButton = GetButton("Students");
            studentsButton.Click();
            Thread.Sleep(2000);

            var studentsWindow = FindWindowByTitle("Ученики");
            Assert.NotNull(studentsWindow);

            // 2. Нажимаем кнопку "Добавить ученика"
            var addButton = studentsWindow.FindFirstDescendant(cf => cf.ByAutomationId("ButtonAdd"))?.AsButton();
            Assert.NotNull(addButton);
            addButton.Click();
            Thread.Sleep(2000);

            // 3. Проверяем, что открылась форма ученика
            var studentWindow = FindWindowByTitle("Ученик");
            Assert.NotNull(studentWindow);

            // 4. На форме ученика находим кнопку "Добавить новый уровень ученика"
            var addLevelButton = studentWindow.FindFirstDescendant(cf => cf.ByAutomationId("ButtonAddLevel"))?.AsButton();
            Assert.NotNull(addLevelButton);
            addLevelButton.Click();
            Thread.Sleep(2000);

            // 5. Проверяем, что открылась форма уровней
            var levelWindow = FindWindowByTitle("Уровни владения и сложности");
            Assert.NotNull(levelWindow);
        }
        [Fact]
        public void Test_Материалы_Открыть_Форму_Добавления()
        {
            // Открываем форму Материалов
            var studentsButton = GetButton("ButtonMaterials");
            studentsButton.Click();
            Thread.Sleep(2000);

            var studentsWindow = FindWindowByTitle("Материалы");
            Assert.NotNull(studentsWindow);

            // Находим кнопку "Добавить Материал"
            var addButton = studentsWindow.FindFirstDescendant(cf => cf.ByAutomationId("ButtonAdd"))?.AsButton();
            Assert.NotNull(addButton);

            addButton.Click();
            Thread.Sleep(2000);

            // Проверяем, что открылась форма добавления Материала (заголовок "Материал")
            var studentEditWindow = FindWindowByTitle("Материал");
            Assert.NotNull(studentEditWindow);
        }
        [Fact]
        public void Test_Уроки_Добавить_Открыть_Форму_Направлений_Предметов()
        {
            // 1. Открываем форму учеников
            var studentsButton = GetButton("Lessons");
            studentsButton.Click();
            Thread.Sleep(2000);

            var studentsWindow = FindWindowByTitle("Уроки");
            Assert.NotNull(studentsWindow);

            // 2. Нажимаем кнопку "Добавить ученика"
            var addButton = studentsWindow.FindFirstDescendant(cf => cf.ByAutomationId("ButtonAdd"))?.AsButton();
            Assert.NotNull(addButton);
            addButton.Click();
            Thread.Sleep(2000);

            // 3. Проверяем, что открылась форма ученика
            var studentWindow = FindWindowByTitle("Урок");
            Assert.NotNull(studentWindow);

            // 4. На форме ученика находим кнопку "Добавить новый уровень ученика"
            var addLevelButton = studentWindow.FindFirstDescendant(cf => cf.ByAutomationId("ButtonAddType"))?.AsButton();
            Assert.NotNull(addLevelButton);
            addLevelButton.Click();
            Thread.Sleep(2000);

            // 5. Проверяем, что открылась форма уровней
            var levelWindow = FindWindowByTitle("Направления");
            Assert.NotNull(levelWindow);

            var addSubButton = levelWindow.FindFirstDescendant(cf => cf.ByAutomationId("ButtonAddSubj"))?.AsButton();
            Assert.NotNull(addSubButton);
            addSubButton.Click();
            Thread.Sleep(2000);

            // 5. Проверяем, что открылась форма уровней
            var subjWindow = FindWindowByTitle("Предметы");
            Assert.NotNull(subjWindow);
        }
        [Fact]
        public void Test_Материалы_Добавить_Открыть_Форму_Уровней()
        {
            // Открываем форму Материалов
            var studentsButton = GetButton("ButtonMaterials");
            studentsButton.Click();
            Thread.Sleep(2000);

            var studentsWindow = FindWindowByTitle("Материалы");
            Assert.NotNull(studentsWindow);

            // Находим кнопку "Добавить Материал"
            var addButton = studentsWindow.FindFirstDescendant(cf => cf.ByAutomationId("ButtonAdd"))?.AsButton();
            Assert.NotNull(addButton);

            addButton.Click();
            Thread.Sleep(2000);

            // Проверяем, что открылась форма добавления Материала (заголовок "Материал")
            var studentEditWindow = FindWindowByTitle("Материал");
            Assert.NotNull(studentEditWindow);

            // 4. На форме ученика находим кнопку "Добавить новый уровень ученика"
            var addLevelButton = studentEditWindow.FindFirstDescendant(cf => cf.ByAutomationId("ButtonAddLevel"))?.AsButton();
            Assert.NotNull(addLevelButton);
            addLevelButton.Click();
            Thread.Sleep(2000);

            // 5. Проверяем, что открылась форма уровней
            var levelWindow = FindWindowByTitle("Уровни владения и сложности");
            Assert.NotNull(levelWindow);
        }
        [Fact]
        public void Test_Материалы_Добавить_Открыть_Форму_Направлений_Предметов()
        {
            // Открываем форму Материалов
            var studentsButton = GetButton("ButtonMaterials");
            studentsButton.Click();
            Thread.Sleep(2000);

            var studentsWindow = FindWindowByTitle("Материалы");
            Assert.NotNull(studentsWindow);

            // Находим кнопку "Добавить Материал"
            var addButton = studentsWindow.FindFirstDescendant(cf => cf.ByAutomationId("ButtonAdd"))?.AsButton();
            Assert.NotNull(addButton);

            addButton.Click();
            Thread.Sleep(2000);

            // Проверяем, что открылась форма добавления Материала (заголовок "Материал")
            var studentEditWindow = FindWindowByTitle("Материал");
            Assert.NotNull(studentEditWindow);

            // 4. На форме ученика находим кнопку "Добавить новый уровень ученика"
            var addLevelButton = studentEditWindow.FindFirstDescendant(cf => cf.ByAutomationId("ButtonAddType"))?.AsButton();
            Assert.NotNull(addLevelButton);
            addLevelButton.Click();
            Thread.Sleep(2000);

            // 5. Проверяем, что открылась форма уровней
            var levelWindow = FindWindowByTitle("Направления");
            Assert.NotNull(levelWindow);

            var addSubButton = levelWindow.FindFirstDescendant(cf => cf.ByAutomationId("ButtonAddSubj"))?.AsButton();
            Assert.NotNull(addSubButton);
            addSubButton.Click();
            Thread.Sleep(2000);

            // 5. Проверяем, что открылась форма уровней
            var subjWindow = FindWindowByTitle("Предметы");
            Assert.NotNull(subjWindow);
        }

        public void Dispose()
        {
            _app?.Close();
            _automation?.Dispose();
        }
    }
}