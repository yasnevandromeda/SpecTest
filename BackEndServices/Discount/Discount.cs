namespace BackEndServices
{
    public class Discount
    {
        public Discount(decimal discountValue)
        {
            DiscountValue = discountValue;
        }

        public decimal DiscountValue { get; set; }

        public virtual decimal GetDiscount(Course course, User user)
        {
            return DiscountValue;
        }
    }

    public class StartDiscount : Discount
    {
        public StartDiscount(decimal discountValue, int dayCount) : base(discountValue) 
        {
            DayCount = dayCount;
        }
        
        public int DayCount { get; set; }

        public override decimal GetDiscount(Course course, User user)
        {
            DateTime now = DateTime.Now;
            if (now >= course.Started)
                return 0;
            if (course.Started.Subtract(now) < TimeSpan.FromDays(DayCount))
                return DiscountValue;
            else
                return 0;
        }

    }

    public class GraduateDiscount : Discount
    {
        public GraduateDiscount(decimal discountValue) : base(discountValue) { }
                
        public override decimal GetDiscount(Course course, User user)
        {
            if (user.IsGraduate)
                return DiscountValue;
            else
                return 0;
        }

    }


}


