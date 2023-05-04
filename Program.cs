using System.Reflection.Metadata;
using System.Text;

static void PrintEmptyDirectories(string path) //d
{
    string[] dirNames = Directory.GetDirectories(path);
    foreach (var dirName in dirNames)
    {
        if (Directory.GetFiles(dirName).Length == 0 && Directory.GetDirectories(dirName).Length == 0)
        {
            Console.WriteLine(dirName);
        }
        else
        {
            PrintEmptyDirectories(dirName);
        }
    }
}
static void PrintAllItems(string path) //f
{
    string[] fileNames = Directory.GetFiles(path);
    string[] dirNames = Directory.GetDirectories(path);
    foreach (var fileName in fileNames)
    {
        Console.WriteLine(fileName);
    }
    foreach (var dirName in dirNames)
    {
        Console.WriteLine(dirName);
        PrintAllItems(dirName);
    }
}
static string GetDirectoryWithMaxFiles(string path) //g
{
    string[] dirNames = Directory.GetDirectories(path);
    int maxFilesCount = 0;
    string dirWithMaxFiles = string.Empty;
    foreach (var dirName in dirNames)
    {
        int filesCount = Directory.GetFiles(dirName).Length;
        if (filesCount > maxFilesCount)
        {
            maxFilesCount = filesCount;
            dirWithMaxFiles = dirName;
        }
    }
    return dirWithMaxFiles;
}
static string GetDeepestItemPath(string path) //h
{
    string[] fileNames = Directory.GetFiles(path);
    string[] dirNames = Directory.GetDirectories(path);
    string deepestItemPath = string.Empty;
    int deepestDepth = 0;
    foreach (var fileName in fileNames)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        if (fileInfo.DirectoryName.Split('\\').Length > deepestDepth)
        {
            deepestDepth = fileInfo.DirectoryName.Split('\\').Length;
            deepestItemPath = fileName;
        }
    }
    foreach (var dirName in dirNames)
    {
        string itemPath = GetDeepestItemPath(dirName);
        if (itemPath.Split('\\').Length > deepestDepth)
        {
            deepestDepth = itemPath.Split('\\').Length;
            deepestItemPath = itemPath;
        }
    }
    return deepestItemPath;
}




DirectoryInfo dir = new DirectoryInfo(@"..\..\..\basedir\dir0");
if (dir.Exists)
{
    //    //a
    //    Console.WriteLine("Общее кол-во файлов" + dir.GetFileSystemInfos().Length); 
    //    //b
    //    Console.WriteLine("Подкаталоги:");
    //    DirectoryInfo[] dirs = dir.GetDirectories();
    //    foreach (var s in dirs)
    //    {
    //        Console.WriteLine(s.Name);
    //    }
    //    Console.WriteLine("Кол-во файлов: " + dir.GetFiles().Length);
    //    //c
    //    string[] fileNames = Directory.GetFiles(@"..\..\..\basedir\dir0");
    //    int txtFilesCount = 0;
    //        foreach (var fileName in fileNames)
    //        {
    //            if (Path.GetExtension(fileName).Equals(".txt"))
    //            {
    //                txtFilesCount++;
    //            }
    //        }
    //    Console.WriteLine($"Кол-во текстовых файлов: {txtFilesCount}" );
    //    //d
    //    Console.WriteLine("Имена всех пустых директорий:");
    //    PrintEmptyDirectories(@"..\..\..\basedir\");

    //    //e 
    //    string filePath = Path.Combine(@"..\..\..\basedir\dir0", "елки.txt");
    //    Console.WriteLine($"Полный абсолютный путь файла елки.txt: {filePath}");

    //    //f
    //    Console.WriteLine("Имена всех вложенных файлов и директорий:");
    //    PrintAllItems(@"..\..\..\basedir\");

    //    //g
    //    string dirWithMaxFiles = GetDirectoryWithMaxFiles(@"..\..\..\basedir\");
    //    Console.WriteLine($"Имя директории с максимальным количеством файлов: {dirWithMaxFiles}");

    //    // h) 
    //    string deepestItemPath = GetDeepestItemPath(@"..\..\..\basedir\");
    //    Console.WriteLine($"Полное имя (абсолютный путь) файла или директории с самой глубокой вложенностью: {deepestItemPath}");

    //    // i) 
    //    DriveInfo driveInfo = new DriveInfo("C:");
    //    long freeSpace = driveInfo.AvailableFreeSpace;
    //    Console.WriteLine($"Размер свободного дискового пространства на устройстве: {freeSpace} байт");

    //    // j)
    //    DriveInfo[] allDrives = DriveInfo.GetDrives();
    //    Console.WriteLine($"Количество устройств хранения (дисков): {allDrives.Length}");
    //    Console.WriteLine("Имена устройств хранения (дисков):");
    //    foreach (var drive in allDrives)
    //    {
    //        Console.WriteLine(drive.Name);
    //    }

    //    //Задание 3

    //    Directory.CreateDirectory(@"..\..\..\basedir\Picture");
    //    Directory.CreateDirectory(@"..\..\..\basedir\Texts\History");
    //    Directory.CreateDirectory(@"..\..\..\basedir\Texts\Horror\First");
    //    for (int i = 1; i < 6 + 1; i++)
    //    {
    //        var myFile = File.CreateText(@$"..\..\..\basedir\Picture\{i}.txt");
    //        myFile.Close();
    //    }
    //    FileInfo file1 = new FileInfo(@"..\..\..\basedir\Picture\5.txt");
    //    file1.CopyTo(@"..\ ..\..\basedir\Picture\5000.txt", true);
    //    file1.Delete();
    //    Console.WriteLine("5.txt заменен");
    //    File.Delete(@"..\..\..\basedir\Picture\6.txt");
    //    Console.WriteLine("6.txt Удален");
    //    Console.WriteLine("Какой файл необходимо удалить?\n1,2,3,4,5000");
    //    int n = Convert.ToInt32(Console.ReadLine());
    //    if (n == 1 || n == 2 || n == 3 || n == 4 || n == 5000)
    //    {
    //        File.Delete(@$"..\..\..\basedir\Picture\{n}.txt");
    //        Console.WriteLine($"{n}.txt Удален");
    //    }
    //    else
    //    {
    //        Console.WriteLine("Нет такого Файла");
    //    }
    //    Directory.Delete(@"..\..\..\basedir\Picture", true);
    //    Console.WriteLine(@"basedir\Picture Удален");
    //    Directory.Delete(@"..\..\..\basedir\Texts\Horror", true);
    //    Console.WriteLine(@"basedir/Texts/Horror Удален");
    //    Console.WriteLine();


    //}

    ////Задание 4
    ////a)
    //var a = new FileStream(@"..\..\..\basedir\data\dataset_1.txt", FileMode.Open);
    //byte[] buffer = new byte[a.Length];
    //a.Read(buffer, 0, buffer.Length);
    //string Text = Encoding.Default.GetString(buffer);
    //string[] b = Text.Split(" ");
    //double[] b1 = new double[b.Length];
    //for (int i = 0; i < b.Length; i++)
    //{
    //    b1[i] = Convert.ToDouble(b[i]);
    //}
    //Console.WriteLine($"a+b={b1[0] + b1[1]},a*b={b1[0] * b1[1]},a+b^2={b1[0] + Math.Pow(b1[1], 2)}");
    //Console.WriteLine();

    ////b)
    //a = new FileStream(@"..\..\..\basedir\data\dataset_2.txt", FileMode.Open);
    //buffer = new byte[a.Length];
    //a.Read(buffer, 0, buffer.Length);
    //Text = Encoding.Default.GetString(buffer);
    //b = Text.Split("\n");
    //int count = 0;
    //for (int i = 0; i < b.Length; i++)
    //{
    //    if (Convert.ToDouble(b[i]) % 2 == 0)
    //    {
    //        count++;
    //    }
    //}
    //Console.WriteLine("Кол-во четных чисел:" + count);
    //Console.WriteLine();

    ////c)
    //var myFile = File.CreateText(@"..\..\..\basedir\data\res_3.txt");
    //myFile.Close();
    //a = new FileStream(@"..\..\..\basedir\data\dataset_3.txt", FileMode.Open);
    //buffer = new byte[a.Length];
    //a.Read(buffer, 0, buffer.Length);
    //Text = Encoding.Default.GetString(buffer);
    //b = Text.Split(" ");
    //StringBuilder stringBuilder = new StringBuilder();
    //foreach (string temp in b)
    //{
    //    if (Convert.ToDouble(temp) < 9999)
    //    {
    //        Console.Write(temp + " ");
    //        stringBuilder.Append(temp);
    //        stringBuilder.Append(" ");
    //    }
    //}
    //using (FileStream fileStream = new FileStream(@"..\..\..\basedir\data\res_3.txt", FileMode.OpenOrCreate))
    //{
    //    byte[] array = Encoding.Default.GetBytes(stringBuilder.ToString());
    //    fileStream.Write(array, 0, array.Length);
    //    fileStream.Close();
    //}
    //Console.WriteLine("Числа добавлены");
    //Console.WriteLine();

    ////d)
    //a = new FileStream(@"..\..\..\basedir\data\dataset_4.txt", FileMode.Open);
    //buffer = new byte[a.Length];
    //a.Read(buffer, 0, buffer.Length);
    //Text = Encoding.Default.GetString(buffer);
    //b = Text.Split(" ");
    //double max = 0;
    //foreach (string temp in b)
    //{
    //    if (Convert.ToDouble(temp) > max)
    //        max = Convert.ToDouble(temp);
    //}
    //Console.WriteLine(max);
    //using (FileStream fileStream = new FileStream(@"..\..\..\basedir\data\res_3.txt", FileMode.Append))
    //{
    //    byte[] array = Encoding.Default.GetBytes(max.ToString());
    //    fileStream.Write(array, 0, array.Length);
    //    fileStream.Close();
    //}
    //Console.WriteLine("Число добавлено");
    //Console.WriteLine();

    ////e
    //a = new FileStream(@"..\..\..\basedir\data\dataset_5.txt", FileMode.Open);
    //buffer = new byte[a.Length];
    //a.Read(buffer, 0, buffer.Length);
    //Text = Encoding.Default.GetString(buffer);
    //b = Text.Split(" ");
    //foreach (string temp in b)
    //{
    //    Console.WriteLine(temp.ToUpper());
    //}
    
   
} 
//Задание 5
PersonData[] person = new PersonData[3];
person[0] = new PersonData("Абзалов", 183, 80, new DateTime(2005, 2, 2));
person[1] = new PersonData("Иванова", 170, 66, new DateTime(2003, 12, 11));
person[2] = new PersonData("Баталов", 180, 55, new DateTime(2002, 10, 4));

string PathToFile = @"..\..\..\basedir\data\persons.txt";

using (StreamWriter writer = File.CreateText(PathToFile))
{
    foreach(PersonData personData in person)
    {
        writer.WriteLine($"{personData.LastName};{personData.Height};{personData.Weight};{personData.Birth.ToString("dd.MM.yyyy")}");
    }
}
Console.WriteLine($"Данные записаны в файл {PathToFile}");

Console.WriteLine("Введите данные для нового объекта: ");
PersonData obj1 = new();
obj1.ConsoleInp();
PersonData obj2 = new();
obj2.ConsoleInp();

using (StreamWriter writer = File.AppendText(PathToFile))
{
    writer.WriteLine($"{obj1.LastName};{obj1.Height};{obj1.Weight};{obj1.Birth.ToString("dd.MM.yyyy")}");
    writer.WriteLine($"{obj2.LastName};{obj2.Height};{obj2.Weight};{obj2.Birth.ToString("dd.MM.yyyy")}");
}
Console.WriteLine($"Данные записаны в файл {PathToFile}");

//a
string[] lines = File.ReadAllLines(PathToFile);

PersonData[] people = new PersonData[lines.Length];
for (int i = 0; i < lines.Length; i++)
{
    string[] fields = lines[i].Split(';');
    string lastName = fields[0];
    int height = int.Parse(fields[1]);
    double weight = double.Parse(fields[2]);
    DateTime dateOfBirth = DateTime.ParseExact(fields[3], "dd.MM.yyyy", null);
    people[i] = new PersonData(lastName, height, weight, dateOfBirth);
}

foreach (PersonData pers in people)
{
    int age = DateTime.Today.Year - pers.Birth.Year;
    if (pers.Birth > DateTime.Today.AddYears(-age))
    {
        age--;
    }
    Console.WriteLine($"Фамилия: {pers.LastName}; Возраст: {age} лет");
}

//б
double avgHeight = people.Average(p => p.Height);
double avgWeight = people.Average(p => p.Weight);

Console.WriteLine($"Средний рост в группе: {avgHeight:F2} см");
Console.WriteLine($"Средний вес в группе: {avgWeight:F2} кг");

using (StreamWriter writer = File.AppendText(PathToFile))
{
    writer.WriteLine($"Средний рост в группе: {avgHeight:F2} см");
    writer.WriteLine($"Средний вес в группе: {avgWeight:F2} кг");
}

//в
using (StreamWriter sw = File.CreateText(@"..\..\..\basedir\data\overweight.txt"))
{
   
    foreach (PersonData personData in people)
    {
        double idealWeight = personData.Height - 100 + 10;
        if (personData.Weight > idealWeight)
        {
            Console.WriteLine($"{personData.LastName} имеет избыточный вес: {personData.Weight:F2} кг (идеальный вес: {idealWeight:F2} кг)");
            sw.WriteLine($"{personData.LastName};{personData.Height};{personData.Weight};{personData.Birth:dd.MM.yyyy}");
        }
    }
}
