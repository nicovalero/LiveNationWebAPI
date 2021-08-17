using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LiveNationWebAPI.Model
{
    public static class CustomFileReader
    {
        public static string ReadFile(Uri location)
        {
            try
            {
                string localPath = location.LocalPath;
                if (File.Exists(localPath))
                {
                    string content = "";
                    using (var reader = new StreamReader(localPath))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadToEnd();
                            content += line;
                        }
                    }

                    return content;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
