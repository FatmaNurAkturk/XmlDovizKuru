using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDovizKuru.Model;

namespace XmlDovizKuru.Classes
{
    public class Sale
    {
        ConsoleDbProjeEntities1 db = new ConsoleDbProjeEntities1();
        public void MakeSale(string customerName, string customerSurname, int currencyCode, string operationType, decimal CurrentValue,
            decimal amount, decimal totalPrice)
        {
            TblOperation t = new TblOperation();
            t.CustomerName = customerName;
            t.CustomerSurname = customerSurname;
            t.CurrencyId = currencyCode;    
            t.OperationType = operationType;    
            t.CurrentVAlue= CurrentValue;
            t.Amount = amount;
            t.TotalPrice = totalPrice;
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblOperation.Add(t);
            db.SaveChanges();
            Console.WriteLine("Satış İşlemi Başarılı Bir Şekilde Gerçekleşti");



        }
    }
}
