using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlDovizKuru.Classes;
using XmlDovizKuru.Model;

namespace XmlDovizKuru
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleDbProjeEntities1 db = new ConsoleDbProjeEntities1();
            GetCurrency getCurrency = new GetCurrency();
            SaleOperation saleOperation = new SaleOperation();  
            Sale sale = new Sale(); 

            void CurrencyList()
            {
                Console.WriteLine();
                Console.WriteLine("Döviz Listesi");
                Console.WriteLine();
                var values = db.TblCurrency.ToList();
                foreach (var value in values)
                {
                    Console.WriteLine(value.Id + " " + value.CurrencyName);
                }
            }
            void CurrentCurreny()
            {
                Console.WriteLine();
                Console.WriteLine("Güncel Kur Lİstesi");
                Console.WriteLine();
                var values = db.TblCurrenyValue.ToList();
                foreach(var value in values)
                {
                    Console.WriteLine("Döviz: " + value.TblCurrency.CurrencyName + " Alış:" + value.CurrencyBuying + " Satış:" + value.CurrencySelling);
                }
            }

            void GetCurrencyClass()
            {                
                getCurrency.SaveCurrencyDollar();
                getCurrency.SaveCurrencyEuro();
                getCurrency.SaveCurrencyPound();
            }

            Console.WriteLine("Döviz İşlemlerine Hoşgeldiniz");
            Console.WriteLine();
            Console.WriteLine("Mevcut Kullanıcı: Admin"+"    Tarih:"+DateTime.Now.ToShortDateString());
            Console.WriteLine();
            Console.WriteLine("Yapmak isteğiniz işlemi seçin");
            Console.WriteLine();
            Console.WriteLine("1-Döviz Listesi");
            Console.WriteLine("2-Güncel Kurlar");
            Console.WriteLine("3-Satış yap");
            Console.WriteLine("4-Müşterilere Yapılan Satış Hareketleri");
            Console.WriteLine("5-Müşterilerden Alınan Satışlar");
            Console.WriteLine("6-Kurları Veri Tabanına Kaydet");
            Console.WriteLine("7-Yardım");
            Console.WriteLine("8-Çıkış Yap");
            Console.WriteLine("");
            Console.Write("İşlem Numarası: ");

            string choose = Console.ReadLine();
            if(choose == "1" || choose == "01")
            {
                CurrencyList();
            }
            if(choose == "2" || choose == "02")
            {
                CurrentCurreny();
            }
            if (choose == "3" || choose == "03")
            {
                Console.WriteLine();
                Console.Write("Müşteri Adı: ");
                string customerName = Console.ReadLine();
                Console.Write("Müşteri Soyadı: ");
                string customerSurname = Console.ReadLine();
                Console.Write("Döviz Kodu ");
                int currencyCode = int.Parse(Console.ReadLine());
                Console.Write("İşlem Türü: ");
                string operationType = Console.ReadLine();
                Console.Write("Güncel Kur Değeri: ");
                decimal currentValue =decimal.Parse(Console.ReadLine());
                Console.Write("Alınacak Tutar ");
                decimal amount = decimal.Parse(Console.ReadLine());
                Console.Write("Toplam Ücret ");
                decimal totalAmount = decimal.Parse(Console.ReadLine());


                sale.MakeSale(customerName,customerSurname,currencyCode,operationType,currentValue,amount,totalAmount);
            }
            if (choose == "4" || choose == "04")
            {
                saleOperation.CustomerSaleOperationAlis();                
            }
            if (choose == "5" || choose == "05")
            {
                saleOperation.CustomerSaleOperationSatis();
            }

            if (choose == "6" || choose == "06")
            {
                GetCurrencyClass();
                Console.WriteLine("Dövizler Başarı ile Veri Tabanına Kaydedildi ");
            }
            if (choose == "7" || choose == "07")
            {
                Console.WriteLine("Tüm sorularınız için bize mail@mail.com'dan ulaşabililrsiniz...");
            }
            if (choose == "8" || choose == "08")
            {
                
                Environment.Exit(0);
            }

            Console.ReadLine();
        }
    }
}
