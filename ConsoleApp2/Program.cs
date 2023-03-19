// Практическая работа №1
// Использование языка С# для математических расчётов
// Студент группы 414, Богданов Александр Евгеньевич. 2023 год

using System.Text;

// Для заданной окружности и луча в 
// плоскости определить, пересекает ли луч
// окружность. 
// Найти координаты точек пересечения.

namespace CircleRayIntersection
{
    public struct Point
    {
        public double X { get; }
        public double Y { get; }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
    public class Intersection
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Богданов А.Е\n414 группа\nВариант 4\nПрактическая работа 1\nПоиск точек пересечения луча и окружности");
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Start the program");
                Console.WriteLine("2. Exit the program");
                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    // double[] coordinates = new double[7];
                    Console.WriteLine("SubMenu:");
                    Console.WriteLine("1. File input");
                    Console.WriteLine("2. User input");
                    Console.WriteLine("3. Exit the program");
                    Console.Write("Enter your choice: ");
                    choice = Console.ReadLine();
                    if (choice == "2")
                    {
                        double centerX, centerY, radius, startX, startY, directionX, directionY;
                        Console.WriteLine("Enter circle parameters:");
                        Console.Write("Center X: ");
                        centerX = ReadDouble("X");
                        Console.Write("Center Y: ");
                        centerY = ReadDouble("Y");

                        Console.Write("Radius: ");
                        radius = ReadPositiveDouble("Radius");

                        Console.WriteLine("Enter ray parameters:");
                        Console.Write("Start X: ");
                        startX = ReadDouble("X");
                        Console.Write("Start Y: ");
                        startY = ReadDouble("Y");

                        Console.Write("Direction X: ");
                        directionX = ReadDouble("X"); ;
                        Console.Write("Direction Y: ");
                        directionY = ReadDouble("Y");
                        double[] coordinates = new double[] { centerX, centerY, radius, startX, startY, directionX, directionY };
                        CalculateIntersectionPoints(new Point(centerX, centerY), radius, new Point(startX, startY), new Point(directionX, directionY), coordinates);
                    }
                    else if (choice == "1")
                    {
                        List<string> mass = new List<string>();

                        LoadFromFile(ref mass);
                        double centerX, centerY, radius, startX, startY, directionX, directionY;
                        centerX = double.Parse(mass[0]);
                        centerY = double.Parse(mass[1]);
                        radius = double.Parse(mass[2]);
                        startX = double.Parse(mass[3]);
                        startY = double.Parse(mass[4]);
                        directionX = double.Parse(mass[5]);
                        directionY = double.Parse(mass[6]);
                        double[] coordinates = new double[] { centerX, centerY, radius, startX, startY, directionX, directionY };
                        CalculateIntersectionPoints(new Point(centerX, centerY), radius, new Point(startX, startY), new Point(directionX, directionY), coordinates);

                    }
                    else if (choice == "3")
                    {
                        Console.WriteLine("\r\n");
                        continue;
                    }


                }
                else if (choice == "2")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.WriteLine();
            }
        }
        public static double[] CalculateIntersectionPoints(Point circleCenter, double radius, Point rayStart, Point rayDirection, double[] coordinates)
        {
            double dx = rayStart.X - circleCenter.X; //rayDirection.X - rayStart.X;
            double dy = rayStart.Y - circleCenter.Y; //rayDirection.Y - rayStart.Y;            
            double a = rayDirection.X * rayDirection.X + rayDirection.Y * rayDirection.Y;
            double b = 2 * (dx * rayDirection.X + dy * rayDirection.Y);
            double c = dx * dx + dy * dy - radius * radius;
            double discriminant = b * b - 4 * a * c;
            double[] result;

            if (discriminant < 0)
            {
                Console.WriteLine("Ray does not intersect circle.");
                return result = new double[] { };
            }

            double sqrtDiscriminant = Math.Sqrt(discriminant);
            double t1, t2;
            t1 = (-b + sqrtDiscriminant) / (2 * a);
            t2 = (-b - sqrtDiscriminant) / (2 * a);
            double x1 = rayStart.X + t1 * rayDirection.X;
            double y1 = rayStart.Y + t1 * rayDirection.Y;
            Point intersection1 = new Point(x1, y1);

            double x2 = rayStart.X + t2 * rayDirection.X;
            double y2 = rayStart.Y + t2 * rayDirection.Y;
            Point intersection2 = new Point(x2, y2);

            Console.WriteLine($"Intersection point 1: ({intersection1.X}, {intersection1.Y})");
            Console.WriteLine($"Intersection point 2: ({intersection2.X}, {intersection2.Y})");
            result = new double[] { intersection1.X, intersection1.Y, intersection2.X, intersection2.Y };
            SaveFile(intersection1, intersection2, coordinates);
            return result;
        }
        static double ReadDouble(string label)
        {
            string? input = Console.ReadLine();
            double result;
            while (!double.TryParse(input!, out result))
            {
                Console.WriteLine($"Invalid input for {label}. Please enter a valid number");
                input = Console.ReadLine();
            }
            return result;
        }
        static double ReadPositiveDouble(string label)
        {
            string? input = Console.ReadLine();
            double result;
            while (!double.TryParse(input!, out result))
            {
                Console.WriteLine($"Invalid input for {label}. Please enter a valid number");
                input = Console.ReadLine();
            }
            return result;
        }
        static void SaveFile(Point a, Point b, double[] coordinates)
        {

            Console.Write("Do you want to save the result to a file? (1/2): ");
            string? saveToFile = Console.ReadLine();
            if (saveToFile == "1")
            {
                Console.Write("Enter the file name: ");
                string? fileName = Console.ReadLine();
                try
                {
                    // true - запись данных в конец файла
                    // false - перезапись данных
                    StreamWriter sw = new StreamWriter(fileName!, true);
                    for (int i = 0; i < coordinates.Length; i++)
                    {
                        sw.WriteLine($"{coordinates[i]}");

                    }
                    sw.WriteLine($"Intersection point 1: ({a.X}, {a.Y})");
                    sw.WriteLine($"Intersection point 2: ({b.X}, {b.Y})");
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally save function block.");
                }

            }
        }

        public static void LoadFromFile(ref List<string> points) 
        {
            string line;
            try
            {
                Console.Write("Enter the full path to the file: ");
                string? filepath = Console.ReadLine();
                StreamReader sr = new StreamReader(filepath!);
                points = new List<string>();
                while ((line = sr.ReadLine()!) != null)
                {
                    points.Add(line);
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);

            }
            finally
            {
                Console.WriteLine("Executing finally load function block.");

            }


        }

    }
}





