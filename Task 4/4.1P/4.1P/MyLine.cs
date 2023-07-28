using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        Line _line;
        DrawingOptions DrawingOptions = new DrawingOptions() { LineWidth = 5 };
        public MyLine()
        {

        }

        public MyLine(Line line)
        {
            _line = line;
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(_color, _line);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, _line.EndPoint.X, _line.EndPoint.Y, 3);
            SplashKit.FillCircle(Color.Black, _line.StartPoint.X, _line.StartPoint.Y, 3);

        }

        
        public override bool IsAt(Point2D pt)
        {
            double tolerance = 5;
            Point2D normalisedLine;
            Point2D normalisedPoint;
            Point2D rotatedNormalisedLine;
            Point2D rotatedNormalisedPoint;
      
            normalisedLine.X = _line.EndPoint.X - _line.StartPoint.X;
            normalisedLine.Y = _line.EndPoint.Y - _line.StartPoint.Y;
            normalisedPoint.X = _line.EndPoint.X - pt.X;
            normalisedPoint.Y = _line.EndPoint.Y - pt.Y;
          
            double theta = Math.Atan2(normalisedLine.Y, normalisedLine.X);
            rotatedNormalisedLine.X = Math.Cos(theta) * normalisedLine.X + Math.Sin(theta) * normalisedLine.Y;
            rotatedNormalisedLine.Y = Math.Cos(theta) * normalisedLine.Y - Math.Sin(theta) * normalisedLine.X;
            rotatedNormalisedPoint.X = Math.Cos(theta) * normalisedPoint.X + Math.Sin(theta) * normalisedPoint.Y;
            rotatedNormalisedPoint.Y = Math.Cos(theta) * normalisedPoint.Y - Math.Sin(theta) * normalisedPoint.X;
      
            if (Math.Abs(rotatedNormalisedPoint.Y - rotatedNormalisedLine.Y) < tolerance)
            {
                if (rotatedNormalisedPoint.X < rotatedNormalisedLine.X + tolerance && rotatedNormalisedPoint.X > -tolerance)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
