using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented a http://go.microsoft.com/fwlink/?LinkId=234238
namespace DrawingApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        public MainPage()
        {
            this.InitializeComponent();
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _buttonClear.Click += HandleClearButtonClick;
            _buttonLine.Click += ClickButtonLine;
            _buttonRectangle.Click += ClickButtonRectangle;
            _buttonRedo.Click += ClickButtonRedo;
            _buttonUndo.Click += ClickButtonUndo;
            _model._modelChanged += HandleModelChanged;
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// The Parameter
        /// property is typically used to configure the page.</param>

        //OnNavigatedTo
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        //HandleClearButtonClick
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
        }

        //HandleCanvasPressed
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _presentationModel.DrawCanvas();
            _model.PressPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y, _presentationModel.IsButtonLinePressed(), _presentationModel.IsButtonRectanglePressed(), _presentationModel.IsButtonEllipsePressed());
            RefreshState();
        }

        //HandleCanvasReleased
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _presentationModel.ReleaseCanvas();
            _model.ReleasePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            RefreshState();
        }

        //HandleCanvasMoved
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        //HandleModelChanged
        public void HandleModelChanged()
        {
            _presentationModel.Draw();
        }

        // Start Draw Rectangle
        private void ClickButtonRectangle(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClickButtonRectangle();
            RefreshState();
        }

        // Start Draw Line
        private void ClickButtonLine(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClickButtonLine();
            RefreshState();
        }

        // Start Draw Ellipse
        private void ClickButtonEllipse(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClickButtonEllipse();
            RefreshState();
        }

        //RefreshState
        public void RefreshState()
        {
            _buttonRectangle.IsEnabled = _presentationModel.IsButtonShapeEnabled();
            _buttonLine.IsEnabled = _presentationModel.IsButtonShapeEnabled();
            _buttonEllipse.IsEnabled = _presentationModel.IsButtonShapeEnabled();
            _buttonClear.IsEnabled = _presentationModel.IsButtonShapeEnabled();
            _buttonRedo.IsEnabled = _presentationModel.IsButtonRedoEnabled();
            _buttonUndo.IsEnabled = _presentationModel.IsButtonUndoEnabled();
        }

        //ClickButtonRedo
        private void ClickButtonRedo(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClickButtonRedo();
            RefreshState();
        }

        //ClickButtonUndo
        private void ClickButtonUndo(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClickButtonUndo();
            RefreshState();
        }
    }
}