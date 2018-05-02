public class PriceCalculator
{
    private decimal price;
    private Season season;
    private DiscountType? discountType;
    private int numOfDays;

    public Season Season
    {
        get { return season; }
        set { season = value; }
    }
    
    public DiscountType DiscountType
    {
        get
        {
            if (DiscountType == 0)
            {
                return DiscountType = DiscountType.None;
            }
            else
            {
                return this.DiscountType;
            }
        }
        set { discountType = value; }
    }
    
    public int NumOfDays
    {
        get { return numOfDays; }
        set { numOfDays = value; }
    }
    
    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }

    public PriceCalculator()
    {

    }

    public PriceCalculator(int days, decimal price, Season season, DiscountType type)
    {
        this.DiscountType = type;
        this.Season = season;
        this.NumOfDays = days;
        this.Price = price;
    }

    public decimal CalculateTotalPrice(int days, decimal price, Season season, DiscountType type)
    {
        decimal result = 0.00m;
        switch (season)
        {
            case Season.Spring:
                days *= 2;
                result = days * price;
                if (type == DiscountType.VIP)
                {
                    result -= (decimal)0.20 * result;
                }
                else if (type == DiscountType.SecondVisit)
                {
                    result -= (decimal)0.10* result;
                }
                break;
            case Season.Summer:
                days *= 4;
                result = days * price;
                if (type == DiscountType.VIP)
                {
                    result -= (decimal)0.20 * result;
                }
                else if (type == DiscountType.SecondVisit)
                {
                    result -= (decimal)0.10 * result;
                }
                break;
            case Season.Autumn:
                days *= 1;
                result = days * price;
                if (type == DiscountType.VIP)
                {
                    result -= (decimal)0.20 * result;
                }
                else if (type == DiscountType.SecondVisit)
                {
                    result -= (decimal)0.10 * result;
                }
                break;
            case Season.Winter:
                days *= 3;
                result = days * price;
                if (type == DiscountType.VIP)
                {
                    result -= (decimal)0.20 * result;
                }
                else if (type == DiscountType.SecondVisit)
                {
                    result -= (decimal)0.10 * result;
                }
                break;
            default:
                break;
        }
        return result;
    }
}