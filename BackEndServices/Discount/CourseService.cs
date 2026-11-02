using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices
{
    public class CourseService
    {
        public CourseService()
        { 
        }

        public decimal GetTotalCost(List<Course> courses, List<Discount> discounts, User user)
        {
            decimal res = 0;

            foreach (Course course in courses)
            {
                decimal d = 0;
                foreach (var discount in discounts)
                {
                    var dv = discount.GetDiscount(course, user);
                    if(dv > d)
                        d = dv;
                }
                var coursePrice = course.Price * (1 - d);
                res += coursePrice;
            }

            return res;
        }

    }
}
