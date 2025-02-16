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

        // Constructor không tham số
        public Vector2D()
        {
            x = 0;
            y = 0;
        }

        // Constructor có tham số
        public Vector2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        // Getter và Setter cho x
        public float X
        {
            get => x;
            set => x = value;
        }

        // Getter và Setter cho y
        public float Y
        {
            get => y;
            set => y = value;
        }

        // In thông tin vector
        public string Print()
        {
            return $"Vector2D<x: {x}, y: {y}>";
        }

        // Kiểm tra hai vector có trực giao không
        public bool TrucGiao(Vector2D b)
        {
            // Tích vô hướng = 0 thì trực giao
            float tichVoHuong = this.x * b.x + this.y * b.y;
            return tichVoHuong == 0;
        }

        // Tính độ dài vector
        public float DoDai()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        // Tính góc giữa 2 vector (radian)
        public float Goc(Vector2D b)
        {
            // cos(α) = (a·b)/(|a|·|b|)
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

            // Tạo List các vector
            List<Vector2D> vectors = new List<Vector2D>();

            // Thêm các vector vào list
            vectors.Add(new Vector2D(1, 0));
            vectors.Add(new Vector2D(0, 1));
            vectors.Add(new Vector2D(2, 2));

            // Test các chức năng
            Console.WriteLine("Danh sach cac vector:");
            for (int i = 0; i < vectors.Count; i++)
            {
                Console.WriteLine(vectors[i].Print());
            }

            // Kiểm tra trực giao
            Console.WriteLine("\nKiem tra truc giao giua vector 1 va 2:");
            Console.WriteLine(vectors[0].TrucGiao(vectors[1]));

            // Tính độ dài
            Console.WriteLine("\nDo dai cua vector 3:");
            Console.WriteLine(vectors[2].DoDai());

            // Tính góc
            Console.WriteLine("\nGoc giua vector 1 va 2 (radian):");
            Console.WriteLine(vectors[0].Goc(vectors[1]));
        }

    }
}

