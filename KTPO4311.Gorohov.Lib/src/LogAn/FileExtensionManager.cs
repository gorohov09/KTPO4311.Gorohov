using System;
using System.Configuration;

namespace KTPO4311.Gorohov.Lib.src.LogAn
{
    /// <summary>
    /// Менеджер расширения файлов
    /// </summary>
    public class FileExtensionManager : IExtensionManager
    {
        /// <summary>
        /// Проверка правильности расширения
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool IsValid(string fileName)
        {
            string configExtension = ConfigurationManager.AppSettings["goodExtension"];
            if (fileName.EndsWith(configExtension))
            {
                return true;
            }

            return false;
        }
    }
}