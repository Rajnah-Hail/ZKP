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
                PhoneNumber = "0501111111",
                AgeGroup = "شاب",
                IsAdult = true
            },
            new DemoUser
            {
                PhoneNumber = "0502222222",
                AgeGroup = "طفل",
                IsAdult = false
            },
            new DemoUser
            {
                PhoneNumber = "0503333333",
                AgeGroup = "كبار سن",
                IsAdult = true
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