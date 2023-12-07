/*******************************************************************
* Name: Brianna Schneider
* Date: December 3, 2023
* Project Quiz Application
*
* Main application class.
*/
using System.Data.SQLite;
public class QuizTest
{
    public static void Main(string[] args)
    {
        const string dbName = "users.db";
        SQLiteConnection conn = Database.Connect(dbName);
        if (conn != null)
        {
            UsersDB.CreateTable(conn);
            //Create
            Console.WriteLine("Enter your first name: ");
            string? fName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter your last name: ");
            string? lName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("What is your age: ");
            int uAge = Convert.ToInt32(Console.ReadLine());
            //Add user to Database Table
            UsersDB.AddUser(conn, new User(fName,lName,uAge));
            //start quiz
            string userName = fName + " " + lName;
            Console.WriteLine("Welcome to the Quiz Game " + userName); 

            //string array for the questions that will be asked 
            //and easy to add extra questions later
            string[] questions =
            {
                "In what country did the first Starbucks open outside of North America?",
                "What is the tiny piece at the end of a shoelace called?",
                "In what year was the internet opened to the public?",
                "What was the first Disney animated feature movie that was not based on an already existing story?",
                "What is the national sport of Jamaica?"
            };//end of questions array

            //string array for the answers choices to the questions
            string[] answers =
            {
                "A. England \nB. Mexico \nC. Japan",
                "A. aglet \nB. tip \nC. eyelet",
                "A. 1990 \nB. 1993 \nC. 1989",
                "A. The Little Mermaid \nB. The Lion King \nC. Snow White",
                "A. Lacrosse \nB. Soccer \nC. Cricket"
            };//end of answers array
            
            
            int[] correctAnswers = {2, 0, 1, 1, 2};

            int playerScore = 0;

            for (int i=0; i < questions.Length; i++)
            {
                Console.WriteLine("Question " + (i + 1));
                Console.WriteLine(questions[i]);
                Console.WriteLine(answers[i]);
                Console.Write("Please enter your answer ('A','B', or 'C'): ");
                string? playerAnswer = Console.ReadLine();

                // Validating Answers
                if(string.Equals(playerAnswer, "A", StringComparison.OrdinalIgnoreCase) && correctAnswers[i] == 0)
                {
                    playerScore++;
                }
                else if(string.Equals(playerAnswer, "B", StringComparison.OrdinalIgnoreCase) && correctAnswers[i] == 1)
                {
                    playerScore++;
                }
                else if(string.Equals(playerAnswer, "C", StringComparison.OrdinalIgnoreCase) && correctAnswers[i] == 2)
                {
                    playerScore++;
                }
            }


            Console.WriteLine("\nQuiz Complete\n");
            
            PrintUser(UsersDB.GetUser(conn, fName)) ;
            Console.Write(playerScore + "/" + questions.Length);
            
          
        }
        
    }//end of Main
    private static void PrintUsers(List<User> users)
    {
        foreach (User u in users)
        {
            PrintUser(u);
        }
    }
    private static void PrintUser(User u)
    {
        Console.WriteLine("User " + u.ID + ": ");
        Console.WriteLine("Congradulations " + u.FirstName + " " + u.LastName + "!!\n At "
            + u.Age + " years old you have managed to get a score of: " );
    }
}