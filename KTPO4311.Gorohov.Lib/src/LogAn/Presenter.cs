namespace KTPO4311.Gorohov.Lib.src.LogAn
{
    public class Presenter
    {
        private ILogAnalyzer _logAnalyzer;

        private IView _view;

        public Presenter(ILogAnalyzer logAnalyzer, IView view)
        {
            _logAnalyzer = logAnalyzer;
            _view = view;
            _logAnalyzer.Analyzed += OnLogAnalyzed;
        }

        private void OnLogAnalyzed()
        {
            _view.Render("Обработка завершена");
        }
    }
}
