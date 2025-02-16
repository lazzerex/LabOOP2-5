using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* LAB 03: Lớp số phức
Một lớp số phức gồm có 2 thuộc tính: phần thực (real) và phần ảo (imaginary).
Hãy khai báo một lớp số phức với các yêu cầu sau:
- Có 2 phương thức getter và setter cho mỗi field
- Có 3 dạng constructor: không tham số, có 2 tham số và copy constructor
- Khai báo các phép toán cộng, trừ, nhân, chia 2 số phức
- Khai báo phương thức tính module của số phức
- Khai báo phương thức tính argument của số phức
- Khai báo phương thức cộng số phức với một số thực, sử dụng default params (tối đa 3 số thực)
- Khai báo phương thức cộng nhiều số phức, sử dụng rest params
(Lưu ý: phương thức cộng 2 số phức và phương thức cộng số phức với một số thực và phương thức cộng các số phức phải
sử dụng method overloading.)
Hàm Main: test thử các phương thức nói trên. Lưu ý: tạo một mảng các số phức để thực
thi kết quả.
*/

namespace Lab03_OOP
{
    public class ComplexNumber
    {
        private float real;
        private float imaginary;

        // Getter và Setter cho real
        public float Real
        {
            get => real;
            set => real = value;
        }

        // Getter và Setter cho imaginary
        public float Imaginary
        {
            get => imaginary;
            set => imaginary = value;
        }

        // Constructor không tham số
        public ComplexNumber()
        {
            real = 0;
            imaginary = 0;
        }

        // Constructor có tham số
        public ComplexNumber(float real, float imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        // Copy constructor
        public ComplexNumber(ComplexNumber c)
        {
            this.real = c.real;
            this.imaginary = c.imaginary;
        }

        // In số phức
        public void Print()
        {
            Console.WriteLine($"({real} + {imaginary}i)");
        }

        // Phép cộng 2 số phức
        public ComplexNumber Add(ComplexNumber other)
        {
            return new ComplexNumber(this.real + other.real, this.imaginary + other.imaginary);
        }

        // Phép trừ 2 số phức
        public ComplexNumber Subtract(ComplexNumber other)
        {
            return new ComplexNumber(this.real - other.real, this.imaginary - other.imaginary);
        }

        // Phép nhân 2 số phức
        public ComplexNumber Multiply(ComplexNumber other)
        {
            float newReal = this.real * other.real - this.imaginary * other.imaginary;
            float newImaginary = this.real * other.imaginary + this.imaginary * other.real;
            return new ComplexNumber(newReal, newImaginary);
        }

        // Phép chia 2 số phức
        public ComplexNumber Divide(ComplexNumber other)
        {
            float denominator = other.real * other.real + other.imaginary * other.imaginary;
            if (denominator == 0)
            {
                Console.WriteLine("Không thể chia cho 0!");
                return new ComplexNumber();
            }
            float newReal = (this.real * other.real + this.imaginary * other.imaginary) / denominator;
            float newImaginary = (this.imaginary * other.real - this.real * other.imaginary) / denominator;
            return new ComplexNumber(newReal, newImaginary);
        }

        // Tính module số phức
        public float Module()
        {
            return (float)Math.Sqrt(real * real + imaginary * imaginary);
        }

        // Tính argument (góc) của số phức (theo radian)
        public float Argument()
        {
            return (float)Math.Atan2(imaginary, real);
        }

        // Cộng số phức với các số thực (default params)
        public ComplexNumber Add(float x, float y = 0, float z = 0)
        {
            return new ComplexNumber(this.real + x + y + z, this.imaginary);
        }

        // Cộng nhiều số phức (rest params)
        public ComplexNumber AddMultiple(params ComplexNumber[] numbers)
        {
            float sumReal = this.real;
            float sumImaginary = this.imaginary;

            foreach (ComplexNumber num in numbers)
            {
                sumReal += num.real;
                sumImaginary += num.imaginary;
            }

            return new ComplexNumber(sumReal, sumImaginary);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Tạo mảng số phức
            ComplexNumber[] complexNumbers = new ComplexNumber[4];
            complexNumbers[0] = new ComplexNumber(1, 2);
            complexNumbers[1] = new ComplexNumber(3, 4);
            complexNumbers[2] = new ComplexNumber(0, 1);
            complexNumbers[3] = new ComplexNumber(2, -3);

            // Test các phương thức
            Console.WriteLine("Các số phức trong mảng:");
            for (int i = 0; i < complexNumbers.Length; i++)
            {
                complexNumbers[i].Print();
            }

            Console.WriteLine("\nPhép cộng hai số phức:");
            (complexNumbers[0].Add(complexNumbers[1])).Print();

            Console.WriteLine("\nPhép trừ hai số phức:");
            (complexNumbers[0].Subtract(complexNumbers[1])).Print();

            Console.WriteLine("\nPhép nhân hai số phức:");
            (complexNumbers[0].Multiply(complexNumbers[1])).Print();

            Console.WriteLine("\nPhép chia hai số phức:");
            (complexNumbers[0].Divide(complexNumbers[1])).Print();

            Console.WriteLine("\nModule của số phức thứ nhất:");
            Console.WriteLine(complexNumbers[0].Module());

            Console.WriteLine("\nArgument của số phức thứ nhất (radian):");
            Console.WriteLine(complexNumbers[0].Argument());

            Console.WriteLine("\nCộng số phức với một số thực:");
            (complexNumbers[0].Add(2)).Print();

            Console.WriteLine("\nCộng số phức với hai số thực:");
            (complexNumbers[0].Add(2, 3)).Print();

            Console.WriteLine("\nCộng số phức với ba số thực:");
            (complexNumbers[0].Add(2, 3, 4)).Print();

            Console.WriteLine("\nCộng nhiều số phức:");
            (complexNumbers[0].AddMultiple(complexNumbers[1], complexNumbers[2], complexNumbers[3])).Print();
        }
    }
}
