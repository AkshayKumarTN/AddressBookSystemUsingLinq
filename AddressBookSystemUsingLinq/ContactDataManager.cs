using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBookSystemUsingLinq
{
    public class ContactDataManager
    {
        DataTable dataTable;

        public void CreateDataTable()
        {
            // Creating a object for datatable................
            dataTable = new DataTable();
            // Creating a object for datacolumn.............
            DataColumn dtColumn = new DataColumn();
            // Create FirstName Column...........
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "FirstName";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            // Create LastName Column..........
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "LastName";
            dtColumn.Caption = "Last Name";
            dtColumn.AutoIncrement = false;

            dataTable.Columns.Add(dtColumn);

            // Create Address Column...........
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Address";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            // Create City Column..............
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "City";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            // Create State Column..............
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "State";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            // Create EmailId Column...............
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Email";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            // Create Address column..............    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int64);
            dtColumn.ColumnName = "PhoneNumber";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            // Create ZipCode Column...................
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int64);
            dtColumn.ColumnName = "Zip";
            dtColumn.Caption = "Zip";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

        }

        // Method to Add Values in datatable...........
        public int AddValues()
        {
            // Calling the createtable method..........
            CreateDataTable();
            //Create Object for DataTable for adding tow values in table
            Contact contact1 = new Contact();
            Contact contact2 = new Contact();

            // Insert Values of contact1 into Table.............
            contact1.firstName = "Surya";
            contact1.lastName = "V";
            contact1.phoneNumber = 9876543219;
            contact1.emailId = "Surya@yahoo.com";
            contact1.address = "T-Nagar";
            contact1.city = "Chennai";
            contact1.state = "Tamilnadu";
            contact1.zipCode = 600132;
            // Calling the insert table to insert the data..........
            InsertintoDataTable(contact1);

            // Insert Values of contact2 into Table.............
            contact2.firstName = "Sam";
            contact2.lastName = "R";
            contact2.phoneNumber = 9876512349;
            contact2.emailId = "Sam2@gmail.com";
            contact2.address = "Ranapuram";
            contact2.city = "Chennai";
            contact2.state = "Tamilnadu";
            contact2.zipCode = 600068;
            InsertintoDataTable(contact2);
            // Returning the count of inserted data..............
            return dataTable.Rows.Count;
        }

        // Method to Insert values in Data Table................
        public void InsertintoDataTable(Contact contact)
        {
            DataRow dtRow = dataTable.NewRow();
            dtRow["FirstName"] = contact.firstName;
            dtRow["LastName"] = contact.lastName;
            dtRow["Address"] = contact.address;
            dtRow["City"] = contact.city;
            dtRow["State"] = contact.state;
            dtRow["Zip"] = contact.zipCode;
            dtRow["PhoneNumber"] = contact.phoneNumber;
            dtRow["Email"] = contact.emailId;
            dataTable.Rows.Add(dtRow);

        }
        // Method to Display all Values in Table...................
        public void Display()
        {

            Console.WriteLine("\n-------------Values in datatable------------\n");
            foreach (DataRow dtRows in dataTable.Rows)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}\n", dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
            }
        }

        // Method to Modify Data Table Using FirstName............
        public bool ModifyDataTableUsingName(string FirstName, string ColumnName, string value )
        {
            AddValues();
            var modifiedList = (from Contact in dataTable.AsEnumerable() where Contact.Field<string>("FirstName") == FirstName select Contact).LastOrDefault();
            if (modifiedList != null)
            {
                modifiedList[ColumnName] = value;
                Display();
                return true;
            }
            return false;
        }

        public bool DeleteRecordUsingName(string FirstName)
        {
            //Calling the add values to data table
            AddValues();
            //performing delete operation using linq
            var modifiedList = (from Contact in dataTable.AsEnumerable() where Contact.Field<string>("FirstName") == FirstName select Contact).FirstOrDefault();
            if (modifiedList != null)
            {
                modifiedList.Delete();
                Console.WriteLine("******* After Deletion ******");
                Display();
                return true;
            }
            return false;
        }

        public string RetrieveDataBasedOnCityorState(string CityName, string StateName)
        {
            AddValues();
            string nameList = null;
            var modifiedList = (from Contact in dataTable.AsEnumerable() where (Contact.Field<string>("State") == StateName || Contact.Field<string>("City") == CityName) select Contact);
            foreach (var dtRows in modifiedList)
            {
                if (dtRows != null)
                {
                    Console.WriteLine("{0} | {1} | {2} |  {3} | {4} | {5} | {6} | {7} \n", dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
                    nameList += dtRows["FirstName"] + " ";
                }
                else
                {
                    nameList = null;
                }
            }
            return nameList;
        }

        public string RetrieveCountBasedOnCityorState()
        {
            AddValues();
            string result = "";
            var modifiedList = (from Contact in dataTable.AsEnumerable().GroupBy(r => new { City = r["City"], StateName = r["State"] }) select Contact);
            Console.WriteLine("*****After Count of City And State");
            foreach (var i in modifiedList)
            {
                result += i.Count() + " ";
                Console.WriteLine("Count Key" + i.Key);
                foreach (var dtRows in i)
                {
                    if (dtRows != null)
                    {
                        Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \n", dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
                    }

                    else
                    {
                        result = null;
                    }
                }
            }
            Console.WriteLine(result);
            return result;

        }

        public string SortBasedOnNameInDataTable(string CityName)
        {
            AddValues();
            string result = null;
            var modifiedRecord = (from Contact in dataTable.AsEnumerable() orderby Contact.Field<string>("FirstName") where Contact.Field<string>("City") == CityName select Contact);
            Console.WriteLine("****After Sorting Their Name For a given city*********");
            foreach (var dtRows in modifiedRecord)
            {
                if (dtRows != null)
                {
                    Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7}\n", dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
                    result += dtRows["FirstName"] + " ";
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }
    }
}
