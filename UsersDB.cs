/*******************************************************************
* Name: Brianna Schneider
* Date: December 6, 2023
* Project Quiz App
*
* Class to handle all interactions with the Users table in the
* database, including creating the table if it doesn't exist and all
* CRUD (Create, Read Update, Delete) operations on the People table.
* Note that the interactions are all done using standard SQL syntax
* that is then executed by the SQLite library.
*/
using System.Data.SQLite;
public class UsersDB
{
    public static void CreateTable(SQLiteConnection conn)
    {
        // SQL statement for creating a new table
        string sql =
            "CREATE TABLE IF NOT EXISTS Users (\n"
            + " ID integer PRIMARY KEY\n"
            + " ,FirstName varchar(20)\n"
            + " ,LastName varchar(40)\n"
            + " ,Age integer \n);";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void AddUser(SQLiteConnection conn, User u)
    {
        string sql = string.Format(
            "INSERT INTO Users(FirstName, LastName, Age) "
            + "VALUES('{0}','{1}',{2})",
        u.FirstName, u.LastName, u.Age);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void UpdateUser(SQLiteConnection conn, User u)
    {
        string sql = string.Format(
            "UPDATE Users SET FirstName='{0}', LastName='{1}', Age={2}"
            + " WHERE ID={3}", u.FirstName, u.LastName, u.Age, u.ID);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void DeleteUser(SQLiteConnection conn, int id)
    {
        string sql = string.Format("DELETE from Users WHERE ID = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static List<User> GetAllUsers(SQLiteConnection conn)
    {
        List<User> users = new List<User>();
        string sql = "SELECT * FROM Users";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            users.Add(new User(
            rdr.GetInt32(0),
            rdr.GetString(1),
            rdr.GetString(2),
            rdr.GetInt32(3)
            ));
        }
        return users;
    }
    public static User GetUser(SQLiteConnection conn, string firstName)
    {
        string sql = string.Format("SELECT * FROM Users WHERE FirstName = '{0}'", firstName);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            return new User(
                rdr.GetInt32(0),
                rdr.GetString(1),
                rdr.GetString(2),
                rdr.GetInt32(3)
            );
        }
        else
        {
            return new User(-1, string.Empty, string.Empty, -1);
        }
    }
}