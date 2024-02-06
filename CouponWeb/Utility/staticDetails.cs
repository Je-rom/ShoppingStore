namespace CouponWeb.Utility
{
    public class staticDetails
    {
        internal static string CouponApiBase;

        public static string CouponAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST, 
            PUT, 
            DELETE
        }
    }
}
