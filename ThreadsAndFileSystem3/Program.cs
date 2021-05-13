using System;
using System.IO;
using System.Threading.Tasks;

namespace ThreadsAndFileSystem3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // создаем каталог для файла
            string path = @"D:\SomeDir3";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            Console.WriteLine("Введите строку для записи в файл:");
            string text = Console.ReadLine();

            // запись в файл
            using (FileStream fstream = new FileStream($"{path}\note.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // асинхронная запись массива байтов в файл
                await fstream.WriteAsync(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }

            // чтение из файла
            using (FileStream fstream = File.OpenRead($"{path}\note.txt"))
            {
                byte[] array = new byte[fstream.Length];
                // асинхронное чтение файла
                await fstream.ReadAsync(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }

            Console.ReadLine();
        }
    }
}