namespace KTPO4311.Gorohov.Lib.src.LogAn
{
    public static class WebServiceFactory
    {
        private static IWebService _customService = null;

        public static IWebService Create()
        {
            if (_customService != null)
            {
                return _customService;
            }

            return new WebService();
        }

        public static void SetWebService(IWebService srv)
        {
            _customService = srv;
        }
    }
}
