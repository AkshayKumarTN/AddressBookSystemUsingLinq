using System;

namespace AddressBookSystemUsingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("  Address Book System Using Linq ");
            Console.WriteLine("********************************************************************************************");

            ContactDataManager contactDataManager = new ContactDataManager();
            contactDataManager.DeleteRecordUsingName("Sam");

        }
    }
}
