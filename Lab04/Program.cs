using System;

public class MyMatrix
{
    private int[][] matrix;
    private int intervalmin, intervalmax;

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

    MyMatrix (int m, int n)
    {
        this.m = m;
        this.n = n;

        Random r = new Random();
        matrix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                matrix[i][j] = r.Next(intervalmin, intervalmax+1);
            }
        }
    }
    public static MyMatrix operator *(int num) {}

    public static MyMatrix operator +(MyMatrix m1, MyMatrix m2) {}

    public static MyMatrix operator -(MyMatrix m1, MyMatrix m2) {}

    public static MyMatrix operator *(MyMatrix m1, MyMatrix m2) {}

    public static MyMatrix operator /(int num) {}
}