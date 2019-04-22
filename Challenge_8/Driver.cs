using System.Collections.Generic;

namespace Challenge_8
{
    public class Driver
    {
        private string _fullName;

        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MyProperty { get; set; }
        public string FullName
        {
            get => _fullName;
            set { _fullName = LastName + ", " + FirstName; }
        }

        public List<Car> Cars { get; set; }
    }
}