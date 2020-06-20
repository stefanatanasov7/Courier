using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create parcels and attach employees

        ParcelForPlovdiv parcelForPlovdiv = new ParcelForPlovdiv("Пратка за Пловдив", 4.00);
        parcelForPlovdiv.Attach(new Employee("Служител #1"));
        parcelForPlovdiv.Attach(new Employee("Служител #2"));
        parcelForPlovdiv.Attach(new Employee("Служител #3"));

        ParcelForBulgaria parcelForBulgaria = new ParcelForBulgaria("Пратка за Страната", 4.50);
        parcelForBulgaria.Attach(new Employee("Служител #1"));
        parcelForBulgaria.Attach(new Employee("Служител #2"));
        parcelForBulgaria.Attach(new Employee("Служител #3"));

        ParcelForAbroad parcelForAbroad = new ParcelForAbroad("Пратка за Чъжбина", 10.20);
        parcelForAbroad.Attach(new Employee("Служител #1"));
        parcelForAbroad.Attach(new Employee("Служител #2"));
        parcelForAbroad.Attach(new Employee("Служител #3"));

        parcelForPlovdiv.Price = 4.50;
        parcelForPlovdiv.Price = 5.20;
        parcelForPlovdiv.Price = 5.20;

        parcelForBulgaria.Price = 6.10;
        parcelForBulgaria.Price = 7.50;
        parcelForBulgaria.Price = 8.80;

        parcelForAbroad.Price = 12.20;
        parcelForAbroad.Price = 15.50;
        parcelForAbroad.Price = 20.10;

        // Wait for user

        Console.ReadKey();
    }
}



abstract class Parcel
{
    private string _parcelType;

    private double _price;

    private List<IEmployee> _employees = new List<IEmployee>();

    // Constructor

    public Parcel(string parcelType, double price)
    {
        this._parcelType = parcelType;

        this._price = price;
    }


    public void Attach(IEmployee employee)
    {
        _employees.Add(employee);
    }

    public void Detach(IEmployee employee)

    {
        _employees.Remove(employee);
    }


    public void Notify()
    {
        foreach (IEmployee employee in _employees)
        {
            employee.Update(this);
        }
        Console.WriteLine("");
    }



    public double Price
    {
        get { return _price; }

        set

        {

            if (_price != value)

            {

                _price = value;

                Notify();

            }

        }

    }




    public string ParcelName

    {

        get { return _parcelType; }

    }

}


class ParcelForAbroad : Parcel

{


    public ParcelForAbroad(string parcelType, double price)

      : base(parcelType, price)

    {

    }

}

class ParcelForBulgaria : Parcel

{


    public ParcelForBulgaria(string parcelType, double price)

      : base(parcelType, price)

    {

    }

}

class ParcelForPlovdiv : Parcel

{


    public ParcelForPlovdiv(string parcelType, double price)

      : base(parcelType, price)

    {

    }

}



interface IEmployee

{

    void Update(Parcel parcel);

}




class Employee : IEmployee

{

    private string _name;

    private Parcel _parcel;



    // Constructor

    public Employee(string name)

    {

        this._name = name;

    }



    public void Update(Parcel parcel)

    {

        Console.WriteLine(" {0} уведомява, че е постъпила {1} " +

          "с цена {2:C} и преминава в състояние на подготовка", _name, parcel.ParcelName, parcel.Price);

    }


    // Gets or sets the parcel

    public Parcel parcel

    {

        get { return _parcel; }

        set { _parcel = value; }

    }

}