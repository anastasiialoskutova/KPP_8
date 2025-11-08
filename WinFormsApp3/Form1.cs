using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection.Emit;

namespace WinFormsApp3
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click);
        }

        // Обробник події натиснення на кнопку Пуск

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Дослідження Інтерфейсу IComparer<T> (Сортування)\n");

            // 1. Створення масиву об'єктів Book
            Book[] library = new Book[]
            {
                new Book(1, "E. Marija Remark", "Три товариші", "Ранок", 1981),
                new Book(3, "А. Конан Дойл", "Собака Баскервілів", "Віват", 1902),
                new Book(2, "В. Нестайко", "Тореадори з Васюківки", "А-ба-ба-га-ла-ма-га", 1973),
                new Book(4, "В. Косик", "Україна і Німеччина", "Шевченка", 1993)
            };

            output.AppendLine("Вихідний список книг:");
            foreach (Book b in library)
            {
                output.AppendLine($" {b.ToString()}");
            }
            output.AppendLine("------------------------------------------------------------------------");


            // 2. Сортування за назвою (використовуємо BookTitleComparer)
            output.AppendLine("Сортування за Назвою (через IComparer):");

            // Статичний метод Array.Sort приймає масив та екземпляр класу-компаратора
            Array.Sort(library, new BookTitleComparer());

            foreach (Book b in library)
            {
                output.AppendLine($" {b.ToString()}");
            }
            output.AppendLine("------------------------------------------------------------------------");


            // 3. Сортування за автором (використовуємо BookAuthorComparer)
            output.AppendLine("Сортування за Автором (через IComparer):");

            // Повторно сортуємо той самий масив, але з іншим компаратором
            Array.Sort(library, new BookAuthorComparer());

            foreach (Book b in library)
            {
                output.AppendLine($" {b.ToString()}");
            }
            output.AppendLine("------------------------------------------------------------------------");

            // Виводимо весь накопичений текст у мітку
            label1.Text = output.ToString();
        }
    }

    // Допоміжні класи та Інтерфейси

    // Клас Книга (без реалізації IComparer чи IComparable)
    public class Book
    {
        public int Nomer { get; set; }
        public String Avtor { get; set; }
        public String Nazva { get; set; }
        public String Vydavnyctvo { get; set; }
        public Int16 RikVyhodu { get; set; }

        public Book(int Nomer, String Avtor, String Nazva, String Vydavnyctvo, Int16 RikVyhodu)
        {
            this.Nomer = Nomer;
            this.Avtor = Avtor;
            this.Nazva = Nazva;
            this.Vydavnyctvo = Vydavnyctvo;
            this.RikVyhodu = RikVyhodu;
        }

        public override string ToString()
        {
            return $"№{Nomer} | Автор: {Avtor,-18} | Назва: {Nazva,-28} | Рік: {RikVyhodu}";
        }
    }

    // 1. Клас-компаратор для сортування за Назвою книги (Назва)
    public class BookTitleComparer : IComparer<Book>
    {
        // Реалізація єдиного методу інтерфейсу IComparer<T>
        public int Compare(Book x, Book y)
        {
            if (x == null || y == null) return 0;
            // Порівнюємо властивість Nazva двох об'єктів Book
            return string.Compare(x.Nazva, y.Nazva);
        }
    }

    // 2. Клас-компаратор для сортування за Автором книги (Avtor)
    public class BookAuthorComparer : IComparer<Book>
    {
        // Реалізація єдиного методу інтерфейсу IComparer<T>
        public int Compare(Book x, Book y)
        {
            if (x == null || y == null) return 0;
            // Порівнюємо властивість Avtor двох об'єктів Book
            return string.Compare(x.Avtor, y.Avtor);
        }
    }
}