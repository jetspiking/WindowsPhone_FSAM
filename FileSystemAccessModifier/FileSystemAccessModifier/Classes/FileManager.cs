using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemAccessModifier.Classes
{
    public class FileManager
    {
        public static readonly string[] attributes =
        {
            "ReadOnly",
            "Hidden",
            "System",
            "Directory",
            "Archive",
            "Device",
            "Normal",
            "Temporary",
            "Sparsefile",
            "ReparsePoint",
            "Compressed",
            "Offline",
            "NotContentIndexed",
            "Encrypted",
            "IntegrityStream",
            "NoScrubData"
        };

        public static bool applyOnContentsOfFolder = false;

        public static int GetFileAttributeByAttributeIndex(int attributeIndex)
        {
            return (int)Math.Pow(2, attributeIndex);
        }

        public static FileAttributes GetFileAttributesByString(String fileAttribute)
        {
            switch (fileAttribute)
            {
                case "ReadOnly":
                    return FileAttributes.ReadOnly;
                case "Hidden":
                    return FileAttributes.Hidden;
                case "System":
                    return FileAttributes.System;
                case "Directory":
                    return FileAttributes.Directory;
                case "Archive":
                    return FileAttributes.Archive;
                case "Device":
                    return FileAttributes.Device;
                case "Normal":
                    return FileAttributes.Normal;
                case "Temporary":
                    return FileAttributes.Temporary;
                case "Sparsefile":
                    return FileAttributes.SparseFile;
                case "ReparsePoint":
                    return FileAttributes.ReparsePoint;
                case "Compressed":
                    return FileAttributes.Compressed;
                case "Offline":
                    return FileAttributes.Offline;
                case "NotContentIndexed":
                    return FileAttributes.NotContentIndexed;
                case "Encrypted":
                    return FileAttributes.Encrypted;
                case "IntegrityStream":
                    return FileAttributes.IntegrityStream;
                case "NoScrubData":
                    return FileAttributes.NoScrubData;

            }
            return FileAttributes.Normal;
        }

        public static void SetAccessModifierForPath(String path, FileAttributes accessModifier)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                if (applyOnContentsOfFolder)
                {
                    foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetFileSystemInfos("*"))
                    {
                        //SetAccessModifierForPath(subDirectoryInfo.FullName, accessModifier);
                        subDirectoryInfo.Attributes = accessModifier;
                    }
                }
                else
                {
                    directoryInfo.Attributes = accessModifier;
                }
            }
            catch { };
        }

        public static bool VerifyValidPath(String path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.Exists;
        } 

        public static String GetAccessModifierForPath(String path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.Attributes.ToString();
        }
    }
}
