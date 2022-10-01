using System;

namespace KTPO4311.Gorohov.Lib.src.LogAn
{
    /// <summary>
    /// Анализ лог. файлов
    /// </summary>
    public class LogAnalyzer
    {
        public LogAnalyzer()
        {
        }

        /// <summary>
        /// Проверка правильности имени файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool IsValidLogFileName(string fileName)
        {
            return ExtensionManagerFactory.Create().IsValid(fileName);
        }
    }
}
