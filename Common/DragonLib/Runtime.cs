using System;

namespace DragonLib
{
    public class Runtime
    {
        public Runtime()
        {

        }

        private void Init()
        {

        }
    }

    public static class DragonLibVersion
    {
        public static string GetVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
