using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Додаємо обробник події тут, якщо він не доданий в дизайнері
            this.button1.Click += new System.EventHandler(this.button1_Click);
        }

        // --- Обробник події "натиснення на кнопку" ---

        private void button1_Click(object sender, EventArgs e)
        {
            string ss = "";

            // 1. Вивід для класу MyBooks1 (Успадкування від ArrayList)
            ss += "\n\n Вивід для класу MyBooks1 \n\n";
            MyBooks1 mbs1 = new MyBooks1(100);
            mbs1.MyBooksArray[0] = new MyBook(1, "E. Marija Remark", "Три товариші", "Ранок", 1981);
            mbs1.MyBooksArray[1] = new MyBook(2, "Нестайко", "В країні сонячних зайчиків", "Ранок", 1961);
            mbs1.MyBooksArray[2] = new MyBook(3, "Баскаков", "Радіотехнічні кола і сигнали", "М.: Вища школа", 2000);

            // Використовуємо foreach
            foreach (MyBook b in mbs1.MyBooksArray)
            {
                if (b != null) ss += b.ToString() + "\n";
            }

            // 2. Вивід для класу MyBooks2 (Використання ітератора Array)
            ss += "\n\n Вивід для класу MyBooks2 \n\n";
            MyBooks2 mbs2 = new MyBooks2(100);
            mbs2.MyBooksArray[0] = new MyBook(1, "E. Marija Remark", "Три товариші", "Ранок", 1981);
            mbs2.MyBooksArray[1] = new MyBook(2, "Нестайко", "У країні сонячних зайчиків", "Ранок", 1961);
            mbs2.MyBooksArray[2] = new MyBook(3, "Баскаков", "Радіотехнічні кола і сигнали", "М.: Вища школа", 2000);

            // Використовуємо foreach
            foreach (MyBook b in mbs2.MyBooksArray)
            {
                if (b != null) ss += b.ToString() + "\n";
            }

            // 3. Вивід для класу MyBooks3 (Повна самостійна реалізація IEnumerable та IEnumerator)
            ss += "\n\n Вивід для класу MyBooks3 \n\n";
            MyBooks3 mbs3 = new MyBooks3(100);
            int KodError = 0;

            // Додаємо книги за допомогою методу Add
            mbs3.Add(1, "E. Marija Remark", "Три товариші", "Ранок", 1981, ref KodError);
            if (KodError > 0) MessageBox.Show("Не вдалось додати книжку, оскільки масив переповнено");
            mbs3.Add(3, "Баскаков", "Радіотехнічні кола і сигнали", "М.: Вища школа", 2000, ref KodError);
            if (KodError > 0) MessageBox.Show("Не вдалось додати книжку, оскільки масив переповнено");
            mbs3.Add(4, "Загребельний", "Роксолана", "Світанок", 2000, ref KodError);
            if (KodError > 0) MessageBox.Show("Не вдалось додати книжку, оскільки масив переповнено");
            mbs3.Add(5, "В. Косик", "Україна і Німеччина у другій світовій війні", "Наукове товариство ім. Шевченка у Львові", 1993, ref KodError);
            if (KodError > 0) MessageBox.Show("Не вдалось додати книжку, оскільки масив переповнено");


            // Виведення книг з масиву класу MyBooks3 через foreach 
            foreach (MyBooks3 b in mbs3)
            {
                if (b != null) ss += b.ToString() + "\n";
            }

            // Демонстрація роботи IEnumerator (MoveNext() та Current)
            mbs3.Reset(); // Додано скидання позиції для гарантії, хоча MoveNext далі робить це неявно
            mbs3.MoveNext();
            ss += "\n Вивід поточного елементу \n \n";
            ss += mbs3.Current.ToString() + "\n";

            ss += " \n Ще раз MoveNext \n \n";
            mbs3.MoveNext();
            ss += mbs3.Current.ToString();

            // Виводимо весь накопичений текст у мітку
            label1.Text = ss;
        }
    }

// Визначення допоміжних класів 

    // Клас для представлення книги
    public class MyBook
    {
        public int bookNomer { get; set; }
        public String Avtor { get; set; }
        public String Nazva { get; set; }
        public String Vydavnyctvo { get; set; }
        public Int16 RikVyhodu { get; set; }

        public MyBook(int bookNomer, String Avtor, String Nazva, String Vydavnyctvo, Int16 RikVyhodu)
        {
            this.bookNomer = bookNomer;
            this.Avtor = Avtor;
            this.Nazva = Nazva;
            this.Vydavnyctvo = Vydavnyctvo;
            this.RikVyhodu = RikVyhodu;
        }

        public override string ToString()
        {
            return "Книга №" + bookNomer.ToString() + " Автор: " + Avtor + " Назва: " + Nazva +
                   " Видавництво: " + Vydavnyctvo + " Рік: " + RikVyhodu.ToString();
        }
    }

    // Клас MyBooks1 - Реалізація IEnumerable (Спосіб 1: Успадкування від ArrayList)
    public class MyBooks1 : ArrayList, IEnumerable
    {
        public MyBook[] MyBooksArray { get; set; }

        public MyBooks1(int kilkistKnyh)
        {
            MyBooksArray = new MyBook[kilkistKnyh];
        }
    }

    // Клас MyBooks2 - Реалізація IEnumerable (Спосіб 2: Використання ітератора Array)
    public class MyBooks2 : IEnumerable
    {
        public MyBook[] MyBooksArray { get; set; }

        public MyBooks2(int kilkistKnyh)
        {
            MyBooksArray = new MyBook[kilkistKnyh];
        }

        public IEnumerator GetEnumerator()
        {
            return MyBooksArray.GetEnumerator();
        }
    }

    // Клас MyBooks3 - Реалізація IEnumerable та IEnumerator (Спосіб 3: Повна самостійна реалізація)
    public class MyBooks3 : IEnumerable, IEnumerator
    {
        private MyBooks3[] myBooksArray;
        private int kilkistKnyh = 0;
        private int CurrentNomer = 0;
        private int position = -1;

        public int bookNomer { get; set; }
        public String Avtor { get; set; }
        public String Nazva { get; set; }
        public String Vydavnyctvo { get; set; }
        public Int16 RikVyhodu { get; set; }

        // Конструктор 1
        public MyBooks3(int kilkistKnyh, int bookNomer, String Avtor, String Nazva, String Vydavnyctvo, Int16 RikVyhodu)
        {
            if (kilkistKnyh <= 0) return;
            myBooksArray = new MyBooks3[kilkistKnyh];
            this.kilkistKnyh = kilkistKnyh;
            this.bookNomer = bookNomer;
            this.Avtor = Avtor;
            this.Nazva = Nazva;
            this.Vydavnyctvo = Vydavnyctvo;
            this.RikVyhodu = RikVyhodu;
        }

        // Конструктор 2
        public MyBooks3(int kilkistKnyh)
        {
            myBooksArray = new MyBooks3[kilkistKnyh];
            this.kilkistKnyh = kilkistKnyh;
            bookNomer = 0;
        }

        // Індексатор
        public MyBooks3 this[int index]
        {
            get
            {
                if (index < kilkistKnyh && index >= 0)
                    return myBooksArray[index];
                else return null;
            }
            set
            {
                if (index < kilkistKnyh) myBooksArray[index] = value;
            }
        }

        // GetEnumerator() з yield
        public IEnumerator GetEnumerator()
        {
            foreach (MyBooks3 b in myBooksArray)
            {
                if (b != null)
                {
                    yield return b;
                }
            }
        }

        // Current() інтерфейсу IEnumerator
        public object Current
        {
            get
            {
                if (position >= 0 && position < kilkistKnyh) return myBooksArray[position];
                else return null;
            }
        }

        // MoveNext() інтерфейсу IEnumerator
        public bool MoveNext()
        {
            position++;
            // Перевіряємо, чи не вийшли за межі масиву І чи елемент не null
            return (position < kilkistKnyh && myBooksArray[position] != null);
        }

        // Reset() інтерфейсу IEnumerator
        public void Reset()
        {
            position = -1;
        }

        // Метод Add
        public void Add(int bookNomer, String Avtor, String Nazva, String Vydavnyctvo, Int16 RikVyhodu, ref int KodError)
        {
            if (CurrentNomer < kilkistKnyh)
            {
                this.myBooksArray[CurrentNomer] = new MyBooks3(1);
                this.myBooksArray[CurrentNomer].bookNomer = bookNomer;
                this.myBooksArray[CurrentNomer].Avtor = Avtor;
                this.myBooksArray[CurrentNomer].Nazva = Nazva;
                this.myBooksArray[CurrentNomer].Vydavnyctvo = Vydavnyctvo;
                this.myBooksArray[CurrentNomer].RikVyhodu = RikVyhodu;

                CurrentNomer++;
                KodError = 0;
            }
            else
            {
                KodError = 1;
            }
        }

        public override string ToString()
        {
            return "Книга №" + bookNomer.ToString() + " Автор:" + Avtor + " Назва:" + Nazva + " Видавництво: " +
                   Vydavnyctvo + " Рік: " + RikVyhodu.ToString();
        }
    }
}