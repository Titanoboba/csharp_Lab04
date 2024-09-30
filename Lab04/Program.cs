using System;
using System.Collections;
using System.Collections.Specialized;

public class MyMatrix
{
    private int[][] matrix;
    private int intervalmin, intervalmax;
    public int width, height;

    public int MinInterval
    {
        get { return intervalmin; }
        set { intervalmin = value; }
    }

    public int MaxInterval
    {
        get { return intervalmax; }
        set { intervalmax = value; }
    }

    MyMatrix(int m, int n)
    {
        this.width = m;
        this.height = n;

        Random r = new Random();
        matrix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                matrix[i][j] = r.Next(intervalmin, intervalmax + 1);
            }
        }
    }
    public static MyMatrix operator *(MyMatrix matrix, int num)
    {
        for (int i = 0; i < matrix.width; i++)
        {
            for (int j = 0; j < matrix.height; j++)
            {
                matrix.matrix[i][j] *= num;
            }
        }
        return matrix;
    }

    public static MyMatrix operator +(MyMatrix m1, MyMatrix m2)
    {
        if (m1.width != m2.width || m1.height != m2.height)
        {
            throw new ArgumentException(String.Format("Matrixes are not the same width or height"));
        }
        else
        {
            for (int i = 0; i < m1.width; i++)
            {
                for (int j = 0; j < m1.height; j++)
                {
                    m1.matrix[i][j] += m2.matrix[i][j];
                }
            }
        }
        return m1;
    }

    public static MyMatrix operator -(MyMatrix m1, MyMatrix m2)
    {
        if (m1.width != m2.width || m1.height != m2.height)
        {
            throw new ArgumentException(String.Format("Matrixes are not the same width or height"));
        }
        else
        {
            for (int i = 0; i < m1.width; i++)
            {
                for (int j = 0; j < m1.height; j++)
                {
                    m1.matrix[i][j] -= m2.matrix[i][j];
                }
            }
        }
        return m1;
    }

    public static MyMatrix operator *(MyMatrix m1, MyMatrix m2)
    {
        MyMatrix result = new MyMatrix(m2.height, m2.width);

        for (int i = 0; i < m1.height; i++)
        {
            for (int j = 0; j < m2.width; j++)
            {
                result.matrix[i][j] = 0;
                for (int k = 0; k < m2.height; k++)
                {
                    result.matrix[i][j] += m1.matrix[i][k] * m2.matrix[k][j];
                }
            }
        }

        return result;
    }

    public static MyMatrix operator /(MyMatrix matrix, int num)
    {
        for (int i = 0; i < matrix.width; i++)
        {
            for (int j = 0; j < matrix.height; j++)
            {
                matrix.matrix[i][j] /= num;
            }
        }
        return matrix;
    }

    public int this[int i, int j]
    {
        get { return matrix[i][j]; }

    }
}

public class Car
{
    public string Name {  get; set; }

    public int ProductionYear {  get; set; }

    public double MaxSpeed {  get; set; }

    public Car (string? name, int productionYear, double maxspeed)
    {
        if (name == null)
        {
            this.Name = "Kelvin";
        }
        else
        {
            this.Name = name;
        }
        this.ProductionYear = productionYear;
        this.MaxSpeed = maxspeed;
    }

    public override string ToString()
    {
        return String.Format($"Car name: {Name}\nProduction year: {ProductionYear}\nMax speed: {MaxSpeed}");
    }
}

public class CarComparerProductionYear : IComparer<Car>
{
    public int Compare(Car x, Car y)
    {
        if (x.ProductionYear.CompareTo(y.ProductionYear) != 0)
        {
            return x.ProductionYear.CompareTo(y.ProductionYear);
        }
        else if (x.MaxSpeed.CompareTo(y.MaxSpeed) != 0)
        {
            return x.MaxSpeed.CompareTo(y.MaxSpeed);
        }
        else if (x.Name.CompareTo(y.Name) != 0)
        {
            return x.Name.CompareTo(y.Name);
        }
        else
        {
            return 0;
        }
    }
}

public class CarComparerMaxSpeed : IComparer<Car>
{
    public int Compare(Car x, Car y)
    {
        if (x.MaxSpeed.CompareTo(y.MaxSpeed) != 0)
        {
            return x.MaxSpeed.CompareTo(y.MaxSpeed); 
        }
        else if (x.ProductionYear.CompareTo(y.ProductionYear) != 0)
        {
            return x.ProductionYear.CompareTo(y.ProductionYear);
        }
        else if (x.Name.CompareTo(y.Name) != 0)
        {
            return x.Name.CompareTo(y.Name);
        }
        else
        {
            return 0;
        }
    }
}

public class CarComparerName : IComparer<Car>
{
    public int Compare(Car x, Car y)
    {
        if (x.Name.CompareTo(y.Name) != 0)
        {
            return x.Name.CompareTo(y.Name);
        }
        else if (x.MaxSpeed.CompareTo(y.MaxSpeed) != 0)
        {
            return x.MaxSpeed.CompareTo(y.MaxSpeed);
        }
        else if (x.ProductionYear.CompareTo(y.ProductionYear) != 0)
        {
            return x.ProductionYear.CompareTo(y.ProductionYear);
        }
        else
        {
            return 0;
        }
    }
}

public class CarCatalog
{
    Car[] cars;
    CarCatalog(Car[] cars)
    {
        this.cars = cars;
    }
    public IEnumerator<Car> GetEnumerator()
    {
        foreach (Car car in cars)
        {
            yield return car;
        }
    }

    public IEnumerator<Car> GetEnumeratorReverse()
    {
        for (int i = cars.Length - 1; i > 0; i--)
        {
            yield return cars[i];
        }
    }

    public IEnumerator<Car> GetEnumeratorYearProduction(int year)
    {
        foreach (Car car in cars)
        {
            if (car.ProductionYear == year)
            {
                yield return car;
            }
        }
    }

    public IEnumerator<Car> GetEnumeratorMaxSpeed(int maxspeed)
    {
        foreach (Car car in cars)
        {
            if (car.MaxSpeed == maxspeed)
            {
                yield return car;
            }
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        List <Car> cars = new List <Car>();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Input information about car # {i+1}");
            Console.Write("Name: ");
            string? name = Console.ReadLine();
            Console.Write("Production year: ");
            int productionYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("MaxSpeed: ");
            double maxSpeed = Convert.ToDouble(Console.ReadLine());
            cars.Add(new Car(name, productionYear, maxSpeed));
        }

        CarComparerMaxSpeed carComparerMaxSpeed = new CarComparerMaxSpeed();
        CarComparerName carComparerName = new CarComparerName();
        CarComparerProductionYear carComparerProductionYear = new CarComparerProductionYear();

        Console.WriteLine("Initial list");

        foreach (Car car in cars) Console.WriteLine(car);

        Console.WriteLine("Sorted by max speed");

        List<Car> carsSpeedSort = cars;
        carsSpeedSort.Sort(carComparerMaxSpeed);

        foreach (Car car in carsSpeedSort) Console.WriteLine(car);

        Console.WriteLine("Sorted by production year");

        List<Car> carsYearSort = cars;
        carsSpeedSort.Sort(carComparerProductionYear);

        foreach (Car car in carsYearSort) Console.WriteLine(car);

        Console.WriteLine("Sorted by name");

        List<Car> carsNameSort = cars;
        carsSpeedSort.Sort(carComparerName);

        foreach (Car car in carsNameSort) Console.WriteLine(car);
    }
}
