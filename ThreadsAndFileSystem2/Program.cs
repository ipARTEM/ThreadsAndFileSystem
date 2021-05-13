using System;
using System.IO;

namespace ThreadsAndFileSystem2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Получение списка файлов и подкаталогов
            string dirName = "D:\\";

            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }

            //Создание каталога
            string path = @"C:\SomeDir";
            string subpath = @"program\avalon";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);


            //Получение информации о каталоге
            string dirName2 = "C:\\Program Files";

            DirectoryInfo dirInfo2 = new DirectoryInfo(dirName);

            Console.WriteLine($"Название каталога: {dirInfo2.Name}");
            Console.WriteLine($"Полное название каталога: {dirInfo2.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo2.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo2.Root}");

            //Удаление каталога
            string dirName3 = @"C:\SomeFolder";

            try
            {
                DirectoryInfo dirInfo3 = new DirectoryInfo(dirName);
                dirInfo3.Delete(true);
                Console.WriteLine("Каталог удален");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //2-й вариант
            //string dirName4 = @"C:\SomeFolder";
            //Directory.Delete(dirName4, true);

            //Перемещение каталога
            string oldPath = @"C:\SomeFolder";
            string newPath = @"C:\SomeDir";
            DirectoryInfo dirInfo5 = new DirectoryInfo(oldPath);
            if (dirInfo5.Exists && Directory.Exists(newPath) == false)
            {
                dirInfo5.MoveTo(newPath);
            }
        }
    }
}
