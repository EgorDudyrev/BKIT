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
			return string.Format ("Прям-ник: W({0:F2}) H({1:F2}) S({2:F2}).", Width, Height, Area());
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
			return string.Format ("Квадрат: l({0:F2}) S({1:F2})", Height, Area());
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
			return string.Format ("Круг: R({0:F2}) S({1:F2})", Rad, Area());
		}

		/// <summary>
		/// Получать и устанавливать радиус круга
		/// </summary>
		/// <value>Радиус.</value>
		public double Rad { get; protected set;}
	}

    	/// <summary>
    
	/// Класс разреженной матрицы
    	/// </summary>
    	/// <typeparam name="T"></typeparam>
    	public class Matrix<T>
    	{ 
       		/// <summary> 
		/// Словарь для хранения значений 
		/// </summary> 
		Dictionary<string, T> _matrix = new Dictionary<string, T>();

		/// <summary> 
		/// Количество элементов по горизонтали (максимальное количество столбцов) 
		/// </summary> 
		int maxX;

		/// <summary> 
		/// Количество элементов по вертикали (максимальное количество строк) 
		/// </summary> 
		int maxY;

		int maxZ;

		/// <summary> 
		/// Реализация интерфейса для проверки пустого элемента 
		/// </summary> 
		IMatrixCheckEmpty<T>сheckEmpty;

		/// <summary> 
		/// Конструктор 
		/// </summary> 
		public Matrix(int px, int py, int pz, IMatrixCheckEmpty<T> сheckEmptyParam)
		{ 
		    this.maxX = px; 
		    this.maxY = py;
		    this.maxZ = pz;
		    this.сheckEmpty = сheckEmptyParam; 
		}
		/// <summary> 
		/// Индексатор для доступа к данных 
		/// </summary> 
		public T this[int x, int y, int z] 
		{ 
		    set 
		    { 
			CheckBounds(x, y, z); 
			string key = DictKey(x, y, z); 
			this._matrix.Add(key, value); 
		    } 
		    get 
		    {
			CheckBounds(x, y, z);
			string key = DictKey(x, y, z);
			if (this._matrix.ContainsKey(key)) 
			    return this._matrix[key]; 
			else 
			    return this.сheckEmpty.getEmptyElement();
		    } 
		}
		/// <summary> 
		/// Проверка границ 
		/// </summary> 
		void CheckBounds(int x, int y, int z) 
		{ 
		    if (x < 0 || x >= this.maxX) 
			throw new ArgumentOutOfRangeException("x", "x=" + x + " выходит за границы"); 
		    if (y < 0 || y >= this.maxY) 
			throw new ArgumentOutOfRangeException("y", "y=" + y + " выходит за границы");
		    if (z < 0 || z >= this.maxZ)
			throw new ArgumentOutOfRangeException("z", "z=" + z + " выходит за границы"); 
		}
		/// <summary>
		/// Формирование ключа 
		/// </summary> 
		string DictKey(int x, int y, int z) 
		{ 
		    return x.ToString() + "_" + y.ToString() + "_" + z.ToString(); 
		}
		/// <summary> 
		/// Приведение к строке 
		/// </summary> 
		/// <returns></returns> 
		public override string ToString() 
		{ 
		    StringBuilder b = new StringBuilder(); 
		    for(int k = 0; k < this.maxZ; k++)
		    {
			b.Append("z = ");
			b.Append(k);
			b.Append("\n");
			for (int j = 0; j < this.maxY; j++)
			{
			    b.Append("[");
			    for (int i = 0; i < this.maxX; i++)
			    {
				//Добавление разделителя-табуляции 
				if (i > 0)
				    b.Append("\t");
				//Если текущий элемент не пустой
				if (!this.сheckEmpty.checkEmptyElement(this[i, j, k]))
				{
				    //Добавить приведенный к строке текущий элемент
				    b.Append(this[i, j, k].ToString());
				}
				else
				{
				    //Иначе добавить признак пустого значения
				    b.Append(" - ");
				}
			    }
			    b.Append("]\n");
			}
			b.Append("\n\n");
		    } 
		    return b.ToString(); 
		}
    	}
	    class FigureMatrixCheckEmpty : IMatrixCheckEmpty<Figure> 
	    { 
		/// <summary> 
		/// В качестве пустого элемента возвращается null 
		/// </summary> 
		public Figure getEmptyElement() { return null; }

		/// <summary> 
		/// Проверка что переданный параметр равен null 
		/// </summary> 
		public bool checkEmptyElement(Figure element) 
		{ 
		    bool Result = false; 
		    if (element == null) 
			Result = true;
		    return Result; 
		}
	    }
	    /// <summary> 
	    /// Проверка пустого элемента матрицы 
	    /// </summary> 
	    public interface IMatrixCheckEmpty<T> { 
		/// <summary> 
		/// Возвращает пустой элемент 
		/// </summary> 
		T getEmptyElement();

		/// <summary> 
		/// Проверка что элемент является пустым 
		/// </summary> 
		bool checkEmptyElement(T element); 
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
