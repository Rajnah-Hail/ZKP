using System.Collections.Generic;
using System.Linq;

namespace ZKP.TestData
{
    // Class يحتوي على بيانات تجريبية
    public static class TestData
    {
        public static readonly List<DemoUser> Users = new List<DemoUser>
        {
            new DemoUser
            {
                PhoneNumber = "0558580907",
                AgeGroup = "شاب",
                IsAdult = true,
                 firstName="عبدالعزيز",
                 LastName="الحمد",

            },
            new DemoUser
            {
                PhoneNumber = "0505114071",
                AgeGroup = "طفل",
                IsAdult = false,
                 firstName="فهد",
                 LastName="الحمد",

            },
            new DemoUser
            {
                PhoneNumber = "0503333333",
                AgeGroup = "كبار سن",
                IsAdult = true,
                firstName="عبدالله",
                 LastName="الحمد",


            }
        };
    }

    // تعريف المستخدم التجريبي
    public class DemoUser
    {
        public string PhoneNumber { get; set; }
        public string AgeGroup { get; set; }
        public bool IsAdult { get; set; }
        public string firstName { get; set; }

        public string LastName { get; set; }
    }
}