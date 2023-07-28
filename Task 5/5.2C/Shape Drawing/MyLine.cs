using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawing
{
    public class MyLine : Shape
    {
		private float _endX, _endY;

		public MyLine() : this(Color.Green, 0, 0, 50, 50) { }

		public MyLine(Color clr, float startX, float startY, float endX, float endY)
		{
			Color = clr;
			X = startX;
			Y = startY;
			_endX = endX;
			_endY = endY;
		}

		public float EndX
		{
			get { return _endX;} set { _endX = value; }
		}

		public float EndY
		{
			get { return _endY;} set { _endY = value; }
		}

		
		public override void Draw()
		{
			if (Selected)
			{
				DrawOutline();
			}
			SplashKit.DrawLine(Color.Red, X, Y, _endX, _endY);
			
		}

		public override void DrawOutline()
		{
			int radius = 5;
			SplashKit.FillCircle(Color.Black, X, Y, radius);
			SplashKit.FillCircle(Color.Black, _endX, _endY, radius);
		}

		public override bool IsAt(Point2D pt)
		{
			if (SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, _endX, _endY)))
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
			//writer.WriteLine("Line");
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
