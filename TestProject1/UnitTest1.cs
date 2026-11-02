using BackEndServices;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var user = new User(1, true);
            var c = new List<Course> { new Course(
                                                DateTime.Now.AddDays(1),100) };
            var d = new List<Discount> { new StartDiscount(new decimal(0.2), 5),
                                         new GraduateDiscount(new decimal(0.3))};
            var cs = new CourseService();
            var res = cs.GetTotalCost(c, d, user);
            Assert.True(res == new decimal(70));
        }

        [Fact]
        public void Test2()
        {
            var user = new User(1, false);
            var c = new List<Course> { new Course(
                                                DateTime.Now.AddDays(1),100) };
            var d = new List<Discount> { new StartDiscount(new decimal(0.2), 5),
                                         new GraduateDiscount(new decimal(0.3))};
            var cs = new CourseService();
            var res = cs.GetTotalCost(c, d, user);
            Assert.True(res == new decimal(80));
        }
    }
}
