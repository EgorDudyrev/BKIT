using System;

namespace Lab2
{
	interface IPrint
	{
		void Print();
	}

	/// <summary>
	/// Абстрактный класс геом. фигуры
	/// </summary>
	abstract class Figure
	{
		/// <summary>
		/// Вычисление площади фигуры
		/// </summary>
		public abstract double Area();
	}
	class Rect : Figure, IPrint
	{
		/// <summary>
		/// Конструктор прямоугольника по ширине и высоте
		/// </summary>
		/// <param name="w">Ширина.</param>
		/// <param name="h">Высота.</param>
		public Rect(double w, double h) {this.Width = w; this.Height = h;}

		public override double Area() {return Width*Height;}

		public override string ToString ()
		{
			return string.Format ("Прямоугольник: Ширина = {0}, Высота = {1}, Площадь = {2}.", Width, Height, Area());
		}
		public void Print() {Console.WriteLine(ToString());}

		public double Width { get; protected set;}
		public double Height { get; protected set;}
	}
	class Quadr : Rect, IPrint
	{
		/// <summary>
		/// Конструктор квадрата по длине стороны
		/// </summary>
		/// <param name="a">Длина стороны.</param>
		public Quadr(double a):base(a,a) {}

		public override string ToString ()
		{
			return string.Format ("Квадрат: Длина стороны = {0}, Площадь = {1}", Height, Area());
		}
		//public void Print() {Console.WriteLine(ToString());}
	}
	class Circle : Figure, IPrint
	{
		/// <summary>
		/// Конструктор круга по радиусу
		/// </summary>
		/// <param name="r">Радиус.</param>
		public Circle(double r) {this.Rad = r;}

		public override double Area (){ return Math.PI * Rad * Rad;	}

		public override string ToString ()
		{
			return string.Format ("Круг: Радиус = {0}, Площадь = {1}", Rad, Area());
		}
		public void Print() {Console.WriteLine(ToString());}

		/// <summary>
		/// Получать и устанавливать радиус круга
		/// </summary>
		/// <value>Радиус.</value>
		public double Rad { get; protected set;}
	}


	class MainClass
	{
		public static void Main (string[] args)
		{
			double a, b;
			a = AskNumber ("Введите ширину прямоугольника: ");
			b = AskNumber ("Введите высоту прямоугольника: ");
			Rect rect = new Rect(a,b);
			rect.Print ();
			Console.WriteLine ();

			a = AskNumber ("Введите сторону квадрата: ");
			Quadr quadr = new Quadr (a);
			quadr.Print ();
			Console.WriteLine ();

			a = AskNumber ("Введите радиус круга: ");
			Circle circle = new Circle (a);
			circle.Print ();
		}

		static double AskNumber(string msg)
		{
			double X;
			while (true)
			{
				Console.Write(msg);
				string str = Console.ReadLine();
				try
				{
					X = double.Parse(str);
				}
				catch (Exception e)
				{
					Console.WriteLine("Вы ввели не число: " + e.Message);
					Console.WriteLine("\nПопробуйте ещё раз");
					continue;
				}
				break;
			}
			return X;
		}
	}
}
