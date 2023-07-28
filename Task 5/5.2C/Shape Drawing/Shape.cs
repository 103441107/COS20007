using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawing
{

    public abstract class Shape
    {
        private static Dictionary<string, Type> _ShapeClassRegistry = new Dictionary<string, Type>();
        public static void RegisterShape(string name, Type t)
        {
            _ShapeClassRegistry[name] = t;
        }
        public static Shape CreateShape(string name)
        {
            return (Shape)Activator.CreateInstance(_ShapeClassRegistry[name]);
        }
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;                
       
        public Shape() : this(Color.Yellow) 
        {
            Color = SplashKit.ColorWhite();
            X = 0;
            Y = 0;
        }

        public Shape(Color color, float x, float y, int width, int height, bool selected)
        {
            Color = color;
            X = x;
            Y = y;
            
            Selected = selected;
        }

        public Shape(Color yellow)
        {
            Yellow = yellow;
        }

        //public void Draw()
        //{
        //    SplashKit.FillRectangle(Color, X, Y, Width, Height);

        //    if (Selected)
        //    {
        //        DrawOutline();
        //    }

        //}

        public abstract void Draw();

        //if (Selected) DrawOutline();
        //SplashKit.FillRectangle(Color, X, Y, Width, Height);

        public abstract void DrawOutline();

        //SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);

        public abstract bool IsAt(Point2D pt);
        
        public bool Selected { get => Selected1; set => Selected1 = value; }
        public Color Color { get => _color; set => _color = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public bool Selected1 { get => _selected; set => _selected = value; }
        public Color Yellow { get; }

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(Shape.GetKey(this.GetType()));
            writer.WriteColor(Color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            X = reader.ReadInterger();
            Y = reader.ReadInterger();
        }
        static string GetKey(Type t)
        {
            foreach (string key in _ShapeClassRegistry.Keys)
            {
                if (_ShapeClassRegistry[key] == t)
                {
                    return key;
                }
            }
            throw new KeyNotFoundException();
        }
    }
}
