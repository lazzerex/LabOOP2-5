using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*  ############ LAB 02 ###############
    Cho một lớp Vector2D gồm 2 dữ liệu thành viên x, y 
    kiểu float đặc trưng cho toạ độ của vector 2 chiều.
    1. Xây dựng lớp Vector2D với các fields nói trên.
    2. Bổ sung getter và setter cho 2 fields nói trên.
    3. Khai báo constructor không tham số và có tham số.
    4. Khai báo phương thức Print() để in ra thông tin
    của vector 2D dưới dạng: Vector2D<x: 1.2, y: 3.4>
    5. Khai báo phương thức kiểm tra 2 vector trực giao.
    6. Khai báo phương thức tính độ dài của vector.
    7. Khai báo phương thức xác định góc (theo radian)
    giữa 2 vector.
    Trong chương trình chính: tạo ra một mảng 
    (List, ArrayList hay bất kì cấu trúc collection 
    nào), sau đó kiểm tra tất cả các hàm chức năng
    từ câu 4 đến câu 7.
*/

namespace Lab02_OOP
{

    public class Vector2D
    {
        private float x;
        private float y;

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

        public float X
        {
            get => x;
            set => x = value;
        }

        public float Y
        {
            get => y;
            set => y = value;
        }
        public string Print()
        {
            return $"Vector2D<x: {x}, y: {y}>";
        }

        
        public bool TrucGiao(Vector2D b)
        {
            // vô hướng = 0 => trực giao
            float tichVoHuong = this.x * b.x + this.y * b.y;
            return tichVoHuong == 0;
        }

        
        public float DoDai()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        
        public float Goc(Vector2D b)
        {
            // cong thuc: cos(α) = (a·b)/(|a|·|b|)
            float tichVoHuong = this.x * b.x + this.y * b.y;
            float doDaiA = this.DoDai();
            float doDaiB = b.DoDai();

            if (doDaiA == 0 || doDaiB == 0)
                return 0;

            float cosAnpha = tichVoHuong / (doDaiA * doDaiB);
            return (float)Math.Acos(cosAnpha);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            
            List<Vector2D> vectors = new List<Vector2D>();

           
            vectors.Add(new Vector2D(5, 12));
            vectors.Add(new Vector2D(-5, 1));
            vectors.Add(new Vector2D(3.1f, 8.5f));
            vectors.Add(new Vector2D(3, 5));
            vectors.Add(new Vector2D(-5, 3));
            vectors.Add(new Vector2D(1, 0));
            vectors.Add(new Vector2D(1, 0));

            Console.WriteLine("Danh sách các vector:"); 
            for (int i = 0; i < vectors.Count; i++)
            {
                Console.WriteLine($"Vector{i+1}: " + vectors[i].Print());
            }

            // truc giao
            Console.WriteLine("\nKiểm tra trực giao vector 1 và 2:");
            Console.WriteLine(vectors[0].TrucGiao(vectors[1]));
            Console.WriteLine("\nKiểm tra trực giao vector 4 và 5:");
            Console.WriteLine(vectors[3].TrucGiao(vectors[4]));

            //do dai
            Console.WriteLine("\nĐộ dài của vector 1:");
            Console.WriteLine(vectors[0].DoDai());
            Console.WriteLine("\nĐộ dài của vector 3:");
            Console.WriteLine(vectors[2].DoDai());
            

            //goc
            Console.WriteLine("\nGóc giữa vector 1 và 2 (radian):");
            Console.WriteLine(vectors[0].Goc(vectors[1]));
            Console.WriteLine("\nGóc giữa vector 6 và 7 (radian):");
            Console.WriteLine(vectors[5].Goc(vectors[6]));
        }

    }
}

