public class PersonData
{
    public string LastName { get; set; }
    public int Height { get; set; }

    public double Weight { get; set; }
    public DateTime Birth { get; set; }

    public PersonData() : this("null", 0,0.0,new DateTime(default)) { }
    
    public PersonData(string lastname, int height, double weight, DateTime birth)
    {
        LastName = lastname;
        Height = height;
        Weight = weight;
        Birth = birth;
    }
    public void ConsoleInp()
    {
        Console.WriteLine("Фамилия: ");
        LastName = Console.ReadLine();
        Console.WriteLine("Рост: ");
        Height = int.Parse(Console.ReadLine());
        Console.WriteLine("Вес: ");
        Weight = double.Parse(Console.ReadLine());
        Console.WriteLine("Дата рождения: ");
        Birth = DateTime.ParseExact(Console.ReadLine(),"dd.MM.yyyy",null);
    }


}