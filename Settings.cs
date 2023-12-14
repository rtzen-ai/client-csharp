using System;
namespace RtzenAPIs
{
    public class Settings
    {

        // Mandatory Settings
        public static readonly String API_URL = "https://api.dev.rtzen.com";
        public static readonly String API_KEY = "xxxxxxxxxxxxxxxxx";

        // Sync Flags
        public static readonly bool READ_CHART_OF_ACCOUNTS = true;
        public static readonly bool READ_VENDORS = true;
        public static readonly bool READ_BILLS = true;

        public static readonly bool WRITE_CHART_OF_ACCOUNTS = false;
        public static readonly bool WRITE_VENDORS = false;
        public static readonly bool WRITE_BILLS = false;

        // Optinal Settings
        public static readonly int RESULTS_PER_PAGE = 100;

        // For Testing the Syns
        public static readonly String BUSINESS_UNIT_ID = "8e0b4bca-xxxx-xxxx-xxxx-xxxxxxxxxx";
        public static readonly String VENDOR_ID = "4c4d6483-xxxx-xxxx-xxxx-xxxxxxxxxxxx";


    }
}

