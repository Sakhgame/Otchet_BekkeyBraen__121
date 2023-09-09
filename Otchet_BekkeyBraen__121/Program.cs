// See https://aka.ms/new-console-template for more information
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

string path = "C:\\Users\\ikhar\\OneDrive\\Рабочий стол\\FileTxt.txt"; //Путь к файлу предеться установить самостоятельно, так как по какикм-то причинам неявный путь он не хочет воспринимать.

Console.WriteLine("Если хотите создать отчет нажмите 1");
Console.WriteLine("Если хотите узнать состояние созданного отчета нажмите 2");
Console.WriteLine("Если хотите удалить созданный отчет нажмите 3");
int n = int.Parse(Console.ReadLine());
if (n == 1)
{
    Console.WriteLine("Введите название отчета :");
    string name = Console.ReadLine();

    using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
    {
        byte[] buffer = Encoding.Default.GetBytes($"Название отчета: {name}");
        await fstream.WriteAsync(buffer, 0, buffer.Length);
    }
    Console.WriteLine("Введите кому адресован отчет :");
    string whom = Console.ReadLine();  

    using (FileStream fstream = new FileStream(path, FileMode.Append))
    {
        byte[] buffer = Encoding.Default.GetBytes($"\nКому адресован: {whom}");
        await fstream.WriteAsync(buffer, 0, buffer.Length);
    }

    Console.WriteLine("Введите от чьего имени написан отчет :");
    string from = Console.ReadLine();

    using (FileStream fstream = new FileStream(path, FileMode.Append))
    {
        byte[] buffer = Encoding.Default.GetBytes($"\nОт кого : {from}");
        await fstream.WriteAsync(buffer, 0, buffer.Length);
    }

    Console.WriteLine("Введите основной текст отчета :");
    string text = Console.ReadLine();

    using (FileStream fstream = new FileStream(path, FileMode.Append))
    {
        byte[] buffer = Encoding.Default.GetBytes($"\nОсновной текст отчета : {text}");
        await fstream.WriteAsync(buffer, 0, buffer.Length);
    }

    using (FileStream fstream = File.OpenRead(path))
    {
        byte[] buffer = new byte[fstream.Length];
        await fstream.ReadAsync(buffer, 0, buffer.Length);
        string textFromFile = Encoding.Default.GetString(buffer);
        Console.WriteLine($"\nТекст из файла: {textFromFile}");
    }
}
else if (n == 2)
{
    FileInfo fileInfo = new FileInfo(path);
    if (fileInfo.Exists)
    {
        Console.WriteLine($"Имя файла: {fileInfo.Name}");
        Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
        Console.WriteLine($"Размер: {fileInfo.Length}");
    }
    using (FileStream fstream = File.OpenRead(path))
    {
        byte[] buffer = new byte[fstream.Length];
        await fstream.ReadAsync(buffer, 0, buffer.Length);
        string textFromFile = Encoding.Default.GetString(buffer);
        Console.WriteLine($"\nТекст из файла: {textFromFile}");
    }
}
else if(n == 3)
{
    FileInfo fileInf = new FileInfo(path);
    if (fileInf.Exists)
    {
        fileInf.Delete();
    }
}



