using System;

namespace KTPO4311.Gorohov.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameIsValid { get; set; }

        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameIsValid = false;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Имя файла должно быть задано");
            }
            if (!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            
            WasLastFileNameIsValid = true;
            return true;
        }
    }
}
