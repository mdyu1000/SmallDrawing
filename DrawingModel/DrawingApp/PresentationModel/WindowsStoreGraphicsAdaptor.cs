using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;
using Windows.UI.Xaml;

namespace DrawingApp.PresentationModel
{
    class WindowsStoreGraphicsAdaptor : IGraphics
    {
        Canvas _canvas;
        private const int PEN_THICK = 5;

        //WindowsStoreGraphicsAdaptor
        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        //ClearAll
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        //DrawLine
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        //DrawRectangle
        public void DrawRectangle(double valueX, double valueY, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Margin = new Thickness(valueX, valueY, width, height);
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.Fill = new SolidColorBrush(Colors.Gold);
            _canvas.Children.Add(rectangle);
        }

        //DrawEllipse
        public void DrawEllipse(double valueX, double valueY, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Width = width;
            ellipse.Height = height;
            ellipse.Margin = new Thickness(valueX, valueY, width, height);
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Fill = new SolidColorBrush(Colors.Gold);
            _canvas.Children.Add(ellipse);
        }

        //DrawArrow
        public void DrawArrow(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.StrokeThickness = PEN_THICK;
            line.Stroke = new SolidColorBrush(Colors.Blue);
            _canvas.Children.Add(line);
        }

        //DrawLineSelected
        public void DrawLineSelected(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.StrokeThickness = PEN_THICK;
            line.Stroke = new SolidColorBrush(Colors.Red);
            _canvas.Children.Add(line);
        }

        //DrawRectangleSelected
        public void DrawRectangleSelected(double valueX, double valueY, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Margin = new Thickness(valueX, valueY, width, height);
            rectangle.StrokeThickness = PEN_THICK;
            rectangle.Stroke = new SolidColorBrush(Colors.Red);
            _canvas.Children.Add(rectangle);
        }

        //DrawEllipseSelected
        public void DrawEllipseSelected(double valueX, double valueY, double width, double height)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Width = width;
            ellipse.Height = height;
            ellipse.Margin = new Thickness(valueX, valueY, width, height);
            ellipse.StrokeThickness = PEN_THICK;
            ellipse.Stroke = new SolidColorBrush(Colors.Red);
            _canvas.Children.Add(ellipse);
        }

        //DrawArrowSelected
        public void DrawArrowSelected(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.StrokeThickness = PEN_THICK;
            line.Stroke = new SolidColorBrush(Colors.Red);
            _canvas.Children.Add(line);
        }
    }
}