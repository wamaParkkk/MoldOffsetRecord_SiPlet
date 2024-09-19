namespace MoldOffsetRecord_SiPlet
{
    public enum Page
    {        
        MaintnancePage = 0,
        ConfigurePage = 1
    }

    class Define
    {
        public const int BUFSIZ = 512;                
                
        public static byte currentPage = 0;
        public static byte MaintCurrentPage = 0;

        public static string strUserMode = string.Empty;

        public static int iTimeInterval = 0;
    }    
}
