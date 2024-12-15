using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting;

public class AccountingModel : ModelBase
{
    private double price;
    public double Price {
        get { return price; }
        set { 
            if (value < 0) throw new ArgumentException();
            price = value;
            UpdataTotal();
            Notify(nameof(Price));
        }
    }
    private int nightsCount;
    public int NightsCount{ 
        get { return nightsCount; }
        set {
            if (value <= 0) throw new ArgumentException();
            nightsCount = value;
            UpdataTotal();
            Notify(nameof(NightsCount));
        }
    }
    private double discount;
    public double Discount { 
        get { return discount; } 
        set { 
            discount = value;
            if (!(Total == Price * NightsCount * (1 - Discount / 100))) {
                UpdataTotal();
            }
            Notify(nameof(Discount));
        }
    }
    private double total;
    public double Total { 
        get { return total; }
        set { 
            total = value;
            if (!(Total == Price * NightsCount * (1 - Discount / 100)))
            {
                UpdataDiscount();
            }
            Notify(nameof(Total));
        } 
    }
    private void UpdataTotal()
    {
        Total = Price * NightsCount * (1 - Discount / 100);;
    }
    private void UpdataDiscount()
    {
        Discount = 100 - 100 * (Total / (Price * NightsCount));
    }
}