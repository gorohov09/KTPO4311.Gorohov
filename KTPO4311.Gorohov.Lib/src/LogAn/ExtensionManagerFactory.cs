using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4311.Gorohov.Lib.src.LogAn
{
    /// <summary>
    /// Фабрика диспетчеров расширений файлов
    /// </summary>
    public static class ExtensionManagerFactory
    {
        private static IExtensionManager _customManager = null;

        public static IExtensionManager Create()
        {
            if (_customManager != null)
            {
                return _customManager;
            }

            return new FileExtensionManager();
        }

        public static void SetManager(IExtensionManager mgr)
        {
            _customManager = mgr;
        }
    }
}
