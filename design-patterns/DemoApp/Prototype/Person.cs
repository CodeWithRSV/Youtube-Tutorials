using System;

namespace DemoApp
{
    public class Person : ICloneable
    {
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }

        public Address Address { get; set; }

        public object Clone()
        {
            //Shallow Clone
            return MemberwiseClone();
        }
        public object DeepClone()
        {
            return new Person { Age = Age, BirthDate = BirthDate, Name = Name, Address = new Address(Address.HouseNumber) };
        }


        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, BirthDate: {BirthDate}, HouseNumber: {Address?.HouseNumber}";
        }
    }

    public class Address
    {
        public int HouseNumber { get; set; }
        public Address(int houseNumber)
        {
            this.HouseNumber = houseNumber;
        }
    }
}