using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Lab 05 */
/*
    1. Khai báo một interface IVector gồm có các phương thức:
        - Add(IVector vector): IVector
        - Subtract(IVector vector): IVector
        - Multiply(double scalar): IVector
        - Divide(double scalar): IVector
        - Length(): double
        - Normalize(): IVector
        - DotProduct(IVector vector): double
        - CrossProduct(IVector vector): IVector
        để thực thi các chức năng: cộng 2 vector, trừ 2 vector, nhân vector với một số, 
        chia vector cho một số, tính độ dài vector, chuẩn hóa vector (chia từng thành phần cho độ dài của vector, 
        tích vô hướng, tích có hướng.
    2. Khai báo một lớp Vector2D và Vector3D kế thừa từ IVector và thực thi các phương thức của IVector.
    3. Trong hàm main, tạo ra một List các IVector và triệu gọi hàm tạo của Vector2D và Vector3D ngẫu nhiên cho từng
    phần tử trong List. Sau đó triệu gọi các phương thức tương ứng của IVector cho từng phần tử trong List.
    4. Cho phép Vector2D và Vector3D thực thi bổ sung 2 interface ICloneable và IComparable. Với IComeparable, các vector
    có thể so sánh với nhau dựa trên độ dài của nó (thông qua Length). Sắp xếp các vector trong List của câu 3 theo
    thứ tự tăng dần của độ dài. In ra dưới dạng bảng toạ độ các vector (x, y, z) và độ dài tương ứng.
    5. Bổ sung vào lớp Vector2D một phương thức ConvertToVector3D() để chuyển đổi từ Vector2D sang Vector3D. Trong đó, có
    sử dụng đến phương thức Clone() để tạo ra một bản sao của Vector2D trước khi chuyển đổi.
*/



namespace Lab05_OOP
{
    public interface IVector
    {
        IVector Add(IVector vector);
        IVector Subtract(IVector vector);
        IVector Multiply(double scalar);
        IVector Divide(double scalar);
        double Length();
        IVector Normalize();
        double DotProduct(IVector vector);
        IVector CrossProduct(IVector vector);
    }

    public class Vector2D : IVector, ICloneable, IComparable
    {
        private double x;
        private double y;

        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public IVector Add(IVector vector)
        {
            Vector2D other = (Vector2D)vector;
            return new Vector2D(this.x + other.x, this.y + other.y);
        }

        public IVector Subtract(IVector vector)
        {
            Vector2D other = (Vector2D)vector;
            return new Vector2D(this.x - other.x, this.y - other.y);
        }

        public IVector Multiply(double scalar)
        {
            return new Vector2D(this.x * scalar, this.y * scalar);
        }

        public IVector Divide(double scalar)
        {
            return new Vector2D(this.x / scalar, this.y / scalar);
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public IVector Normalize()
        {
            double length = Length();
            return new Vector2D(x / length, y / length);
        }

        public double DotProduct(IVector vector)
        {
            Vector2D other = (Vector2D)vector;
            return this.x * other.x + this.y * other.y;
        }

        public IVector CrossProduct(IVector vector)
        {
            throw new NotImplementedException("Cross product is not defined for 2D vectors");
        }

        public object Clone()
        {
            return new Vector2D(this.x, this.y);
        }

        public int CompareTo(object obj)
        {
            IVector other = (IVector)obj;
            return this.Length().CompareTo(other.Length());
        }

        public Vector3D ConvertToVector3D()
        {
            Vector2D clone = (Vector2D)this.Clone();
            return new Vector3D(clone.x, clone.y, 0);
        }

        public override string ToString()
        {
            return String.Format("({0:F2}, {1:F2})", x, y);
        }
    }

    public class Vector3D : IVector, ICloneable, IComparable
    {
        private double x;
        private double y;
        private double z;

        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public IVector Add(IVector vector)
        {
            Vector3D other = (Vector3D)vector;
            return new Vector3D(this.x + other.x, this.y + other.y, this.z + other.z);
        }

        public IVector Subtract(IVector vector)
        {
            Vector3D other = (Vector3D)vector;
            return new Vector3D(this.x - other.x, this.y - other.y, this.z - other.z);
        }

        public IVector Multiply(double scalar)
        {
            return new Vector3D(this.x * scalar, this.y * scalar, this.z * scalar);
        }

        public IVector Divide(double scalar)
        {
            return new Vector3D(this.x / scalar, this.y / scalar, this.z / scalar);
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public IVector Normalize()
        {
            double length = Length();
            return new Vector3D(x / length, y / length, z / length);
        }

        public double DotProduct(IVector vector)
        {
            Vector3D other = (Vector3D)vector;
            return this.x * other.x + this.y * other.y + this.z * other.z;
        }

        public IVector CrossProduct(IVector vector)
        {
            Vector3D other = (Vector3D)vector;
            return new Vector3D(
                this.y * other.z - this.z * other.y,
                this.z * other.x - this.x * other.z,
                this.x * other.y - this.y * other.x
            );
        }

        public object Clone()
        {
            return new Vector3D(this.x, this.y, this.z);
        }

        public int CompareTo(object obj)
        {
            IVector other = (IVector)obj;
            return this.Length().CompareTo(other.Length());
        }

        public override string ToString()
        {
            return String.Format("({0:F2}, {1:F2}, {2:F2})", x, y, z);
        }
    }
    public class Program
    {
        public static void Main(string[] args) 
        {
            Console.OutputEncoding = Encoding.Unicode;
            Random random = new Random();
            List<IVector> vectors = new List<IVector>();
            List<Vector2D> vector2Ds = new List<Vector2D>();
            List<Vector3D> vector3Ds = new List<Vector3D>();

            // Tạo ngẫu nhiên các vector
            for (int i = 0; i < 3; i++)
            {
                Vector2D v2d = new Vector2D(random.NextDouble() * 10, random.NextDouble() * 10);
                Vector3D v3d = new Vector3D(random.NextDouble() * 10, random.NextDouble() * 10, random.NextDouble() * 10);

                vectors.Add(v2d);
                vectors.Add(v3d);
                vector2Ds.Add(v2d);
                vector3Ds.Add(v3d);
            }

            // In ra các vector ban đầu
            Console.WriteLine("Các vector ban đầu:");
            PrintVectors(vectors);

            // Sắp xếp vectors theo độ dài
            vectors.Sort();
            Console.WriteLine("\nCác vector sau khi sắp xếp theo độ dài:");
            PrintVectors(vectors);

            // Thực hiện các phép toán với Vector2D
            if (vector2Ds.Count >= 2)
            {
                Console.WriteLine("\nThực hiện các phép toán với Vector2D:");
                Vector2D v2d1 = vector2Ds[0];
                Vector2D v2d2 = vector2Ds[1];

                Console.WriteLine("Vector2D 1 + Vector2D 2 = " + v2d1.Add(v2d2));
                Console.WriteLine("Vector2D 1 - Vector2D 2 = " + v2d1.Subtract(v2d2));
                Console.WriteLine("Vector2D 1 * 2 = " + v2d1.Multiply(2));
                Console.WriteLine("Vector2D 1 / 2 = " + v2d1.Divide(2));
                Console.WriteLine("Độ dài Vector2D 1 = " + v2d1.Length().ToString("F2"));
                Console.WriteLine("Vector2D 1 chuẩn hóa = " + v2d1.Normalize());
                Console.WriteLine("Tích vô hướng Vector2D 1 và 2 = " + v2d1.DotProduct(v2d2).ToString("F2"));
            }

            // Thực hiện các phép toán với Vector3D
            if (vector3Ds.Count >= 2)
            {
                Console.WriteLine("\nThực hiện các phép toán với Vector3D:");
                Vector3D v3d1 = vector3Ds[0];
                Vector3D v3d2 = vector3Ds[1];

                Console.WriteLine("Vector3D 1 + Vector3D 2 = " + v3d1.Add(v3d2));
                Console.WriteLine("Vector3D 1 - Vector3D 2 = " + v3d1.Subtract(v3d2));
                Console.WriteLine("Vector3D 1 * 2 = " + v3d1.Multiply(2));
                Console.WriteLine("Vector3D 1 / 2 = " + v3d1.Divide(2));
                Console.WriteLine("Độ dài Vector3D 1 = " + v3d1.Length().ToString("F2"));
                Console.WriteLine("Vector3D 1 chuẩn hóa = " + v3d1.Normalize());
                Console.WriteLine("Tích vô hướng Vector3D 1 và 2 = " + v3d1.DotProduct(v3d2).ToString("F2"));
                Console.WriteLine("Tích có hướng Vector3D 1 và 2 = " + v3d1.CrossProduct(v3d2));
            }

            // Test chuyển đổi Vector2D sang Vector3D
            if (vector2Ds.Count > 0)
            {
                Console.WriteLine("\nChuyển đổi Vector2D sang Vector3D:");
                Vector2D v2d = vector2Ds[0];
                Vector3D v3d = v2d.ConvertToVector3D();
                Console.WriteLine("Vector2D: " + v2d);
                Console.WriteLine("Vector3D: " + v3d);
            }
        }

        public static void PrintVectors(List<IVector> vectors)
        {
            Console.WriteLine("Tọa độ\t\t\tĐộ dài");
            Console.WriteLine("------------------------");
            foreach (IVector vector in vectors)
            {
                Console.WriteLine("{0}\t\t{1:F2}", vector, vector.Length());
            }
        }

    }
}

