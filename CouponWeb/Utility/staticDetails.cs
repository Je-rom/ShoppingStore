namespace CouponWeb.Utility
{
    public class staticDetails
    {
        public static string CouponAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }

        public enum ApiType
        {
            GET,
            POST, 
            PUT, 
            DELETE
        }
    }
}
