/*******************************************************************
* Name: Brianna Schneider
* Date: December 6, 2023
* Project Quiz App
*
* Class that represents an individual user record from the Users
* table in the database. 
*/
public class User {
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public User(int iD, string firstName, string lastName, int age) {
        ID = iD;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
    public User(string firstName, string lastName, int age) {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}