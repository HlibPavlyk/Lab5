using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Lab5
{

    public class ShapeObjectsEditor
    {
        private static readonly ShapeObjectsEditor instance = new ShapeObjectsEditor();

        private bool ifButtonClicked = false;
        private Point startPoint;
        private Point endPoint;

        private List<Shape> shapes = new List<Shape>();
        private List<Shape> stepShapes = new List<Shape>();
        private Shape currentRubberShape = null;
        private Shape currentShape = null;
        private Shape selectedShape = null;

        private ChangedEventHandler shapesChangedHandler;

        public event ChangedEventHandler ShapesChangedEvent
        {
            add { shapesChangedHandler += value; }
            remove { shapesChangedHandler -= value; }
        }

        private ShapeObjectsEditor() { }

        public static ShapeObjectsEditor Instance
        {
            get { return instance; }
        }
        public Shape SetCurrentShape
        {
            set { currentShape = value; }
        }
        public Shape SetCurrentRubberShape
        {
            set { currentRubberShape = value; }
        }
        public List<Shape> Shapes 
        { 
            get { return shapes; } 
        }


        public void AddShape(Shape shape)
        {
            if (shapes.Count == stepShapes.Count)
            {
                shapes.Add(shape);
                stepShapes = new List<Shape>(shapes);
                shapesChangedHandler?.Invoke();

            }
            else
            {
                stepShapes.Add(shape);
                shapes = new List<Shape>(stepShapes);
            }
        }

        public void OnLeftButtonDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                endPoint = e.Location;

                currentShape.SetPosition(startPoint);
                if(currentShape.GetType() == typeof(PointShape))
                    AddShape(currentShape.CreateCopy());

                ifButtonClicked = true;
            }
        }

        public void OnLeftButtonUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ifButtonClicked)
            {
                endPoint = e.Location;
                currentShape.SetPosition(startPoint, endPoint);

                if (currentShape.GetType() != typeof(PointShape))
                    AddShape(currentShape.CreateCopy());

                ifButtonClicked = false;
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ifButtonClicked)
            {
                endPoint = e.Location;
                currentRubberShape?.SetPosition(startPoint, endPoint);
            }
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            foreach (Shape shape in stepShapes)
            {

                if (shape != null)
                    shape.Show(graphics);
                else
                    break;
            }

            currentRubberShape?.Show(graphics);
            selectedShape?.Show(graphics);
        }

        public void OnClear()
        {
            stepShapes.Clear();
            shapes.Clear();

            if (currentShape.GetType() != typeof(PointShape))
                currentRubberShape.SetPosition(Point.Empty, Point.Empty);

            shapesChangedHandler?.Invoke();
        }

        public void OnStepBack(object sender, EventArgs e)
        {
            if (stepShapes.Count > 0)
            {
                stepShapes.RemoveAt(stepShapes.Count - 1);
            }
            if (currentShape.GetType() != typeof(PointShape))
                currentRubberShape.SetPosition(Point.Empty, Point.Empty);
        }

        public void OnStepForward(object sender, EventArgs e)
        {
            if (stepShapes.Count < shapes.Count)
            {
                stepShapes.Add(shapes[stepShapes.Count].CreateCopy());
            }
        }

        public void ShowSelectedShape(int shapeNumber)
        {
            selectedShape = shapes[shapeNumber].CreateCopy();
            selectedShape.Color = Color.Red;
        }

        public void HideSelectedShape()
        {
            selectedShape = null;
        }

        public void DeleteSelectedShape(int shapeNumber)
        {
            DeleteShapeAtPosition(shapeNumber);
        }

        private void DeleteShapeAtPosition(int shapeIndex)
        {
            if (shapeIndex < shapes.Count)
                shapes.RemoveAt(shapeIndex);

            if (shapeIndex < stepShapes.Count)
                stepShapes.RemoveAt(shapeIndex);

            if (currentShape.GetType() != typeof(PointShape))
                currentRubberShape.SetPosition(Point.Empty, Point.Empty);

            shapesChangedHandler?.Invoke();
        }
    }
}