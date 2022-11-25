namespace KTPO4311.Gorohov.Lib.src.LogAn
{
    public interface ILogAnalyzer
    {
        public event LogAnalyzerAction Analyzed;

        void Analyze(string fileName);

        bool IsValidLogFileName(string fileName);
    }
}
