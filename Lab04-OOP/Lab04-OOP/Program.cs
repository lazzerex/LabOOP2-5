using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*** Lab 03 ***
Một lớp AVector có các phương thức:
- ShowInfo: hiển thị thông tin của lớp
- Add: cộng 2 AVector
- Sub: trừ 2 AVector
- Mul: nhân 2 AVector
- Div: chia 2 AVector
- Dot: tích vô hướng 2 AVector
- Module: độ dài của AVector
- Angle: góc giữa 2 AVector
Tất cả các phương thức ở trên đều đặc tả dưới dạng lớp trừu tượng abstract.

Khai báo 2 lớp Vector2D và Vector3D kế thừa từ AVector. Cài đặt các phương thức ở lớp cha.
Trong đó, lớp Vector2D chứa hai thuộc tính x và y (float); lớp Vector3D chứa ba thuộc tính x, y và z (float).
Bổ sung các phương thức cần thiết khác cho mỗi lớp như constructor, getter, setter nếu cần.

Trong hàm main, tạo ra một List các Vector hỗn hợp (Vector2D và Vector3D). 
Thực hiện các phép toán cơ bản giữa các phần tử trong List.
*/

namespace Lab04_OOP
{
    public abstract class AVector
    {
        public abstract string ShowInfo();
        public abstract AVector Add(AVector other);
        public abstract AVector Sub(AVector other);
        public abstract AVector Mul(AVector other);
        public abstract AVector Div(AVector other);
        public abstract float Dot(AVector other);
        public abstract float Module();
        public abstract float Angle(AVector other);
    }

    public class Vector2D : AVector
    {
        private float x;
        private float y;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        public Vector2D()
        {
            x = 0;
            y = 0;
        }

        public Vector2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ShowInfo()
        {
            return $"Vector2D(x: {x}, y: {y})";
        }

        public override AVector Add(AVector other)
        {
            if (other is Vector2D v2)
            {
                return new Vector2D(this.x + v2.x, this.y + v2.y);
            }
            return null;
        }

        public override AVector Sub(AVector other)
        {
            if (other is Vector2D v2)
            {
                return new Vector2D(this.x - v2.x, this.y - v2.y);
            }
            return null;
        }

        public override AVector Mul(AVector other)
        {
            if (other is Vector2D v2)
            {
                return new Vector2D(this.x * v2.x, this.y * v2.y);
            }
            return null;
        }

        public override AVector Div(AVector other)
        {
            if (other is Vector2D v2)
            {
                if (v2.x != 0 && v2.y != 0)
                {
                    return new Vector2D(this.x / v2.x, this.y / v2.y);
                }
            }
            return null;
        }

        public override float Dot(AVector other)
        {
            if (other is Vector2D v2)
            {
                return this.x * v2.x + this.y * v2.y;
            }
            return 0;
        }

        public override float Module()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public override float Angle(AVector other)
        {
            if (other is Vector2D v2)
            {
                float dot = this.Dot(other);
                float mods = this.Module() * v2.Module();
                if (mods != 0)
                {
                    return (float)Math.Acos(dot / mods);
                }
            }
            return 0;
        }
    }

    public class Vector3D : AVector
    {
        private float x;
        private float y;
        private float z;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }

        public Vector3D()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ShowInfo()
        {
            return $"Vector3D(x: {x}, y: {y}, z: {z})";
        }

        public override AVector Add(AVector other)
        {
            if (other is Vector3D v3)
            {
                return new Vector3D(this.x + v3.x, this.y + v3.y, this.z + v3.z);
            }
            return null;
        }

        public override AVector Sub(AVector other)
        {
            if (other is Vector3D v3)
            {
                return new Vector3D(this.x - v3.x, this.y - v3.y, this.z - v3.z);
            }
            return null;
        }

        public override AVector Mul(AVector other)
        {
            if (other is Vector3D v3)
            {
                return new Vector3D(this.x * v3.x, this.y * v3.y, this.z * v3.z);
            }
            return null;
        }

        public override AVector Div(AVector other)
        {
            if (other is Vector3D v3)
            {
                if (v3.x != 0 && v3.y != 0 && v3.z != 0)
                {
                    return new Vector3D(this.x / v3.x, this.y / v3.y, this.z / v3.z);
                }
            }
            return null;
        }

        public override float Dot(AVector other)
        {
            if (other is Vector3D v3)
            {
                return this.x * v3.x + this.y * v3.y + this.z * v3.z;
            }
            return 0;
        }

        public override float Module()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public override float Angle(AVector other)
        {
            if (other is Vector3D v3)
            {
                float dot = this.Dot(other);
                float mods = this.Module() * v3.Module();
                if (mods != 0)
                {
                    return (float)Math.Acos(dot / mods);
                }
            }
            return 0;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<AVector> vectors = new List<AVector>();

            // Thêm Vector2D
            vectors.Add(new Vector2D(1, 2));
            vectors.Add(new Vector2D(3, 4));

            // Thêm Vector3D
            vectors.Add(new Vector3D(1, 2, 3));
            vectors.Add(new Vector3D(4, 5, 6));

            // In thông tin các vector
            Console.WriteLine("Danh sach cac vector:");
            for (int i = 0; i < vectors.Count; i++)
            {
                Console.WriteLine(vectors[i].ShowInfo());
            }

            // Test các phép toán giữa Vector2D
            Console.WriteLine("\nPhep toan giua Vector2D:");
            AVector result2D = vectors[0].Add(vectors[1]);
            if (result2D != null)
            {
                Console.WriteLine("Tong: " + result2D.ShowInfo());
            }

            // Test các phép toán giữa Vector3D
            Console.WriteLine("\nPhep toan giua Vector3D:");
            AVector result3D = vectors[2].Add(vectors[3]);
            if (result3D != null)
            {
                Console.WriteLine("Tong: " + result3D.ShowInfo());
            }

            // Test tích vô hướng và góc
            Console.WriteLine("\nTich vo huong Vector2D:");
            Console.WriteLine(vectors[0].Dot(vectors[1]));

            Console.WriteLine("\nGoc giua hai Vector3D (radian):");
            Console.WriteLine(vectors[2].Angle(vectors[3]));
        }
    }
}
