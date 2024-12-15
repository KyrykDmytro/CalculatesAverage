public class Student
{
    public int Age; //<- динамічне поле
    public string FirstName;

    public static string University;//<- Статичне поле і одинакове для всіхі класві Student

    public void PrintInfo()//<-динаміка
    {
        Console.WriteLine("{0} {1}", Age, FirstName);
    }

    public static void PrintInfoStatic(Student student)//<-статика
    {
        Console.WriteLine("{0} {1}", student.Age, student.FirstName);
    }
}

//----------------------------------------------------------------------------------------------------------------------------
//Роширення Класу(для нього створуєтся static клас і це клас в якому все є статисне)
public static class StudentExtensions
{//принято назву таким класам писати: клас_яки_розшироють + "Extensions"
    //можна роширити клас
    public static void PrintAge(this Student stu)//магія роширеня є в команді "this Student"
    {
        Console.WriteLine(stu.Age);
    }
    //можна перегрузити вже ісеиючий метод
    public static void PrintInfo(this Student stu, string title)
    {
        Console.WriteLine("{0}: {1}, {2}", title, stu.Age, stu.FirstName);
    }
}
//роширеня метода використовуючи метод
public static class RandomExtensions
{
	public static double NextDouble(this Random rnd, double min, double max)
	{
		return rnd.NextDouble() * (max - min) + min;
	}
}
//можна роширювати базові класи .Net як int[]
public static class ArrayExtensions n
{
	public static void Swap(this int[] array, int i, int j)
	{
		var t = array[i];
		array[i] = array[j];
		array[j] = t;
	}
}
//Tuple---------------------------------------------------------------------------------------------------------------------------
static Tuple<bool, int> GetNumber()
{
    for(int i = 0;i < 10; i++)
    {
        if (Console.KeyAvailable) 
        {
            return new Tuple<bool, int>(true, 10);
        }
        Thread.Sleep(100);
    }
    return Tuple.Create(false, 0);
}
//out дає можливість вкладати в ньго якесь значеня але не можна читати-------------------------------------------------------------
public static bool TryGetNumber(out int value)
{
    //Console.WriteLine(value); // value не может быть использовано до присвоения внутри метода
    for (int i = 0; i < 10; i++)
    {
        if (Console.KeyAvailable)
        {
            value = rnd.Next(100);
            return true;
        }
        Thread.Sleep(100);
    }
    //value обязано быть присвоено до выхода из метода
    value = 0;
    return false;
}
//Nullable це сентаксичиий сахар-------------------------------------------------------------------------------------------------
static int? TryGetNumber(){
    for(int i = 0;i < 10; i++)
    {
        if (Console.KeyAvailable) 
        {
            return 10;
        }
        Thread.Sleep(100);
    }
    return null;
}
static void Main(){
    var i = TryGetNumber();
    if(i != null)//не справжній/фалшивий null
        Console.WriteLine(i);
    else
        Console.WriteLine("Error");
}
//----------------------------------------------------------------------------------------------------------------------------


public class Program
{
    //Student — это тип данных, который определяет, какую информацию
    // и как мы храним в файле о студенті

    //мы можем создать массив из Student, потому что Student — это такой же тип, как string или int
    static Student[] students;//створуємо масив екземплярів обєктів

    static void Main()
    {
        students = new Student[2];
        //Классы — это ссылочные типы, поэтому их нужно инициализировать.
        //Можно сделать собственный тип-значение, но это мы рассмотрим позже.
        students[0] = new Student();

        students[0].FirstName = "John";
        Student.University = "P1";//<- Оброщенія до статичного поля
        //Можно делать это с помощью сокращенной инициализации — это то же самое
        students = new[]
        {
            new Student {  FirstName = "John", Age = 19 },
            new Student {  FirstName = "William" }
        };

        Student.PrintInfoStatic(students[0]);//<-статика
        students[0].PrintInfo();//<-динаміка
        students[1].PrintAge();//<-роширений метод, лічится як динамісний
        students[1].PrintInfo("Студент1");//<-метод з роширеною перегрузкою

        var array = new int[] { 1, 2, 3, 4, 5 };
		array.Swap(0, 1);

    }
}