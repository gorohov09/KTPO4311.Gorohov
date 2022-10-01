using System;

namespace KTPO4311.Gorohov.Lib.src.LogAn
{
    /// <summary>
    /// Анализ лог. файлов
    /// </summary>
    public class LogAnalyzer
    {
        private readonly IExtensionManager _extensionManager;

        public LogAnalyzer(IExtensionManager extensionManager)
        {
            _extensionManager = extensionManager;
        }

        /// <summary>
        /// Проверка правильности имени файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool IsValidLogFileName(string fileName)
        {
            return _extensionManager.IsValid(fileName);
        }
    }
}
