using System;
using System.Linq;

namespace _66BitApp.Helpers
{
    public static class PathFinder
    {
        public static string GetConnectionPath()
        {
            var directory = Environment.CurrentDirectory.Split("\\").Last();
            if (directory == "66BitApp")
                return "csdev";
            if (directory == "netcoreapp3.1")
                return "cs";
            throw new Exception("Папка запуска неверна");
        }
    }
}
