namespace BackEndServices
{
    public class Course
    {
        public Course(DateTime started, decimal price)
        {
            Price= price;
            Started = started;
        }

        public DateTime Started { get; set; }

        public decimal Price { get; set; }

    }
}
