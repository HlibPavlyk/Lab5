using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Media;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;

namespace Lab5
{
    public delegate void ChangedEventHandler();
    public delegate void SelectEventHandler(int shapeNumber);

    public partial class Lab5 : Form
    {

        private ToolStripMenuItem selectedMenuItem = null;
        private ToolStripMenuItem selectedTableWorkMenu = null;
        private ToolStripButton selectedToolButton = null;
        string currentFilePath = null;
        ShapeObjectsEditor shapeObjectsEditor;
        Table tableWindow;

        public Lab5()
        {
            InitializeComponent();
            tableWindow = new Table();
            shapeObjectsEditor = ShapeObjectsEditor.Instance;

            shapeObjectsEditor.ShapesChangedEvent += ChangeTableInfo;
            tableWindow.DataGridViewRowSelectedEvent += ShowSelected;
            tableWindow.DataGridViewRowUnselectedEvent += HideSelected;
            tableWindow.DataGridViewRowDeleteEvent += DeleteSelected;

            shapeObjectsEditor.SetCurrentShape = new PointShape(Point.Empty);
            IfMenuItemSelected(pointToolStripMenuItem, toolStripButtonPoint);

            IfMenuTableWorkSelected(selectShapeToolStripMenuItem);
            tableWindow.IsWorkTypeSelection = true;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            shapeObjectsEditor.OnLeftButtonDown(sender, e);
            Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            shapeObjectsEditor.OnLeftButtonUp(sender, e);
            Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            shapeObjectsEditor.OnMouseMove(sender, e);
            if (e.Button == MouseButtons.Left)
                Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            shapeObjectsEditor.OnPaint(sender, e);
        }

        private void СlearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeObjectsEditor.OnClear();
            Refresh();
        }

        private void stepBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeObjectsEditor.OnStepBack(sender, e);
            Refresh();
        }

        private void stepForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeObjectsEditor.OnStepForward(sender, e);
            Refresh();
        }

        private void pointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeObjectsEditor.SetCurrentShape = new PointShape(Point.Empty);
            shapeObjectsEditor.SetCurrentRubberShape = null;
            IfMenuItemSelected(pointToolStripMenuItem, toolStripButtonPoint);
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeObjectsEditor.SetCurrentShape = new LineShape(Point.Empty, Point.Empty);
            shapeObjectsEditor.SetCurrentRubberShape =
                new LineShape(Point.Empty, Point.Empty, penStyle: DashStyle.Dash);
            IfMenuItemSelected(lineToolStripMenuItem, toolStripButtonLine);
        }

        private void rectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeObjectsEditor.SetCurrentShape = new RectShape(Point.Empty, Point.Empty);
            shapeObjectsEditor.SetCurrentRubberShape =
                new RectShape(Point.Empty, Point.Empty, penStyle: DashStyle.Dash);
            IfMenuItemSelected(rectToolStripMenuItem, toolStripButtonRect);
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeObjectsEditor.SetCurrentShape =
                new EllipseShape(Point.Empty, Point.Empty, fillColor: Color.Gray);
            shapeObjectsEditor.SetCurrentRubberShape =
                new EllipseShape(Point.Empty, Point.Empty, penStyle: DashStyle.Dash);
            IfMenuItemSelected(ellipseToolStripMenuItem, toolStripButtonEllipse);
        }
        private void CubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeObjectsEditor.SetCurrentShape = new CubeShape(Point.Empty, Point.Empty);
            shapeObjectsEditor.SetCurrentRubberShape =
                new CubeShape(Point.Empty, Point.Empty, penStyle: DashStyle.Dash);
            IfMenuItemSelected(cubeToolStripMenuItem, toolStripButtonCube);
        }

        private void LineOOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeObjectsEditor.SetCurrentShape = new LineOOShape(Point.Empty, Point.Empty);
            shapeObjectsEditor.SetCurrentRubberShape =
                new LineOOShape(Point.Empty, Point.Empty, penStyle: DashStyle.Dash);
            IfMenuItemSelected(lineOOToolStripMenuItem, toolStripButtonLineOO);
        }

        private void selectShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IfMenuTableWorkSelected(selectShapeToolStripMenuItem);
            tableWindow.IsWorkTypeSelection = true;
        }

        private void deleteShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IfMenuTableWorkSelected(deleteShapeToolStripMenuItem);
            tableWindow.IsWorkTypeSelection = false;
        }

        private void saveCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFilePath == null)
                saveToTextFileToolStripMenuItem_Click(sender, e);
            else
                tableWindow.SaveToTextFile(currentFilePath);

        }

        private void openTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableWindow.Show();
        }

        private void closeTableStripMenuItem_Click(object sender, EventArgs e)
        {
            tableWindow.Hide();
        }

        private void saveToTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    if (!Path.GetExtension(filePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        filePath = Path.ChangeExtension(filePath, ".txt");
                    }
                    currentFilePath = filePath;
                    tableWindow.SaveToTextFile(filePath);
                }
            }
        }

        private void readFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстові файли (*.txt)|*.txt";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    if (Path.GetExtension(filePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        currentFilePath = filePath;
                        LoadFromTextFile(filePath);
                    }
                    else
                    {
                        MessageBox.Show("Вибрано непідтримане розширення файлу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadFromTextFile(string filePath)
        {
            shapeObjectsEditor.OnClear();
            try
            {
                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    if (reader.Peek() == -1)
                        throw new FormatException("Неправильний формат файлу: файл пустий");

                    while (!reader.EndOfStream)
                    {
                        Point startPoint = Point.Empty;
                        Point endPoint = Point.Empty;

                        string line = reader.ReadLine();
                        string[] values = line.Split('\t');

                        if (values.Length != 5)
                            throw new FormatException("Неправильний формат файлу: неправильна кількість даних");

                        string shapeType = values[0];
                        while (shapeType[shapeType.Length - 1] == ' ')
                        {
                            shapeType = shapeType.Substring(0, shapeType.Length - 1);
                        }
                        shapeType = tableWindow.typeOfShapes.FirstOrDefault(x => x.Value == shapeType).Key;

                        if (int.TryParse(values[1], out int startX) && int.TryParse(values[2], out int startY))
                        {
                            startPoint = new Point(startX, startY);
                        }

                        if (int.TryParse(values[3], out int endX) && int.TryParse(values[4], out int endY))
                        {
                            endPoint = new Point(endX, endY);
                        }

                        switch (shapeType)
                        {
                            case "PointShape":
                                if (endPoint != Point.Empty)
                                    throw new FormatException("Неправильний формат файлу: забагато даних при створенні крапки");
                                shapeObjectsEditor.AddShape(new PointShape(startPoint));
                                break;

                            case "LineShape":
                                shapeObjectsEditor.AddShape(new LineShape(startPoint, endPoint));
                                break;

                            case "RectShape":
                                shapeObjectsEditor.AddShape(new RectShape(startPoint, endPoint));
                                break;

                            case "EllipseShape":
                                shapeObjectsEditor.AddShape(new EllipseShape(startPoint, endPoint, fillColor: Color.Gray));
                                break;

                            case "CubeShape":
                                shapeObjectsEditor.AddShape(new CubeShape(startPoint, endPoint));
                                break;

                            case "LineOOShape":
                                shapeObjectsEditor.AddShape(new LineOOShape(startPoint, endPoint));
                                break;

                            default:
                                throw new FormatException("Неправильний формат файлу: неправильний тип фігур");
                        }
                    }
                }

                Refresh();
                MessageBox.Show("Дані успішно завантажено з текстового файлу.", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeTableInfo()
        {
            tableWindow.RefreshDataGridView(shapeObjectsEditor.Shapes);
        }

        private void ShowSelected(int shapeNumber)
        {
            shapeObjectsEditor.ShowSelectedShape(shapeNumber);
            Refresh();
        }

        private void HideSelected()
        {
            shapeObjectsEditor.HideSelectedShape();
            Refresh();
        }

        private void DeleteSelected(int shapeNumber)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити об'єкт?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                shapeObjectsEditor.DeleteSelectedShape(shapeNumber);

            Refresh();
        }

        private void IfMenuItemSelected(ToolStripMenuItem menuItem, ToolStripButton toolItem)
        {
            if (selectedMenuItem != menuItem)
            {
                if(selectedMenuItem != null && selectedToolButton != null)
                {
                    selectedMenuItem.Checked = false;
                    selectedToolButton.Checked = false;
                }

                selectedMenuItem = menuItem;
                selectedMenuItem.Checked = true;
                
                selectedToolButton = toolItem;
                selectedToolButton.Checked = true;
            }
        }

        private void IfMenuTableWorkSelected(ToolStripMenuItem menuItem)
        {
            if (selectedTableWorkMenu != menuItem)
            {
                if (selectedTableWorkMenu != null)
                    selectedTableWorkMenu.Checked = false;

                selectedTableWorkMenu = menuItem;
                selectedTableWorkMenu.Checked = true;

            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string info = "Довідку ще не придумали, тому ловіть анекдот:\r\n\r\nВовки загнали собаку, оточили, хочуть зжерти. " +
                "Собака просить не вбивати її, натомість обіцяє допомагати заганяти овець та іншу худобу.\r\n\r\n" +
                "Вовки подумали і залишили собаку в зграї. Два роки вона їм допомагала, всьому вчила, показувала місця, полювала разом з ними...\r\n\r\n" +
                "Настала особливо голодна зима, полювання невдалі, вовки голодні, зневірені. Що робити? Вирішили все-таки зжерти собаку. Зжерли. Кісточки поховали.\r\n\r\n" +
                "Поставили надгробок. Думають, як підписати, від кого? \"Від друзів\"? Так начебто які ж вони друзі, раз зжерли... «Від ворогів»? Так 2 роки разом пліч-о-пліч " +
                "жили, полювали, ніхто в образі не був...\r\n\r\nПодумали і написали «Від колег».";
            MessageBox.Show(info, "Довідка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
    }
}
