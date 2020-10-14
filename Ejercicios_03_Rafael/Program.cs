using Ejercicios_03.Restaurant;
using Ejercicios_03_Rafael.Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_03_Rafael
{
    class Program
    {
        static private BookCase MyBooks = new BookCase();
        static private int BooksNum = 0;
        static private List<Bill> bills = new List<Bill>();
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("+++++++++++++++++|      BIENVENIDO       |+++++++++++++++++");
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("\n1. Programa con Clase Libros");
            Console.WriteLine("2. Programa con Clase Restaurante");
            Console.WriteLine("3. Imprimir JSON de Clase Restaurante");
            Console.Write("\nSelecciona una opcion: ");
            Again:
            string option = Console.ReadLine();
            Console.Clear();
            if (option == "1")
            {
                LibraryBooks();
            }
            else if (option == "2")
            {
                RestauBill();
            }
            else if (option == "3")
            {
                string JSON = JsonConvert.SerializeObject(bills.ToArray());
                if(!Directory.Exists("C:\\JSON"))
                {
                    Directory.CreateDirectory("C:\\JSON");
                }
                File.WriteAllText(@"C:\\JSON\\Bills.json", JSON);
                Console.WriteLine("JSON Generado exitosamente, Path: C:\\JSON\\Bills.json");
                Console.WriteLine(">Presione cualquier tecla para continuar<");
                Console.ReadKey();
                Menu();
            }
            else
            {
                Console.Write("\n\nIntroduzca una opción válida: ");
                goto Again;
            }
        }
        private static void RestauBill()
        {
            Console.Clear();
            List<Product> products = new List<Product>();
            Bill bill;
            Console.WriteLine("++++++++++++++++++      RESTAURANTE      ++++++++++++++++++");
            Console.WriteLine("Ingrese El Nombre del restaurante: ");
            string ResName = Console.ReadLine();
            Console.WriteLine("\nIngrese La sucursal del restaurante: ");
            string ResBranch = Console.ReadLine();
            Console.WriteLine("\nIngrese El tipo de restaurante: ");
            string ResType = Console.ReadLine();
            Console.WriteLine("\nIngrese El Número de facturacion: ");
            string BillNumber = Console.ReadLine();
            Console.WriteLine("\nIngrese el número de clientes en la mesa: ");
            string TableNumber = Console.ReadLine();
            Console.WriteLine("\nIngrese el número de mesa: ");
            string NumOfCust = Console.ReadLine();
            Console.WriteLine("\nIngrese El Nombre del mesero: ");
            string WaiterName = Console.ReadLine();
            Console.WriteLine("\nIngrese El numero de identificacion del mesero: ");
            string WaiterNum = Console.ReadLine();
            Console.WriteLine("\nIngrese la cantidad de productos a comprar: ");
            string prodQuant = Console.ReadLine();
            for (int i = 0; i < Convert.ToInt16(prodQuant); i++)
            {
                Console.WriteLine("\nIngrese el nombre del producto #{0} a comprar: ", i + 1);
                string prodName = Console.ReadLine();
                Console.WriteLine("\nIngrese el precio del producto #{0} a comprar: ", i + 1);
                string prodPrice = Console.ReadLine();
                Console.WriteLine("\nIngrese la cantidad del producto #{0} a comprar: ", i + 1);
                string prodQuanti = Console.ReadLine();
                products.Add(new Product(prodName, Convert.ToDecimal(prodPrice), Convert.ToInt32(prodQuanti)));
            }
            Console.WriteLine("\nIngrese el porcentaje de propina a aplicar: ");
            string tipPer = Console.ReadLine();
            bill = new Bill(ResName, ResBranch, ResType, Convert.ToInt32(BillNumber),
                Convert.ToInt32(TableNumber), WaiterName, Convert.ToInt32(WaiterNum),
                Convert.ToInt32(NumOfCust), Convert.ToDouble(tipPer), products);
            Console.WriteLine("\n>Presione Cualquier tecla para imprimir ticket<");
            Console.ReadKey();
            Console.WriteLine();
            bill.printBill();
            Console.WriteLine("\n>Presione Cualquier tecla para Continuar<");
            Console.ReadKey();
            Console.WriteLine();
            bills.Add(bill);
            Menu();
        }
        private static void LibraryBooks()
        {
            Console.Clear();
            Console.WriteLine("++++++++++++++++++      BIBLIOTECA      ++++++++++++++++++\n");
            if (BooksNum > 0 && BooksNum < 5)
            {
                Console.WriteLine("1. Agregar un libro");
                Console.WriteLine("2. Buscar por libro");
            }
            else if (BooksNum == 0)
            {
                Console.WriteLine("1. Agregar un libro");
            }
            else
            {
                Console.WriteLine("¡Ya no se pueden agregar más libros!");
                Console.WriteLine("2. Buscar por libro");
            }
            Console.WriteLine("3. Volver al menu principal");

            Console.Write("\n\nSeleccione una opción: ");
            int option = Convert.ToInt16(Console.ReadLine());
            BooksOption(option);
        }
        private static void BooksOption(int option)
        {
            if (option == 1)
            {
                Console.WriteLine(">AGREGAR LIBROS<");
                int nextB = 1;
                while (nextB == 1 && BooksLimit(BooksNum))
                {
                    Console.Clear();
                    AddBook();
                    BooksNum++;
                    Console.WriteLine("--> Se pueden agregar {0} libros más.", 5 - BooksNum);
                    Console.Write("Desea agregar otro libro? (Ingrese 1 para sí o 0 para no)");
                    nextB = Convert.ToInt32(Console.ReadLine());
                }
                Console.Clear();
                LibraryBooks();
            }
            else if (option == 2)
            {
                ConsultBooks();
                Console.ReadKey();
            }
            else if (option == 3)
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Ingrese opción válida");
                LibraryBooks();
            }
        }
        private static bool BooksLimit(int limit)
        {
            if (limit < 5) return true;
            else
            {
                Console.WriteLine("Espacio para libros agotado");
                Console.WriteLine(">Presiona cualquir tecla para volver al menú<");
                Console.ReadKey();
                return false;
            }
        }
        private static void AddBook()
        {
            Console.Write("\nIngrese el titulo del libro: ");
            string bookTitle = Console.ReadLine();
            Console.Write("\nIngrese el autor del libro: ");
            string bookAuthor = Console.ReadLine();
            Console.Write("\nIngrese la calificacion del libro: ");
            int bookScore = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nIngrese el numero de paginas del libro: ");
            string bookPages = Console.ReadLine();
            Book book = new Book(bookTitle, bookAuthor, bookScore, bookPages);
            MyBooks.Books[BooksNum] = book;
            Console.WriteLine("Libro agregado...");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
        }
        private static void SearchBook(int index)
        {
            Console.WriteLine("\n¿Por medio de qué información quiere buscar el libro?");
            Console.WriteLine("1. Titulo");
            Console.WriteLine("2. Autor");
            Console.WriteLine("3. NÚmero de paginas");
            Console.WriteLine("4. Calificación");
            Console.WriteLine("5. Toda la información");
            Console.Write("Seleccione una opción: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (option)
            {
                case 1:
                    Console.WriteLine("Titulo: {0}", MyBooks.Books[index].Title);
                    break;
                case 2:
                    Console.WriteLine("Autor: {0}", MyBooks.Books[index].Author);
                    break;
                case 3:
                    Console.WriteLine("Número de páginas: {0}", MyBooks.Books[index].NumOfPages);
                    break;
                case 4:
                    Console.WriteLine("Calificación: {0}", MyBooks.Books[index].Score);
                    break;
                case 5:
                    Console.WriteLine(MyBooks.Books[index]);
                    break;
                default:
                    SearchBook(index);
                    break;
            }
            Console.WriteLine(">Presiona cualquier tecla para continuar<");
            Console.ReadKey();
            LibraryBooks();
        }
        private static void ConsultBooks()
        {
            Console.Clear();
            for (int i = 0; i < BooksNum; i++)
            {
                Console.WriteLine("{0}. Titulo: {1}", i + 1, MyBooks.Books[i].Title);
            }
            Console.Write("Libro a buscar: ");
            int option = Convert.ToInt32(Console.ReadLine());
            SearchBook(option - 1); //Pasa el indice del libro para saber que quiere consultar 
        }    }
}
