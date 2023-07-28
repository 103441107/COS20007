using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawing
{
   public class MyCircle : Shape

    {
        private int _radius;

        public MyCircle() : this(Color.Blue, 50)
        {
        }

        public MyCircle(Color clr, int radius)
        {
            _radius = radius;
            Color = clr;
        }

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillCircle(Color, X, Y, _radius);
        }
        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 2);
        }
        public override bool IsAt(Point2D pt)
        {
            double x2 = (pt.X - X) * (pt.X - X);
            double y2 = (pt.Y - Y) * (pt.Y - Y);
            if (Math.Sqrt(x2 + y2) < _radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
           // writer.WriteLine("Circle");
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
