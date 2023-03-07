Vector v1 = new Vector(10);
Vector v2 = new Vector();
Vector v3 = new Vector(v1);
double[] vv = new double[5];
Vector v4 = new Vector(vv);
v3.Input();
Console.WriteLine(v1.ToString());
Console.WriteLine($"Модуль вектора: {v3.ModuleMsv()}" +
    $"\nНаибольший элемент вектора: {v3.msvMax()}" +
    $"\nИндекс наименьшего элемента вектора: {v3.msvMinIndex()}" +
    $"\nВектор из положительных векторов {v3.newMsv()}" +
    $"\nСумма двух векторов {Vector.msvSum(v1, v3)}" +
    $"\nСкалярное произведение векторов: {Vector.msvProz(v1, v3)}" +
    $"\nРавенство векторов: {Vector.msvRaven(v1, v3)}");
v3.hairbrush();
v3.sdvig();
Console.WriteLine(v3);


public class Vector
{
    private double[] msv;

    public double[] Msv
    {
        get { return msv; }
        set { msv = value; }
    }

    public Vector()
    {
        Random rnd = new Random();
        msv = new double[5];
        for (int i = 0; i < msv.Length; i++)
        {
            msv[i] = rnd.Next(1, 10);
        }
    }

    public Vector(int n)
    {
        msv = new double[n];
    }

    public Vector(double[] m)
    {
        msv = m;
    }

    public Vector(Vector other)
    {
        msv = other.Msv;
    }

    public void Input()
    {
        Console.WriteLine($"Введите {msv.Length} чисел(-а): ");
        for (int i = 0; i < msv.Length; i++)
        {
            msv[i] = Convert.ToDouble(Console.ReadLine());
        }
    }

    public override string ToString()
    {
        return $"({string.Join(", ", msv)})";
    }

    public double ModuleMsv()
    {
        double res = 0;
        for (int i = 0; i < msv.Length; i++)
        {
            res += (msv[i] * msv[i]);
        }
        return Math.Sqrt(res);
    }

    public double msvMax()
    {
        return msv.Max();
    }

    public int msvMinIndex()
    {
        int res = 0;
        double mm = msv[0];
        for (int i = 1; i < msv.Length; i++)
        {
            if (mm > msv[i])
            {
                mm = msv[i];
                res = i;
            }
        }
        return res;
    }

    public Vector newMsv()
    {
        int n = 0;
        for (int i = 0; i < msv.Length; i++)
        {
            if (msv[i] > 0) n += 1;
        }
        double[] mssv = new double[n];
        int j = 0;
        for (int i = 0; i < msv.Length; i++)
        {
            if (msv[i] > 0)
            {
                mssv[j] = msv[i];
                j++;
            }
        }
        return new Vector(mssv);
    }

    public static Vector msvSum(Vector v1, Vector v2)
    {
        if (v1.Msv.Length != v2.Msv.Length)
        {
            return v1;
        }
        else
        {
            double[] result = new double[v1.Msv.Length];
            for (int i = 0; i < v1.Msv.Length; i++)
            {
                result[i] = v1.Msv[i] + v2.Msv[i];
            }

            return new Vector(result);
        }
    }

    public static double msvProz(Vector v1, Vector v2)
    {
        if (v1.Msv.Length != v2.Msv.Length)
        {
            return 0;
        }

        double result = 0;
        for (int i = 0; i < v1.Msv.Length; i++)
        {
            result += v1.Msv[i] * v2.Msv[i];
        }

        return result;

    }

    public static bool msvRaven(Vector v1, Vector v2)
    {
        if (v1.Msv.Length != v2.Msv.Length)
        {
            return false;
        }
        for (int i = 0; i < v1.Msv.Length; i++)
        {
            if (v1.Msv[i] != v2.Msv[i])
            {
                return false;
            }
        }
        return true;
    }
    public double getIndex(int i)
    {
        return msv[i];
    }

    public void setIndex(int i, double x)
    {
        msv[i] = x;
    }

    public void vectorRnd(int a, int b)
    {
        Random rnd = new Random();
        for (int i = 0; i < msv.Length; i++) msv[i] = rnd.Next(a, b);
    }

    public int LineSearch(double x)
    {
        for (int i = 0; i < msv.Length; i++)
        {
            if (msv[i] == x)
            {
                return i;
            }
        }
        return -1;
    }

    public bool Sorted()
    {
        for (int i = 0; i < msv.Length - 1; i++)
        {
            if (msv[i] > msv[i + 1]) return false;
        }
        return true;
    }
    public int BinSearch(int x)
    {
        int left = 0;
        int right = msv.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (msv[mid] == x)
            {
                return mid;
            }
            else if (msv[mid] < x)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }

    public void sdvig()
    {
        int c = 1;
        for (int i = msv.Length - c; i > c - 1; i--)
        {
            msv[i] = msv[i - 1];
        }
        for (int i = 0; i < c; i++)
        {
            msv[i] = 0;
        }
    }

    public bool range(int a, int b)
    {
        for (int i = 0; i < msv.Length; i++)
        {
            if (msv[i] < a || msv[i] > b) return false;
        }
        return true;
    }
    public void hairbrush()
    {
        const double factor = 1.247;
        double gap = msv.Length / factor;
        while (gap > 1)
        {
            int ggap = (int)(gap);
            for (int i = 0; i + ggap < msv.Length; i++)
            {
                if (msv[i] > msv[i + ggap])
                {
                    double ss = msv[i];
                    msv[i] = msv[i + ggap];
                    msv[i + ggap] = ss;
                }
            }
            gap /= 1.247;
        }
    }
}