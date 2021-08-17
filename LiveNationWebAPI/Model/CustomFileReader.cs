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
        public static string ReadFile(Uri locationUri)
        {
            try
            {
                string localPath = locationUri.LocalPath;
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

        public static bool WriteToFile(Uri locationUri, string json)
        {
            try
            {
                string localPath = locationUri.LocalPath;
                if (File.Exists(localPath))
                {
                    using (var writer = new StreamWriter(localPath))
                    {
                        writer.Write(json);
                    }

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
