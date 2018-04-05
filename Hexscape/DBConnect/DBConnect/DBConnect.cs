/*
 CSC 424
Instructor Lindy Lewis
Down 2
Billy Loveday, Gabriel Mayo, Michael Ouille, Dane Reggia, Chris Touchette
Class definition for the DBConnect class for hExSCAPE
Also serves as a test program for the database connection and Unit class constructor
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DBConnect
{
    class DBConnect
    {
        private MySqlConnection connection;     //object to reference the database connection
        private string server;      //the target server for the database connection
        private string database;    //the specific database in the server
        private string uid;         //user id for database connection
        private string password;    //must match for user id

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string connectionString; //holds the necessary login info

            server = "localhost";
            database = "hexscape";
            uid = "root";
            password = "h3xSc4p3";
            
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";SslMode=none";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            //Exception loop to catch connection errors
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Select from database
        public UnitData SelectUnitData(string uID)
        {
            string query = "SELECT * FROM unit WHERE unitID = " + uID.ToString();    //string for our query
            UnitData result = new UnitData();                       //query will return unit data for 1 unit

            //Open the connection
            if (this.OpenConnection() == true)
            {
                //Query the database
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader unitReader = cmd.ExecuteReader();

                //Read the data and store it in a UnitData struct
                while (unitReader.Read())
                {
                    result.unitName = unitReader.GetString(0);
                    result.unitLevel = unitReader.GetInt32(1);
                    result.maxHitPoints = unitReader.GetInt32(2);
                    result.curHitPoints = result.maxHitPoints;
                    result.maxMagicPoints = unitReader.GetInt32(3);
                    result.curMagicPoints = result.maxMagicPoints;
                    result.strength = unitReader.GetInt32(4);
                    result.dexterity = unitReader.GetInt32(5);
                    result.agility = unitReader.GetInt32(6);
                    result.intelligence = unitReader.GetInt32(7);
                    result.wisdom = unitReader.GetInt32(8);
                    result.charisma = unitReader.GetInt32(9);
                    result.unitType = unitReader.GetInt32(10);
                    result.unitTypeName = unitReader.GetString(11);
                    result.alignment = unitReader.GetString(12);
                    result.unitID = unitReader.GetInt32(13);
                }

                //Return list for display
                return result;
            }
            else
            {
                Console.WriteLine("Could not retrieve requested unit.");
                return result;
            }

        }

        //Main function to test the constructor code
        public static void Main()
        {

            Console.Write("Enter a unit ID to pull a unit from the database:  ");
            string newUnitID = Console.ReadLine();

            try
            {
                Unit myUnit = new Unit(newUnitID);
                Console.WriteLine("Unit #" + myUnit.GetUnitID() + " is a level "
                    + myUnit.GetUnitLevel() + " " + myUnit.GetUnitTypeName() + " named " + myUnit.GetUnitName() + ".");
                Console.WriteLine(myUnit.GetUnitName() + " is " + myUnit.GetAlignment() + ".");
            }
            catch
            {
                Console.WriteLine("Could not retrieve the requested unit.");
            }

            

            Console.Write("\n\nPress any key to continue...");
            Console.ReadLine();
            return;
        }

    }
}
