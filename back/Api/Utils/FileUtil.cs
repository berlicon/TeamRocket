using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public static class FileUtil
    {
        const string FILE_PATH = @"\data\log.txt";
        public static void SaveTimeToFile()
        {
            string path = Directory.GetCurrentDirectory();
            using (var file = new StreamWriter(path + FILE_PATH, true))
            {
                file.WriteLine(DateTime.Now.ToString());
            }
        }
    }
}
