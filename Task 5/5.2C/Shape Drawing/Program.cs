using System;
using SplashKitSDK;

namespace ShapeDrawing
{
    class Program
    {
        private enum ShapeKind
        {
            Rectangle,Circle,Line
        }
        public static void Main(string[] args)
        {
            Shape.RegisterShape("Rectangle", typeof(MyRectangle));
            Shape.RegisterShape("Circle", typeof(MyCircle));
            Shape.RegisterShape("Line", typeof(MyLine));

            new Window("Shape Drawer", 800, 600);
            Drawing drawingObject = new Drawing();
            ShapeKind kindToAdd = new ShapeKind();                                                                         
            do                                                                                                
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                drawingObject.Draw();
                if (SplashKit.MouseClicked(MouseButton.LeftButton) == true)                                            
                 {
                    Shape newShape;
                    if(kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newCircle.X = SplashKit.MouseX();                                                           
                        newCircle.Y = SplashKit.MouseY();
                        newShape = newCircle;
                        drawingObject.AddShape(newShape);
                    }
                    else if(kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();                                                   
                        newRect.X = SplashKit.MouseX();                                                           
                        newRect.Y = SplashKit.MouseY();                                                           
                        newRect.Color = SplashKit.ColorGreen();
                        newShape = newRect;
                        drawingObject.AddShape(newShape);
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        MyLine newLine = new MyLine();
                        newLine.X = SplashKit.MouseX();
                        newLine.Y = SplashKit.MouseY();
                        newLine.EndX = SplashKit.MouseX() + 50;
                        newLine.EndY = SplashKit.MouseY() + 50;
                        newLine.Color = SplashKit.ColorRed();
                        newShape = newLine;
                        drawingObject.AddShape(newShape);
                    } else {}
                    
                    
                }

                if (SplashKit.KeyTyped(KeyCode.RKey) == true)
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.CKey) == true)
                {
                    kindToAdd = ShapeKind.Circle;
                }
              
                else if (SplashKit.KeyTyped(KeyCode.LKey) == true)
                {
                    kindToAdd = ShapeKind.Line;
                }





                if (SplashKit.KeyTyped(KeyCode.SpaceKey) == true)                                               
                {

                    drawingObject.Background = SplashKit.RandomRGBColor(255);
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton) == true)
                {
                    drawingObject.SelectShapeAt(SplashKit.MousePosition());
                }
                if(SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in drawingObject.SelectedShapes)
                        drawingObject.RemoveShape(s);
                }
                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    drawingObject.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\TestDrawing.txt");
                }
                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        drawingObject.Load(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\TestDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }

                }

                drawingObject.Draw();
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));                                      
        }
    }
}
