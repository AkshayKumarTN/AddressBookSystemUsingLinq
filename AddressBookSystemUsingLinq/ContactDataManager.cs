using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
