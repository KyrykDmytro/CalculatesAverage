using System;//<-інструкція
using System.Globalization;

namespace Hello_world //<-пространство імон(колекція класов)
{
    /*Відкладка
	F9 - ставить брек поін в строці де знаходиться курсор(можна, ще 
	нажати на тулетолію з ліва)
	F10 - виповняє строчку када на якій стоїть брекпоін 
	і переходе до наступної і зупинняється
	F5 - відновляє хід роботи до кінця або наступного брекпоіна
	F11 - перемістити стрілку
	NaN - відсутність числа в типі double, та появляється підча вичеслення кореня від відємного 
	числа або 0.0/0.0
	*/
	
	public enum Color
	{
		Red,
		Green,
		Blue
	}

    class Program
    {
        static string GetColorNameGoodWay(Color color)
		{
			if (color == Color.Red) return "Красный";
			if (color == Color.Blue) return "Синий";
			if (color == Color.Green) return "Зеленый";
			throw new Exception("Unknown color " + color);
			Color color1 = color;
			/* 
			В большинстве случаев писать нужно именно так.
			Если появится новый цвет, то "магическая" строка throw new Exception
			сгенерирует исключительную ситуацию, которая прервет работу программы.

			Обычно падение программы в таком случае лучше, чем некорректная работа.
				(Лучше вообще не стрелять, чем стрелять не туда)
			*/
		}
        
        static string globalVariable = "Globaly";//<-глобальна зміна

        static void Main(string[] args)
        {
            Console.WriteLine("Es:{0}", "Hello World!");
            Console.ReadKey();

            string localVariable = "Local variable";//<-локаольна зміна
//------------------------------------------------------------------------------------------------------
//Типи даних, кастовання та строки
			int integerNumber;
			integerNumber = (int)Math.Round(34.67);

			double doubleNumber = 12.34;

			float floatNumber = 1.234f;

			long longIntegerNumber = 3000000000000L;

            int number = int.Parse("42");
			string numString = 42.ToString();
            char c = numString[1];
			double number2 = double.Parse("34.42"); // Зависит от настроек операционной системы
			//Следующий вызов не зависит от настроек и всегда ожидает точку в качестве разделителя:
			number2 = double.Parse("34.42", CultureInfo.InvariantCulture);//для цего потрібно код 2 лінії
//-------------------------------------------------------------------------------------------------------
//Логічний тип
			bool comparisonResult = 6 > 7;
            //Константы истины и лжи
            bool trueValue = true;
            bool falseValue = false;
            //Все операции сравнения
            Console.WriteLine(5 == 6);
            Console.WriteLine(5 != 6);
            Console.WriteLine(5 < 5);
            Console.WriteLine(5 <= 5);
            // Операция "И", или конъюнкция
            Console.WriteLine((5 < 4) && (3 < 4));
            // Операция "ИЛИ", или дизъюнкция
            Console.WriteLine((5 < 4) || (3 < 4));
            // Операция "НЕ", или отрицание
            Console.WriteLine(!(5 < 4));
//-------------------------------------------------------------------------------------------------------
           
		    var a = Math.Sin(((13 % 6) / (1 + 2))) * 2//<- арифметика та компіляційний цукор var

            var a = int.Parse(Console.ReadLine());

            if (a < 0) Console.WriteLine("A is negative");
			else if (a < 10) Console.WriteLine("A consists of one digit");
			else
			{
				Console.WriteLine("A consists");
			}

            var sum = 0;
            while (true){//конструкція "double break"
				bool stop = false;
				while (true){
					sum += int.Parse(Console.ReadLine());
					if (sum > 100){
						stop = true;
						break;
					}
				}
				if (stop){
					break;
				}
				/* Допустим, мы хотим читать из консоли числа и суммировать их, 
				* пока не будет введена пустая строка. Как это сделать?
				* Хочется написать как-то так:
					while (line != "")
					{
						string line = Console.ReadLine(); 
						sum += int.Parse(line);
						line = Console.ReadLine();
					}
				* но нельзя, потому что line видна только внутри блока while, но не в его условии
				*/
            string text = "qweas"
            for(int i = 0; i <= text.Length; i++)
            {
				Console.Write(text[i]);
            }
//----------------------------------------------------------------------------------------------------------
//Перевірка
			var str = Console.ReadLine();
            int a;
            try{
                a = int.Parse(str);
            }
            catch{
                Console.WriteLine("Error a not = int");
                return;
            }
            if(a == 0){
                Console.WriteLine("Error not did x/0");
            }
            else{
                Console.WriteLine(1 / a);
            }
//----------------------------------------------------------------------------------------------------------
        }
    }
}