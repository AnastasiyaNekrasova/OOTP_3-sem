using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;

namespace LR_13
{
    class NAPLog
    {
        public FileInfo file;
        string path = "";
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                if (value != null)
                {
                    path = value;
                }
                else
                {
                    throw new Exception("Path value is null");
                }

            }
        }
        public NAPLog(string _path)
        {
            file = new FileInfo(_path);
            Path = _path;
            using (var sw = new StreamWriter(_path))
            {
                DateTime Date = DateTime.Now;
                sw.Write("Log has been created at " + Date + "\n");
            }

        }
        public void WriteToLog(string message = "")
        {
            if (message != "")
            {
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    DateTime Date = DateTime.Now;
                    sw.WriteLine(Date + " : " + message);
                }
            }
            else
            {
                throw new Exception("Message is empty");
            }

        }
        public void ReadFromLog()
        {
            Console.WriteLine("\n_____________Log_____________");
            using (StreamReader sr = new StreamReader(Path))
            {
                var text = sr.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("_____________End_____________");
        }
        public void FindInLog(string keyword)
        {
            Console.WriteLine("__Logs which contains " + keyword + "__ ");
            new List<string>(File.ReadAllLines(Path)).Where(l => l.Contains(keyword)).ToList().ForEach(Console.WriteLine);
            Console.WriteLine("_____________End_____________");
        }
    }

    class NAPDiskInfo
    {
        public void GetDiskInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
        }
    }

    class NAPFileInfo
    {
        public void GetFiloInfo(FileInfo file)
        {
            string str = null;
            str += "Время создания файла: ";
            str += file.CreationTime;
            str += "\nВремя последнего изменения: ";
            str += file.LastWriteTime;
            str += "\nПуть: ";
            str += file.FullName;
            Console.WriteLine($"{str}\n\n");
        }
    }
    class NAPDirInfo : NAPFileManager
    {

        public void GetDirInfo()
        {
            string dirName = "E:\\ООТП\\Готовые ЛР\\OOTP_3-sem\\LR_13";

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            Console.WriteLine($"Название каталога: {dirInfo.Name}");
            Console.WriteLine($"Название каталога родителя: {dirInfo.Parent}");
            Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo.Root}\n");
            string[] files = Directory.GetFiles(dirName);
            Console.WriteLine("Файлы:");
            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }
        public string GetDirInfo(string dirName)
        {

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            string str = null;
            str += ($"Название каталога: {dirInfo.Name}"); str += "\n";
            str += ($"Название каталога родителя: {dirInfo.Parent}"); str += "\n";
            str += ($"Полное название каталога: {dirInfo.FullName}"); str += "\n";
            str += ($"Время создания каталога: {dirInfo.CreationTime}"); str += "\n";
            string[] files = Directory.GetFiles(dirName);
            str += "Файлы:"; str += "\n";
            foreach (string s in files)
            {
                str += s; str += "\n";
            }
            return str;
        }
    }
    class NAPFileManager
    {
        public void Quest5()
        {
            NAPDirInfo dirInfo = new NAPDirInfo();
            DirectoryInfo dir = new DirectoryInfo("E:\\ООТП\\Готовые ЛР\\OOTP_3-sem\\LR_13\\NAPInspect");
            dir.Create();
            string str = dir.FullName;
            str += "\\someFile.txt";
            FileInfo file = new FileInfo(str);
            file.Create().Close();
            StreamWriter writer = new StreamWriter(file.FullName);
            writer.WriteLine(dirInfo.GetDirInfo("E:\\ООТП\\Готовые ЛР\\OOTP_3-sem\\LR_13"));
            writer.Close();
            str = null;
            str = dir.FullName;
            str += "\\newFile.txt";
            if (!File.Exists(str))
            {
                file.CopyTo(str);
            }
            file.Delete();
            dir.CreateSubdirectory("NAPFiles");
            var files = Directory.GetFiles(@"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_13\NAPInspect", "*.txt");
            foreach (string fl in files)
            {
                string name = fl.Substring(@"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_13\NAPInspect".Length + 1);
                File.Copy(Path.Combine(@"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_13\NAPInspect", name), Path.Combine(@"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_13\NAPInspect\NAPFiles", name), true);
            }
        }
        public void CreateZIP(string dir1)
        {
            string zip = @"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_13\NAP.zip";
            if (!File.Exists(@"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_13\NAP.zip"))
            {
                ZipFile.CreateFromDirectory(dir1, zip);
            }
        }
        public void ExtractZIP(string dir1)
        {
            string zip = @"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_13\NAP.zip";
            if (File.Exists(@"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_13\NAP.zip"))
            {
                ZipFile.ExtractToDirectory(zip, dir1);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NAPLog log = new NAPLog(@"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_13\naplogfile.txt");
                log.WriteToLog("An instance of the class NAPLog has been created");
                log.WriteToLog("An instance of the class");
                log.WriteToLog("NAPLog");
                log.FindInLog("NAPLog");
                log.ReadFromLog();
                NAPDiskInfo disks = new NAPDiskInfo();
                disks.GetDiskInfo();
                NAPFileInfo fileInfo = new NAPFileInfo();
                fileInfo.GetFiloInfo(log.file);
                NAPDirInfo dirInfo = new NAPDirInfo();
                dirInfo.GetDirInfo();
                NAPFileManager fileManager = new NAPFileManager();
                fileManager.Quest5();
                fileManager.CreateZIP(@"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_13\NAPInspect");
                fileManager.ExtractZIP(@"E:\ООТП\Готовые ЛР\OOTP_3-sem\LR_13\NAP");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exceptions: " + e.Message +
                "\nin method " + e.TargetSite);
            }
            Console.ReadKey();
        }
    }
}
