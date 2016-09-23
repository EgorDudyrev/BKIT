using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{
	interface IPrint
	{
		void Print ();
	}
	/// <summary>
	/// Абстрактный класс геом. фигуры
	/// </summary>
	abstract class Figure: IComparable, IPrint
	{
		/// <summary>
		/// Вычисление площади фигуры
		/// </summary>
		public abstract double Area();

		public int CompareTo(object obj)
		{
			if (obj == null)
				return 1;

			Figure fig = obj as Figure;
			if (fig != null)
				return this.Area ().CompareTo (fig.Area ());
			else throw new ArgumentNullException("Object is not a Figure");
		}
		public void Print(){ Console.WriteLine (ToString());}
	}
	class Rect : Figure
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
		public double Width { get; protected set;}
		public double Height { get; protected set;}
	}
	class Quadr : Rect
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
	}
	class Circle : Figure
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
			Console.WriteLine ();

			rect.Print ();
			quadr.Print ();
			circle.Print ();
			Console.WriteLine ();

			Console.WriteLine ("Сортировка ArrayList");
			ArrayList al = new ArrayList ();
			al.Add (rect);
			al.Add (quadr);
			al.Add (circle);
			al.Sort ();
			foreach (Figure fig in al) {
				fig.Print ();
			}
			Console.WriteLine ();

			Console.WriteLine ("Сортировка List<Figure>");
			List<Figure> li = new List<Figure> ();
			li.Add (rect);
			li.Add (quadr);
			li.Add (circle);
			li.Sort ();
			foreach (Figure fig in li) {
				fig.Print ();
			}
				
			

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