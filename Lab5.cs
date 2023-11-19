using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab5
{
    public partial class Lab5 : Form
    {
        private ToolStripMenuItem selectedMenuItem = null;
        private ToolStripButton selectedToolButton = null;
        ShapeObjectsEditor shapeObjectsEditor = new ShapeObjectsEditor();

        public Lab5()
        {
            InitializeComponent();
            shapeObjectsEditor.SetCurrentShape = new PointShape(Point.Empty);
            IfMenuItemSelected(pointToolStripMenuItem, toolStripButtonPoint);
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
            shapeObjectsEditor.OnClear(sender, e);
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
