using System;

namespace KTPO4311.Gorohov.Lib.src.LogAn
{
    public static class EmailServiceFactory
    {
        private static IEmailService _customService = null;

        public static IEmailService Create()
        {
            if (_customService != null)
            {
                return _customService;
            }

            throw new NotImplementedException();
        }

        public static void SetEmailService(IEmailService srv)
        {
            _customService = srv;
        }
    }
}
