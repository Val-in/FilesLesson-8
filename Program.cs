using System;
using System.IO;
using System.Runtime;

namespace FilesLesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            // получим системные диски
            DriveInfo[] drives = DriveInfo.GetDrives(); //что это такое?
            GetCatalogsD();
            GetCatalogsC();
            // Пробежимся по дискам и выведем их свойства
            foreach (DriveInfo drive in drives/*.Where(DriveType == DriveType.Fixed)*/) //почему тут не работает эта логика?
            {
                Console.WriteLine($"Название: {drive.Name}"); //почему у drive. можно вызвать методы?
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize}");
                    Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
            GetFilesNumberC();
            GetFilesNumberD();
            CreateFolderD();
            GetFilesNumberDAfterCreation();
            NewFolderDeletion();
            GetFilesNumberDAfterDeletion();

            Console.ReadKey();
        }

        static void GetCatalogsD()
        {
            string dirName = @"D:\\"; // для Windows  тут будет "C:\\"
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);
            }
        }
        static void GetCatalogsC()
        {
            string dirName = @"C:\\"; // для Windows  тут будет "C:\\"
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine();
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);
            }

            Console.WriteLine();
        }
        static void GetFilesNumberC()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:\\"); // зачем тут создавать новый экземпляр (new DirectoryInfo)?
                //почему не делаем, как в методах выше?
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length);
                    Console.WriteLine(dirInfo.GetFiles().Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void GetFilesNumberD()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"D:\C Language"); // зачем тут создавать новый экземпляр (new DirectoryInfo)?
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length);
                    Console.WriteLine(dirInfo.GetFiles().Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void CreateFolderD()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"D:\C Language"); // влияет ли на что-то, если везде dirInfo?
            if (!dirInfo.Exists)
                dirInfo.Create();
            Console.WriteLine("Папка существует!!");

            dirInfo.CreateSubdirectory("New Folderrrr");

            Console.WriteLine($"Название каталога: {dirInfo.Name}");
            Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo.Root}");

        }

        static void GetFilesNumberDAfterCreation()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"D:\C Language"); // зачем тут создавать новый экземпляр (new DirectoryInfo)?
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length);
                    Console.WriteLine(dirInfo.GetFiles().Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void NewFolderDeletion()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"D:\C Language\New Folderrrr"); // влияет ли на что-то, если везде dirInfo?
            if (!dirInfo.Exists)
                try
                {
                    DirectoryInfo dirInfoNewFolder = new DirectoryInfo(@"D:\C Language\New Folderrrr"); //почему первый try пропускает?
                    string newPath = @"Recycle Bin";

                    dirInfo.MoveTo(newPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            try
            {
                dirInfo.Delete(true); // Удаление со всем содержимым
                Console.WriteLine("Каталог удален");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void GetFilesNumberDAfterDeletion()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"D:\C Language"); // зачем тут создавать новый экземпляр (new DirectoryInfo)?
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length);
                    Console.WriteLine(dirInfo.GetFiles().Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
