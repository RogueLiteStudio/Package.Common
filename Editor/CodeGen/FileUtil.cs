using System.IO;
using System.Text;

namespace CodeGen
{
    public static class FileUtil
    {
        private static UTF8Encoding encoding = new UTF8Encoding(false);

        public static void WriteFile(string path, string content)
        {
            if (File.Exists(path))
            {
                if (File.ReadAllText(path, encoding) == content)
                {
                    return;
                }
            }
            File.WriteAllText(path, content, encoding);
        }

        public static void ForceWrite(string path, string content)
        {
            CheckDirectory(path);
            File.WriteAllText(path, content, encoding);
        }

        public static void CheckDirectory(string path)
        {
            string folder = Path.GetDirectoryName(path);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

        }

        public static void WriteFileWithCreateFolder(string path, string content)
        {
            CheckDirectory(path);
            WriteFile(path, content);
        }
    }

}
