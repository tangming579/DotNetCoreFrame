using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ServiceCore.Helpers
{
    public class ZipHelper
    {
        //解压缩文件
        public static bool UnCompressFile(string sourceArchiveFileName, string destinationDirectoryName)
        {
            if (!File.Exists(sourceArchiveFileName)) return false;
            try
            {
                ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }
        //压缩文件
        public static bool CompressFile(string sourceDirectoryName, string destinationArchiveFileName)
        {
            if (!File.Exists(sourceDirectoryName)) return false;
            try
            {
                ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }
    }
}
