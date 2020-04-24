using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Phonorum_5._2
{
    class Triangle
    {
        protected double a;
        protected double b;
        protected double beta;
        public Triangle(double a1, double b1, double betta1)
        {
            beta = betta1;
            a = a1;
            b = b1;
        }
        public Triangle()
        {
            a = 5;
            b = 7;
            beta = 50;
        }
        public Triangle(double x)
        {
            if (x == 60)
            {
                a = 6;
                b = 6;
            }
            else
            {
                a = 5;
                b = 7;
            }
            beta = x;
        }
        public double ToRad
        {
            get
            {
                return beta * 0.0175;
            }
        }
        public virtual double A
        {
            get
            {
                return a;
            }
            set
            {
                try
                {
                    if (value > 0)
                    {
                        a = value;
                    }
                    else
                    {
                        throw new Exception("Длина стороны должна быть больше нуля");
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error:" + error.Message);
                }
            }
        }
        public virtual double B
        {
            get
            {
                return b;
            }
            set
            {
                try
                {
                    if (value > 0)
                    {
                        b = value;
                    }
                    else
                    {
                        throw new Exception("Длина стороны должна быть больше нуля");
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error:" + error.Message);
                }
            }
        }
        public virtual double Beta
        {
            get
            {
                return beta;
            }
            set
            {
                try
                {
                    if ((value > 0) && (value < 180))
                    {
                        beta = value;
                    }
                    else
                    {
                        throw new Exception("Градусная мера угла должна быть больше нуля и меньше 180 градусов");
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error:" + error.Message);
                }
            }
        }

        public double C
        {
            get
            {
                return Math.Round(Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - 2 * a * b * Math.Cos(ToRad)), 3);
            }
        }
        public virtual bool IsSpecialCaseTriangle
        {
            get
            {
                if (a == b || b == (int)C || a == (int)C)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public double MiddleLine
        {
            get
            {
                return Math.Round(C / 2);
            }
        }
        public virtual double Perimetr()
        {
            return a + b + C;
        }
        public virtual double Area()
        {
            return Math.Round((a * b * Math.Sin(ToRad)) / 2, 3);
        }
        public virtual void Show()
        {
            Console.WriteLine("Длина стороны a равняется " + a + ", длина стороны b равняется " + b + ", угол между ними = " + beta);
        }
    }
    class PrTriangle : Triangle
    {
        public PrTriangle() : base(90)
        {

        }
        public PrTriangle(double x, double y) : base(x, y, 90)
        {

        }
        public override double Beta
        {
            get => base.Beta;
        }
        public override void Show()
        {
            Console.WriteLine("В прямоугольном треугольнике длина стороны a равняется " + a + ", длина стороны b равняется " + b + ", угол между ними = " + beta);
        }
        public override bool IsSpecialCaseTriangle
        {
            get
            {
                if (a / b == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
    class RavnostorTriangle : Triangle
    {
        public RavnostorTriangle() : base(60)
        {

        }
        public RavnostorTriangle(double a) : base(a, a, 60)
        {

        }
        public override double Beta
        {
            get => base.Beta;
        }
        public override void Show()
        {
            Console.WriteLine("В равностороннем треугольнике длина стороны a равняется " + a + ", длина стороны b равняется " + b + ", угол между ними = " + beta);
        }
        public override double Area()
        {
            return Math.Round(((a * a * Math.Sqrt(3)) / 4), 3);
        }
        public override double Perimetr()
        {
            return a * 3;
        }
        public override double A
        {
            get => base.A;
            set
            {
                try
                {
                    if (value > 0)
                    {
                        a = value;
                        if (b != a)
                        {
                            B = a;
                            Console.WriteLine("Треугольник равносторонний, ввиду чего изменены две стороны");
                        }
                    }
                    else
                    {
                        throw new Exception("Длина стороны должна быть больше нуля");
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error:" + error.Message);
                }
            }
        }
        public override double B
        {
            get => base.B;
            set
            {
                try
                {
                    if (value > 0)
                    {
                        b = value;
                        if (b != a)
                        {
                            A = b;
                            Console.WriteLine("Треугольник равносторонний, ввиду чего изменены две стороны");
                        }
                    }
                    else
                    {
                        throw new Exception("Длина стороны должна быть больше нуля");
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error:" + error.Message);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Triangle[] array = new Triangle[6];
            double a, b, beta;

            Console.WriteLine("Если вы хотите ввести значения для сторон прямоугольного тругольника, введите 1");
            int x = int.Parse(Console.ReadLine());
            if (x == 1)
            {
                Console.WriteLine("Введите значение для стороны a:");
                a = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите значение для стороны b:");
                b = double.Parse(Console.ReadLine());
                array[0] = new PrTriangle(a, b);
                Console.WriteLine("Значения для Вашего конструктора:");
                array[0].Show();
                Console.WriteLine("Сторона C равняется: " + array[0].C);
                Console.WriteLine("Площадь равняется: " + array[0].Area());
                Console.WriteLine("Периметр треугольника равняется: " + array[0].Perimetr());
                Console.WriteLine("Средняя линяя треугольнка равна: " + array[0].MiddleLine);
                Console.WriteLine("Треугольник равнобедренный? " + array[0].IsSpecialCaseTriangle);
            }
            array[1] = new PrTriangle();
            Console.WriteLine("Значения для конструктора по умолчанию:");
            array[1].Show();
            Console.WriteLine("Сторона C равняется: " + array[1].C);
            Console.WriteLine("Площадь равняется: " + array[1].Area());
            Console.WriteLine("Периметр треугольника равняется: " + array[1].Perimetr());
            Console.WriteLine("Средняя линяя треугольнка равна: " + array[1].MiddleLine);
            Console.WriteLine("Треугольник равнобедренный? " + array[1].IsSpecialCaseTriangle);
            Console.WriteLine("Введите 1, если вы желаете задать размеры равностороннего треугольника");
            x = int.Parse(Console.ReadLine());
            if (x == 1)
            {
                Console.WriteLine("Введите значение для стороны a:");
                a = double.Parse(Console.ReadLine());
                array[2] = new RavnostorTriangle(a);
                Console.WriteLine("Значения для Вашего конструктора: ");
                array[2].Show();
                Console.WriteLine("Сторона C равняется: " + array[2].C);
                Console.WriteLine("Площадь равняется: " + array[2].Area());
                Console.WriteLine("Периметр треугольника равняется: " + array[2].Perimetr());
                Console.WriteLine("Средняя линяя треугольнка равна: " + array[2].MiddleLine);
                Console.WriteLine("Треугольник равнобедренный? " + array[2].IsSpecialCaseTriangle);
            }
            array[3] = new RavnostorTriangle();
            Console.WriteLine("Значения для конструктора по умолчанию:");
            array[3].Show();
            Console.WriteLine("Сторона C равняется: " + array[3].C);
            Console.WriteLine("Площадь равняется: " + array[3].Area());
            Console.WriteLine("Периметр треугольника равняется: " + array[3].Perimetr());
            Console.WriteLine("Средняя линяя треугольнка равна: " + array[3].MiddleLine);
            Console.WriteLine("Треугольник равнобедренный? " + array[3].IsSpecialCaseTriangle);
            Console.WriteLine("Изменение длины стороны р/с треугольника. Введите новое значение:");
            array[3].A = double.Parse(Console.ReadLine());
            array[3].Show();
            Console.WriteLine("Введите 1, если вы желаете задать значения для обычного треугольника:");
            x = int.Parse(Console.ReadLine());
            if (x == 1)
            {
                Console.WriteLine("Введите значение для стороны a:");
                a = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите значение для стороны b:");
                b = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите значение для угла между ними:");
                beta = double.Parse(Console.ReadLine());
                array[4] = new Triangle(a, b, beta);
                Console.WriteLine("Значения для Вашего конструктора:");
                array[4].Show();
                Console.WriteLine("Сторона C равняется: " + array[4].C);
                Console.WriteLine("Площадь равняется: " + array[4].Area());
                Console.WriteLine("Периметр треугольника равняется: " + array[4].Perimetr());
                Console.WriteLine("Средняя линяя треугольнка равна: " + array[4].MiddleLine);
                Console.WriteLine("Треугольник равнобедренный? " + array[4].IsSpecialCaseTriangle);
            }
            array[5] = new Triangle();
            Console.WriteLine("Значения для конструктора по умолчанию:");
            array[5].Show();
            Console.WriteLine("Сторона C равняется: " + array[5].C);
            Console.WriteLine("Площадь равняется: " + array[5].Area());
            Console.WriteLine("Периметр треугольника равняется: " + array[5].Perimetr());
            Console.WriteLine("Средняя линяя треугольнка равна: " + array[5].MiddleLine);
            Console.WriteLine("Треугольник равнобедренный? " + array[5].IsSpecialCaseTriangle);
            Console.ReadLine();
        }
    }
}
