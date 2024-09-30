using System;

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