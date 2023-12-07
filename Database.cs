/*******************************************************************
* Name: Brianna Schneider
* Date: December 3, 2023
* Assignment: CIS317 Week 4 GP – Database Interactions
*
* Class to handle databse interactions with a SQLite database. The
* connect method will either connect to an existing database or
* create the database if the database doesn't exist.
*/
using System.Data.SQLite;
public class Database
{
    public static SQLiteConnection Connect(string database)
    {
        string cs = @"Data Source=" + database;
        SQLiteConnection conn = new SQLiteConnection(cs);
        try
        {
            conn.Open();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return conn;
    }
}