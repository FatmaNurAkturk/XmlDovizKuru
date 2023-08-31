using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDovizKuru.Model;

namespace XmlDovizKuru.Classes
{
    public class SaleOperation
    {
        ConsoleDbProjeEntities1 db = new ConsoleDbProjeEntities1();
        public void CustomerSaleOperationAlis()
        {
            var values = db.TblOperation.Where(x=>x.OperationType=="alış").ToList();
            foreach (var item in values)
            {
                Console.WriteLine("Id: "+item.Id+" Müşteri: "+item.CustomerName+" Müşteri Soyadı: "+item.CustomerSurname+"Döviz: "+
                    item.TblCurrency.CurrencyName+" İşlem Türü: "+item.OperationType+" Kur Birim Tutarı:"+item.CurrentVAlue+" Alınan Tutar: "+
                    item.Amount+" Toplam Tutar"+item.TotalPrice);
            }
        }
        public void CustomerSaleOperationSatis()
        {
            var values = db.TblOperation.Where(x => x.OperationType == "satış").ToList();
            foreach (var item in values)
            {
                Console.WriteLine("Id: " + item.Id + " Müşteri: " + item.CustomerName + " Müşteri Soyadı: " + item.CustomerSurname + "Döviz: " +
                    item.TblCurrency.CurrencyName + " İşlem Türü: " + item.OperationType + " Kur Birim Tutarı:" + item.CurrentVAlue + " Alınan Tutar: " +
                    item.Amount + " Toplam Tutar" + item.TotalPrice);
            }
        }
    }
}
