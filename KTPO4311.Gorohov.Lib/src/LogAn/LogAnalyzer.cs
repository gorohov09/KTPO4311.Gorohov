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

        /// <summary>
        /// Анализировать лог. файлы
        /// </summary>
        /// <param name="fileName"></param>
        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                //Передать внешней службе сообщение об ошибке
                //"Слишком короткое имя файла: " + fileName
            }
        }
    }
}
