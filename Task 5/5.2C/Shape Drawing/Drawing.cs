using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;
namespace ShapeDrawing
{

    public class Drawing
    {
        private readonly List<Shape>_shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = SplashKit.ColorWhite();                                                         
        }

        public Color Background                                                                
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }

        public Drawing() : this (Color.White) { }                                                  


        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);                                                               
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);                                                
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }

        internal void AddShape(MyCircle newCircle)
        {
            throw new NotImplementedException();
        }

        public void SelectShapeAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (!s.Selected) 
                {
                    s.Selected = s.IsAt(pt);
                }
                else 
                {
                    s.Selected = !s.IsAt(pt);
                }
            }

        }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach(Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }
        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }
        public void Save(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteColor(Background);
            writer.WriteLine(ShapeCount);
            foreach (Shape s in _shapes)
            {
                s.SaveTo(writer);
            }
            writer.Close();

        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try
            {
                int count;
                Shape s;
                string kind;
                Background = reader.ReadColor();
                count = reader.ReadInterger();
                _shapes.Clear();
                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    s = Shape.CreateShape(kind);
                    s.LoadFrom(reader);
                    AddShape(s);
                }  
            }
            finally
            {
                reader.Close();
            }

        }
    }
}
