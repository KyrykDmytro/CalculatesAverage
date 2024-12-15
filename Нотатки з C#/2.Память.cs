using System;
using System.Text;

namespace Передача_масива_в__метод
{
    class Program
    {
        public static void Main()
		{
			//МАСИВИ----------------------------------------------------------------------------------------
                var array1 = new int[3];
                array1[0] = 1;
                array1[1] = 2;
                array1[2] = 3;

                var array2 = new int[] { 1, 2, 3 };
                var array3 = new[] { 1, 2, 3 };
                var array4 = new[] { "a", "b", "c" };
                //Здесь компилятор выдаст ошибку, поскольку он не может определить тип массива.
                //var array5 = new[] { 1, "2", 3 };
                var array6 = new object[] { 1, "2", 3 };

                for (int i = 0; i < array2.Length; i++)
                    Console.WriteLine(array2[i]);
                foreach (var e in array2)//Неможливо допустити помилку index
                    Console.WriteLine(e);

            //БAГАТО ВИМІРНІ МАСИВИ----------------------------------------------------------------------------------------
                int[,] twoDimensionalArray = new int[2, 3];
 
                twoDimensionalArray[1, 2] = 1;

                for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)// foreach буде працювати так само тільки без зміних index'ів
                    for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                        twoDimensionalArray[i, j] = 10 * i + j;
                
                Console.WriteLine(twoDimensionalArray.Length); // Output: 6
                int[,,] threeDimensionalArray = new int[2, 3, 4];

            //МАСИВИ В МАСИВІ----------------------------------------------------------------------------------------
                int[][] array;
                array = new int[2][];

                //Так можно - array инициализирован
                Console.WriteLine(array.Length);

                //Выдаст исключение, ведь нулевой массив в этом массиве массивов не инициализирован
                Console.WriteLine(array[0].Length);

                array[0] = new int[3];
                //Теперь это сработает, потому что мы проинициализировали нулевой элемент
                Console.WriteLine(array[0].Length);
                //А это по-прежнему вызовет исключение, потому что первый элемент не инициализирован
                Console.WriteLine(array[1].Length);
                
                //В отличие от многомерного массива, индексация производится двумя парами скобок
                array[0][0] = 1;

                //В отличие от многомерного массива, являющегося прямоугольником или параллелепипедом,
                //в массиве массивов все хранимые массивы могут быть разной длины
                array[1] = new int[10];

                //Могут быть массивы массивов массивов...
                int[][][] array1=new int[2][][];

                //или массивы двумерных массивов
                int[][,] array2=new int[2][,];
                
                //а также двумерные массивы массивов
                int[,][] array3 = new int[2, 3][];

            //Списки----------------------------------------------------------------------------------------
                List<int> list = new List<int>();

                list.Add(0);
                list.Add(2);
                list.Add(3);
                list.Insert(1, 1);
                list.RemoveAt(0);

                foreach (var e in list)
                    Console.WriteLine(e);

            //Словники----------------------------------------------------------------------------------------
                var array = new[] { "A", "AB", "B", "A", "B", "B" };

                var dictionary = new Dictionary<string, int>();

                foreach (var e in array)
                {
                    if (!dictionary.ContainsKey(e)) dictionary[e] = 0;
                    dictionary[e]++;
                }

                foreach (var e in dictionary)
                {
                    Console.WriteLine(e.Key + "\t" + e.Value);
                }

            //StringBuilder----------------------------------------------------------------------------------------
                //StringBuilder - это класс, представляющий собой изменяемую строку
                var builder = new StringBuilder();//Для роботи з ними потрібно код в 2 lien

                //Он содержит различные методы вставки, добавления, удаления и т.д.
                builder.Append("Some ");
                builder.Append("string ");
                builder.Append("#15");
                builder.Remove(0, 5);
                builder.Insert(0, "test ");

                //Также можно манипулировать отдельными символами
                builder[0] = 'T';

                //StringBuilder можно превратить в строку
                var str = builder.ToString();
                Console.WriteLine(str);

                //Не нужно полностью заменять строки на StringBuilder,
                //Только в тех случаях, когда действительно выполняется много преобразований

                var str = "";
                for (int i = 0; i < 50000; i++)//<- погано
                {
                    str += i.ToString() + ", ";
                }

                var builder = new StringBuilder();//<- добре
                for (int i = 0; i < 50000; i++)
                {
                    builder.Append(i);
                    builder.Append(", ");
                }
            //Файли і каталоги------------------------------------------------------------------------------------------
                // Запись текста в файл:
                File.WriteAllText("1.txt", "Hello, world!");

                // Путь относительно "текущей директории", которую можно узнать так:
                Console.WriteLine(Environment.CurrentDirectory);
                // Обычно это директория, в которой была запущена ваша программа

                // А размещение запущенного exe-файла можно узнать так:
                Console.WriteLine(Assembly.GetExecutingAssembly().Location);

                // Сформировать абсолютный путь по относительному можно так:
                Console.WriteLine(Path.Combine(Environment.CurrentDirectory, "1.txt"));

                // Записать строки в файл,
                // разделив их символом конца строки (\r\n для Windows и \n для Linux и MacOS)
                File.WriteAllLines("2.txt", new[] {"Hello", "world"});

                // Записать в файл массив байтов в бинарном виде:
                File.WriteAllBytes("3.dat", new byte[10240]);

                //Повертає масив строк з назвами фаілів(Каталог) в тикичім деректорії, які начинаются на літеру "H"
                Directory.GetFiles(".", "H*")

                // Чтение данных из файла
                string text = File.ReadAllText("1.txt");
                string[] lines = File.ReadAllLines("2.txt");
                byte[] bytes = File.ReadAllBytes("3.dat");

                // Все файлы в текущей директории (точка в пути означает текущую директорию)
                foreach (var file in Directory.GetFiles(".")){
                    Console.WriteLine(file);
                    }
            //Кодировка-------------------------------------------------------------------------------------------------------
                //Английский язык и базовые символы одинаковы во всех кодировках
                //Однако, при сохранении текста в кодировке UTF добавляется специальный маркер файла,
                //по которому текстовые редакторы определяют кодировку текста
                WriteAndRead("Hello!", Encoding.ASCII);
                WriteAndRead("Hello!", Encoding.UTF8);

                //Русские буквы нельзя сохранять в ASCII
                WriteAndRead("Привет!", Encoding.ASCII);

                //Можно попробовать в кодировке локали, но этого лучше не делать:
                //В этом случае файл не самодостаточен, для его прочтения нужно знать
                //какая кодировка у вас в локали
                WriteAndRead("Привет!", Encoding.Default);

                //UTF-8 - лучшее решение!
                //Русские буквы кодируются в ней двумя байтами
                WriteAndRead("Привет!", Encoding.UTF8);

                //А китайские иероглифы - уже тремя
                WriteAndRead("你好!", Encoding.UTF8);
        }
                static void WriteAndRead(string text, Encoding encoding)
                {
                    Console.WriteLine("{0}, encoding {1}", text, encoding.EncodingName);
                    //Так можно записать в файл некий текст
                    //Альтернативы - WriteAllLines (записывает массив строк) или WriteAllBytes (массив байт)
                    File.WriteAllText("temp.txt", text, encoding);

                    //Так можно прочитать массив байт
                    //Альтернативы интуитивно понятны
                    var bytes = File.ReadAllBytes("temp.txt");
                    foreach (var e in bytes)
                        Console.Write("  {0} ", (char)e);
                    Console.WriteLine();
                    foreach (var e in bytes)
                        Console.Write("{0:D3} ", e);
                    Console.WriteLine();

                    //В С# есть явное преобразование типа byte в char. 
                    //Это — наследие прежних эпох, когда кодировка была только одна.
                    //Злоупотреблять этим не стоит

                }
    }
}