using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace LastKey.Backend
{
    internal class CheckFiles
    {
        public void checkFiles()
        {
            directoryExist("Backend");
            filesExist("Backend/Password.txt");
            jsonExist("Backend/Password.json");

        }

        private void filesExist(string path)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write("e7cf3ef4f17c3999a94f2c6f612e8a888e5b1026878e4e19398b23bd38ec221a");
                }
            }
        }
        private void jsonExist(string path)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write("[]");
                }
            }
        }

        private void directoryExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }

}
