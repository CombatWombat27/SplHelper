using System;

namespace splhelper
{
    internal class EnvironmentVariables
    {
        public static readonly string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    }
}
