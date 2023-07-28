using System;
using SplashKitSDK;


namespace ShapeDrawer
{

    public class Program
    {
        public static void Main()
        {
            new Window("Shape Drawer", 800, 600);
            Drawing drawObject = new Drawing();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();                
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    
                    Shape tempShape = new Shape();
                    tempShape.X = SplashKit.MouseX();
                    tempShape.Y = SplashKit.MouseY();
                    drawObject.AddShape(tempShape);
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawObject.Background = SplashKit.RandomRGBColor(255); 
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawObject.SelectSchapesAt(SplashKit.MousePosition());
                }
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in drawObject.SelectedShapes)
                        drawObject.RemoveShape(s);
                }
                drawObject.Draw();
                SplashKit.RefreshScreen(); 
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}
