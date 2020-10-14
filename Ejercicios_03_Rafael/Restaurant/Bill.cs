using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_03.Restaurant
{
    public class Bill
    {
        public string ResName { get; set; }
        public string ResBranch { get; set; }
        public string ResType { get; set; }
        public int BillNum { get; set; }
        public int TableNum { get; set; }
        public string WaiterName { get; set; }
        public int WaiterNum { get; set; }
        public int NumOfCustomers { get; set; }
        public double TipPerc { get; set; }

        private decimal Subtotal;
        private decimal Tip;
        private decimal Total;

        public List<Product> ProductsDetail;

        public Bill(string restaurantName, string restauranBranch, string restaurantType, int billNumber,
            int tableNumber, string waiterName, int waiterNumber, int numberOfCustomers, double tipPercentage,
            List<Product> listOfProducts)
        {
            ResName = restaurantName;
            ResBranch = restauranBranch;
            ResType = restaurantType;
            BillNum = billNumber;
            TableNum = tableNumber;
            WaiterName = waiterName;
            WaiterNum = waiterNumber;
            NumOfCustomers = numberOfCustomers;
            TipPerc = tipPercentage;
            ProductsDetail = listOfProducts;

            getSubtotal();
            getTip();
            getTotal();
        }
        private void getSubtotal()
        {
            Subtotal = ProductsDetail.Sum(item => item.SubtotalProduct);
        }
        private void getTip()
        {
            Tip = Convert.ToDecimal(TipPerc * Convert.ToDouble(Subtotal));
        }
        private void getTotal()
        {
            Total = Tip + Subtotal;
        }
        public void printBill()
        {
            StringBuilder str = new StringBuilder();
            str.Append(ResName + " " + ResBranch + "\n");
            str.Append("\t" + ResType + "\n");
            str.Append("\tEstado de Cuenta\n\tExija Su Factura\n");
            str.Append(string.Format("Cuenta: {0}  Mesa: {1}\n", BillNum, TableNum));
            str.Append(string.Format("Mesero: {0}  Personas: {1}\n", WaiterNum, NumOfCustomers));
            foreach (Product product in ProductsDetail)
            {
                str.Append(string.Format("{0} x {1}\n", product.Quantity, product.Price));
                str.Append(string.Format("{0}\t\t{1}\n", product.Name, product.SubtotalProduct));
            }
            str.Append("------------------------------\n");
            str.Append(string.Format("SUBTOTAL:\t\t{0}\n", Subtotal));
            str.Append(string.Format("Propina:\t\t{0}\n", Tip));
            str.Append(string.Format("TOTAL:\t\t{0}\n\n", Total));
            str.Append(WaiterName);
            str.Append("\t\t"+DateTime.Now);
            Console.WriteLine("\n\n"+str);
        }
    }
}
