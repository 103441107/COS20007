using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShapeDrawing
{
    public class MyRectangle : Shape
    {
        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public MyRectangle() : this(Color.Green, 0, 0, 100, 100)
        {

        }
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
           
        }
        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        }
        public override bool IsAt(Point2D pt)
        {
            if ((pt.X > X) && (pt.X < (X + Width)))
            {
                if ((pt.Y > Y) && (pt.Y < (Y + Height)))
                {
                    return true;
                }
            }
            return false;
        }

        public override void SaveTo(StreamWriter writer)
        {
            //writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInterger();
            Height = reader.ReadInterger();
        }
    }
}
