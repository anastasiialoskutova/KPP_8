using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Використовуємо простір імен WinFormsApp2
namespace WinFormsApp2
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

            output.AppendLine("Робота Квіткового Салону (Демонстрація Інтерфейсів)\n");

            // 1. Створюємо екземпляри квітів 
            Flower rose = new Flower("Троянда", 35.00M, "Червона");
            Flower tulip = new Flower("Тюльпан", 20.00M, "Жовтий");
            Flower lily = new Flower("Лілія", 40.00M, "Біла");
            Flower iris = new Flower("Ірис", 25.00M, "Фіолетовий"); 

            // 2. Створюємо екземпляр Bouquet
            Bouquet myBouquet = new Bouquet();

            // 3. Додаємо квіти до букета 
            myBouquet.Add(rose);
            myBouquet.Add(tulip);
            myBouquet.Add(rose);
            myBouquet.Add(lily);
            myBouquet.Add(iris); 

            output.AppendLine("Склад букета (використання foreach завдяки інтерфейсу IEnumerable):");

            // 4. Використання циклу foreach
            foreach (Flower flower in myBouquet)
            {
                output.AppendLine($" - {flower.GetDescription()}");
            }

            // 5. Розрахунок та виведення загальної ціни
            decimal totalPrice = myBouquet.CalculateTotalPrice();
            output.AppendLine($"\n-------------------------------------------------------------------------");
            output.AppendLine($"Загальна вартість букета: {totalPrice:C} (враховано 5 елементів)");
            output.AppendLine("-------------------------------------------------------------------------");

            // Виводимо весь накопичений текст у мітку
            label1.Text = output.ToString();
        }
    }

    // Допоміжні класи та Інтерфейси

    // 1. Інтерфейс: Визначає контракт для будь-якого елемента, що може бути у букеті.
    public interface IBouquetItem
    {
        string Name { get; }
        decimal Price { get; }
        string GetDescription();
    }

    // 2. Клас Квітка: Реалізує контракт IBouquetItem.
    public class Flower : IBouquetItem
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Color { get; private set; }

        public Flower(string name, decimal price, string color)
        {
            this.Name = name;
            this.Price = price;
            this.Color = color;
        }

        public string GetDescription()
        {
            return $"{Color} {Name} | Ціна: {Price:C}";
        }
    }

    // 3. Клас Букет: Реалізує стандартний інтерфейс IEnumerable.
    public class Bouquet : IEnumerable
    {
        private List<Flower> _flowers = new List<Flower>();

        public void Add(Flower flower)
        {
            _flowers.Add(flower);
        }

        public decimal CalculateTotalPrice()
        {
            return _flowers.Sum(f => f.Price);
        }

        // Реалізація єдиного методу інтерфейсу IEnumerable.
        public IEnumerator GetEnumerator()
        {
            return _flowers.GetEnumerator();
        }
    }
}