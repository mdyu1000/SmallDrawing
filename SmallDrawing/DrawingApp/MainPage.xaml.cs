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
        const int BUTTON_SIZE = 4;
        bool[] _isButtonPressed = new bool[BUTTON_SIZE];

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
            _model.ClearCommand();
        }

        //HandleCanvasPressed
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            const int TWO = 2;
            const int THREE = 3;
            _isButtonPressed[0] = _presentationModel.IsButtonLinePressed();
            _isButtonPressed[1] = _presentationModel.IsButtonRectanglePressed();
            _isButtonPressed[TWO] = _presentationModel.IsButtonEllipsePressed();
            _isButtonPressed[THREE] = _presentationModel.IsButtonArrowPressed();
            _presentationModel.DrawCanvas();
            _model.PressPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y, _isButtonPressed);
            _model.PressSelected(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y, _presentationModel.IsButtonSelectPressed());
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
            _buttonDelete.IsEnabled = _presentationModel.IsButtonShapeEnabled();
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

        //ClickButtonArrow
        private void ClickButtonArrow(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClickButtonArrow();
            RefreshState();
        }

        //ClickButtonSelect
        private void ClickButtonSelect(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClickButtonSelect();
            RefreshState();
        }

        //ClickButtonDelete
        private void ClickButtonDelete(object sender, RoutedEventArgs e)
        {
            _presentationModel.ClickButtonDelete();
            RefreshState();
        }
    }
}