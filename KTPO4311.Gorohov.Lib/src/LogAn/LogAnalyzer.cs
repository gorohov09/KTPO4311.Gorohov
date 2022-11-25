using System;

namespace KTPO4311.Gorohov.Lib.src.LogAn
{
    /// <summary>
    /// Анализ лог. файлов
    /// </summary>
    public class LogAnalyzer : ILogAnalyzer
    {
        //public event LogAnalyzerAction Analyzed;

        public LogAnalyzer()
        {
        }

        public event LogAnalyzerAction Analyzed;

        /// <summary>
        /// Проверка правильности имени файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool IsValidLogFileName(string fileName)
        {
            try
            {
                return ExtensionManagerFactory.Create().IsValid(fileName);
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        /// <summary>
        /// Анализировать лог. файлы
        /// </summary>
        /// <param name="fileName"></param>
        public void Analyze(string fileName)
        {
            try
            {
                if (fileName.Length < 8)
                {
                    IWebService srv = WebServiceFactory.Create();
                    srv.LogError("Слишком короткое имя файла: " + fileName);
                }
            }
            catch (Exception ex)
            {
                IEmailService srv = EmailServiceFactory.Create();
                srv.SendEmail("andrej.gorokhov2017@yandex.ru", "Невозможно вызвать веб-сервис", ex.Message);
            }

            RaiseAnalyzedEvent();
            
        }

        protected void RaiseAnalyzedEvent()
        {
            if (Analyzed != null)
            {
                Analyzed();
            }
        }
    }
}
