namespace Smarts.Core
{
    public static class Functions
    {
        public static void NoOp()
        {
        }

        public static T Identity<T>(T value)
        {
            return value;
        }
    }
}