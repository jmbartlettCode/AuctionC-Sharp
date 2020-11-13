/* 
Josh Bartlett
19July2019
Assignment 5.2
Using overloaded methods that accept an int, double, or string bids. Each 
method should display the bid and indicate whether it is over the minimum
acceptable bid of $10. If the bid is a string accept is only if one of the 
following is true; it is numeric and preceded with a dollar sign, or it is 
numeric and followed by the word dollars. If bid is formatted incorrectly 
or below the minimum show error message and allow user to continue until 
they have input a correct bid.
*/

using System;
using static System.Console;


class Auction
{
    // Declare static variable to be used whole class
    static string entryString;
    
    static void Main()
    {    
        // Declare variables to be used in Main class
        int bid;
        double dBid;
        // Boolean for use in the while loop
        bool retry = true;
        // while loop to loop until an acceptable bid is input
        while(retry)
        {
            // Calls the instructions method 
            Instructions();
            // if statement to check how bid is entered and then passes it onto the overloaded methods 
            if(int.TryParse(entryString, out bid))
            {
                retry = !AcceptBid(bid);
            }
            else if(double.TryParse(entryString, out dBid))
            {
                retry = !AcceptBid(dBid);
            }
            else
            {
                retry = !AcceptBid(entryString);
            }
        }
        // Keeps console open until a key is pressed
        ReadKey(true);
    }
    // Instructions method provides explicit instructions on how an acceptable bid should be formatted and the minimum
    private static void Instructions()
    {
        WriteLine("Only bids of whole numbers(ex 10), decimal numbers(ex 10.00), or are either of those and");
        WriteLine("are preceded by a $ or followed by the word dollars will be accepted. Minimum bid is $10.");
        WriteLine();
        Write("Please Enter Your Bid: ");
        entryString = ReadLine();
        WriteLine();
    }
    // int part of the of the overloaded method to process the bids that are input as ints
    private static bool AcceptBid(int number)
    {
        
        // Accepts int bid if greater than or equal to $10 ends loop with return
        if(number > 9)
        {
            WriteLine("Your bid of ${0} is accepted.", number);
            return true;
        }
        // Denys bid if less than $10 and continues loop 
        else
        {
            WriteLine("Bids must be at least $10. Please try again.");
            return false;
        }
        
    }
    // double part of the of the overloaded method to process the bids that are input as doubles
    private static bool AcceptBid(double doubleNum)
    {
        // Accepts int bid if greater than or equal to $10 ends loop with return
        if(doubleNum >= 10.00)
        {
            WriteLine("Your bid of ${0} is accepted.", doubleNum);
            return true;
        }
        // Denys bid if less than $10 and continues loop 
        else
        {
            WriteLine("Bids must be at least $10. Please try again.");
            return false;
        }
    }
    // string part of the of the overloaded method to process the bids that are input that are not ints or doubles
    private static bool AcceptBid(string word)
    {
        double bid;
        // if string starts with $ and has more than 1 character continue to next if
        if (word.StartsWith("$") && word.Length > 1) 
        {
            // Parses the whole string to a double except the $, 0 index
            if(double.TryParse(word.Substring(1), out bid))
            {
                // Accepts int bid if greater than or equal to $10 ends loop with return
                if(bid >= 10.00)
                {
                    WriteLine("Your bid of ${0} is accepted.", bid);
                    return true;
                }
                // Denys bid if less than $10 and continues loop 
                else
                {
                    WriteLine("Bids must be at least $10. Please try again.");
                    return false;
                }
            }
            // else part of the if the string doesn't start with a $ or isn't longer than 1 character
            else
            {
                // Denys bid because of improper format and continues loop
                WriteLine("Bid was not formatted correctly. Please try again.");
                return false;
            }
        } 
        // Checks string length and if it is greater than or equal to 7 continue
        else if (word.Length >= 7) 
        {
            // Checks that the word dollars is at the end of the string
            if (word.Substring(word.Length - 7) == "dollars")
            {
                // Parses the numerical data to a double leaving off the letters 
                if(double.TryParse(word.Substring(0, word.Length - 7), out bid))
                {
                    // Accepts int bid if greater than or equal to $10 ends loop with return
                    if(bid >= 10.00)
                    {
                        WriteLine("Your bid of ${0} is accepted.", bid);
                        return true;
                    }
                    // Denys bid if less than $10 and continues loop
                    else
                    {
                        WriteLine("Bids must be at least $10. Please try again.");
                        return false;
                    }
                }
                // Denys bid because of improper format and continues loop
                else 
                {
                    WriteLine("Bid was not formatted correctly. Please try again.");
                    return false;
                }
            } 
            // Denys bid because of improper format and continues loop
            else 
            {
                WriteLine("Bid was not formatted correctly. Please try again.");
                return false;
            }
        } 
        // Denys bid because of improper format and continues loop
        else 
        {
            WriteLine("Bid was not formatted correctly. Please try again.");
            return false;
        }
    } 
}
