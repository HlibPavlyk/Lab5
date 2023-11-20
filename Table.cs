using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab5
{
    public partial class Table : Form
    {
        private DataGridView dataGridView;
        public Dictionary<string, string> typeOfShapes = new Dictionary<string, string>
        {
            { "PointShape", "Крапка" },
            { "LineShape", "Лінія" },
            { "RectShape", "Прямокутник" },
            { "EllipseShape", "Еліпс" },
            { "CubeShape", "Каркас куба" },
            { "LineOOShape", "Лінія з кружечками" }
        };
        private const int MAX_LENGTH_OF_SHAPE_NAME = 18;
        private bool isRowSelected = false;
        private bool isOpenedEarlier = false;
        private bool isWorkTypeSelection;

        public bool IsWorkTypeSelection
        {
            set { isWorkTypeSelection = value; }
        }

        private SelectEventHandler dataGridViewRowDeleteHandler;
        public event SelectEventHandler DataGridViewRowDeleteEvent
        {
            add { dataGridViewRowDeleteHandler += value; }
            remove { dataGridViewRowDeleteHandler -= value; }
        }

        private SelectEventHandler dataGridViewRowSelectedHandler;
        public event SelectEventHandler DataGridViewRowSelectedEvent
        {
            add { dataGridViewRowSelectedHandler += value; }
            remove { dataGridViewRowSelectedHandler -= value; }
        }

        private ChangedEventHandler dataGridViewRowUnselectedHandler;
        public event ChangedEventHandler DataGridViewRowUnselectedEvent
        {
            add { dataGridViewRowUnselectedHandler += value; }
            remove { dataGridViewRowUnselectedHandler -= value; }
        }

       
        public Table()
        {
            InitializeComponent();
            InitializeUI();
            Shown += Table_Shown;
        }

        private void Table_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void Table_Shown(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            isOpenedEarlier = true;
        }

        public void RefreshDataGridView(List<Shape> shapes)
        {
            isRowSelected = false;
            dataGridView?.Rows.Clear();

            foreach (var shape in shapes)
            {
                dataGridView.Rows.Add(typeOfShapes[shape.GetType().Name], shape.StartPoint.X, shape.StartPoint.Y,
                    shape.EndPoint?.X, shape.EndPoint?.Y);
            }

            dataGridView.ClearSelection();

            MaximumSize = new Size(int.MaxValue, CalculateTableHeight(dataGridView.Rows.Count));
            Size = new Size(Size.Width, CalculateTableHeight(dataGridView.Rows.Count));
            isRowSelected = true;
        }

        private void InitializeUI()
        {
            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false
            };
            dataGridView.ReadOnly = true;

            dataGridView.Columns.Add("Name", "Назва");
            dataGridView.Columns.Add("X1", "X1");
            dataGridView.Columns.Add("Y1", "Y1");
            dataGridView.Columns.Add("X2", "X2");
            dataGridView.Columns.Add("Y2", "Y2");


            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.Resizable = DataGridViewTriState.False;
                column.HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Bold);
                column.DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Regular);
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
            }

            dataGridView.CellFormatting += DataGridView_CellFormatting;
            dataGridView.SelectionChanged += DataGridView_SelectionChanged;

            MaximumSize = new Size(int.MaxValue, CalculateTableHeight(dataGridView.Rows.Count));
            MinimumSize = new Size(400, CalculateTableHeight(dataGridView.Rows.Count));
            Size = new Size(600, CalculateTableHeight(dataGridView.Rows.Count));

            Controls.Add(dataGridView);

        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.White;
            }
            else
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        private int CalculateTableHeight(int numberOfRows)
        {
            int rowHeight = dataGridView.Rows.Count > 0 ? dataGridView.Rows[0].Height : dataGridView.RowTemplate.Height;
            int totalHeight = (numberOfRows + 2) * rowHeight;
            int headerHeight = SystemInformation.CaptionHeight;

            return totalHeight + headerHeight;
        }

        public void SaveToTextFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            if (i == 0)
                            {
                                string cellValue = Convert.ToString(row.Cells[i].Value);
                                int tabCount = MAX_LENGTH_OF_SHAPE_NAME - cellValue.Length;
                                string tabs = new string(' ', tabCount);
                                writer.Write($"{cellValue}{tabs}");
                            }
                            else
                                writer.Write(row.Cells[i].Value);

                            if (i < dataGridView.Columns.Count - 1)
                                writer.Write("\t");
                        }

                        writer.WriteLine();
                    }
                }

                MessageBox.Show("Дані успішно збережено у текстовий файл.", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 0 && isRowSelected && isOpenedEarlier)
            {
                if (isWorkTypeSelection)
                    dataGridViewRowSelectedHandler?.Invoke(dataGridView.CurrentRow.Index);
                else
                    dataGridViewRowDeleteHandler?.Invoke(dataGridView.CurrentRow.Index);
            }
            else
            {
                if(isWorkTypeSelection)
                    dataGridViewRowUnselectedHandler?.Invoke();
                return;
            }
        }
    }
}

