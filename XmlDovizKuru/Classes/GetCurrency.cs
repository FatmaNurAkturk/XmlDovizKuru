using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlDovizKuru.Model;

namespace XmlDovizKuru.Classes
{
    public class GetCurrency
    {
        ConsoleDbProjeEntities1 db = new ConsoleDbProjeEntities1();
        string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
        public void SaveCurrencyDollar()
        {                      
            var xmlDoc = new XmlDocument(); 
            xmlDoc.Load(today);
            string dolarAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;            
            string dolarSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            dolarAlis = dolarAlis.Replace(".", ",");
            dolarSatis = dolarAlis.Replace(".", ",");

            TblCurrenyValue currenyValue = new TblCurrenyValue();
            currenyValue.CurrencyId = 1;
            currenyValue.CurrencyBuying = decimal.Parse(dolarAlis);
            currenyValue.CurrencySelling = decimal.Parse(dolarSatis);
            currenyValue.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblCurrenyValue.Add(currenyValue);
            db.SaveChanges();
        }

        public void SaveCurrencyEuro()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            string eurAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            string eurSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            eurAlis = eurAlis.Replace(".", ",");
            eurSatis = eurAlis.Replace(".", ",");

            TblCurrenyValue currenyValue = new TblCurrenyValue();
            currenyValue.CurrencyId = 2;
            currenyValue.CurrencyBuying = decimal.Parse(eurAlis);
            currenyValue.CurrencySelling = decimal.Parse(eurSatis);
            currenyValue.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblCurrenyValue.Add(currenyValue);
            db.SaveChanges();
        }
        public void SaveCurrencyPound()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);
            string poundAlis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;
            string poundSatis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            poundAlis = poundAlis.Replace(".", ",");
            poundSatis = poundSatis.Replace(".", ",");

            TblCurrenyValue currenyValue = new TblCurrenyValue();
            currenyValue.CurrencyId = 4;
            currenyValue.CurrencyBuying = decimal.Parse(poundAlis);
            currenyValue.CurrencySelling = decimal.Parse(poundSatis);
            currenyValue.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblCurrenyValue.Add(currenyValue);
            db.SaveChanges();
        }
    }
}
