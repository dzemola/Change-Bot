using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Change_Bot
{
    public class transinfo
    {
        struct till
        {
            //Setting the structure

            public double Ones;
            public double Fives;
            public double Tens;
            public double Twentys;
            public double Fiftys;
            public double Hundreds;
            public double Pennys;
            public double Nickles;
            public double Dimes;
            public double Quarters;
            public int onesAmount;
            public int fivesAmount;
            public int tensAmount;
            public int twentysAmount;
            public int fiftysAmount;
            public int hundredsAmount;
            public int pennysAmount;
            public int nicklesAmount;
            public int dimesAmount;
            public int quartersAmount;
        }

        //Adding a struct to use the variables throughout the program
        public struct Transaction
        {
            public int transactionNum;
            public string transactionDate;
            public double cashAmount;
            public string cardVendor;
            public double cardAmount;
            public double changeGiven;
        }

         public static Transaction trans;

        static void Main(string[] args)
        {
            //Intro screen to the ChangeBot adding colors and ascii art
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("************************************************************************************************************************");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.Write("*                      ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("                     WELCOME TO D & C CHANGEBOT                              ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("                   *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.Write("*                      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("                      PRESS ANY KEY TO CONTINUE                              ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("                   *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("*                                                                                                                      *");
            Console.WriteLine("************************************************************************************************************************");

            //Changing background color and text color
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();

            //Variables
            double price = 0;
            string more = "";
            trans.cashAmount = 0;
            trans.cardVendor = "No_Vendor_Given";
            trans.cardAmount = 0;
            trans.changeGiven = 0;

            //Using a Do loop to get total for all products scanned
            do
            {
                Console.Write("Please enter your items price: ");

                //Change text color
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write("$" );

                //Saving the amount of each item scanned
                price = price + Convert.ToDouble(Console.ReadLine());

                //Change text color
                Console.ForegroundColor = ConsoleColor.White;

                //Line Break
                Console.WriteLine("");

                //Asking if the user has more items to scan or if they are ready to checkout
                Console.Write("Do you have another item to scan? (y/n):  ");

                //Change text color
                Console.ForegroundColor = ConsoleColor.Magenta;

                more = Console.ReadLine().ToLower();

                //Change text color
                Console.ForegroundColor = ConsoleColor.White;

                //Line Break
                Console.WriteLine();

            } while (more == "y");
            //End Loop

            //Sending the total to the payment choice
            payChoice(price);

            Console.WriteLine();

            transLogging();
        }//End main function
        static void payChoice(double purchaseTotal)
        {
            //Variables
            string cash = "cash";
            string card = "card";
            string choice = "";

            //Having the user choose a cash payment or card. Then saving the result to the variable
            Console.Write("Would you like to pay with cash or card? ");

            //Chnage text color
            Console.ForegroundColor = ConsoleColor.Magenta;

            choice = Console.ReadLine().ToLower();

            //Change text color
            Console.ForegroundColor = ConsoleColor.White;

            //Line Break
            Console.WriteLine();

            //If/ Else statement to send the user to the cash or card function to complete the payment transaction
            if (choice == cash)
            {
                cashEntry(purchaseTotal);
                trans.cashAmount = purchaseTotal;
            }//End if statement
            if (choice == card)
            {
                cardEntry(purchaseTotal);
            }//End if statement

            //If anything else other than cash or card is chosen it will send an error and terminate the transaction
            if (choice != cash && choice != card)
            {
                //Change text color
                Console.ForegroundColor = ConsoleColor.Red;

                //Send error message 
                Console.WriteLine("Error, Please try again.");

                //Change text color
                Console.ForegroundColor = ConsoleColor.White;

                //Send user back to pay choice
                payChoice(purchaseTotal);

                //Line Break
                Console.WriteLine();

            }//End if statement

        }//End payChoice function
        static void cardEntry(double total)
        {
            //Variables
            double cBack = 0;
            string choice = "";
            double total2 = 0;
            string result = "";
            long cardNumber = 0;
            
            //Change letter color
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("Total Amount: ");

            //Change text color
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.Write("{0:C}", total);

            //Line Break
            Console.WriteLine();
            Console.WriteLine();

            //Change letter color
            Console.ForegroundColor = ConsoleColor.White;

            //Asking the user if they would like cash back and saving the choice to a variable
            Console.Write("Would you like cash back? (y/n): ");

            //Change text color
            Console.ForegroundColor = ConsoleColor.Magenta;

            choice = Console.ReadLine().ToLower();

            //Change text color
            Console.ForegroundColor = ConsoleColor.White;
            //Line Break
            Console.WriteLine();

            //If statement to recognize fithe user choses a lower case or upper case it will haow much cash back they would like 
            if (choice == "y")
            {
                Console.Write("Please add the amount of cash you would like back: ");

                //Change text color
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("$");

                cBack = Convert.ToDouble(Console.ReadLine());

                //Change text color
                Console.ForegroundColor = ConsoleColor.White;
            }//End if statement

            //Using a variable to save the total between cash back and purchase total
            total2 = cBack + total;
            
            //Saving total amount to be charged to the card to send to the transaction log
            trans.cardAmount = total2;
            
            //Line Break
            Console.WriteLine();

            //Change text color
            Console.ForegroundColor = ConsoleColor.Red;
            
            //Displaying the total of cash back and purchase total
            Console.Write("Total: ");

            //Change text color
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("{0:C}", total2);

            //Change text color
            Console.ForegroundColor = ConsoleColor.White;

            //Line Break
            Console.WriteLine();

            //Do loop to get the card info and display card type if it is a valid or invalid card number
            do
            {
                //Line Break
                Console.WriteLine();

                //User enters card number and it is saved to a variable
                Console.WriteLine("Please enter card number now.");

                //Change text color
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                cardNumber = Convert.ToInt64(Console.ReadLine());

                //Chnage text color
                Console.ForegroundColor = ConsoleColor.White;
                //Line Break
                Console.WriteLine();

                //Sending the card number to check and display the card type
                Console.WriteLine(cardType(cardNumber.ToString()));

                //Saving card type info to send to tranaction log
                trans.cardVendor = cardType(cardNumber.ToString());

                //Change text color
                Console.ForegroundColor = ConsoleColor.White;
               
                //Line Break
                Console.WriteLine();

                //Card number being sent to check if it is a valid or invalid card number and display it
                Console.Write("Card Number: ");

                //Change text color
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write("{0}", cardNumber);

                //Chnage text color
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write(" is ");

                //Change text color
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write(result = isValid(cardNumber) ? " valid " : (Console.ForegroundColor = ConsoleColor.Red) + " invalid ");

                //Change text color
                Console.ForegroundColor = ConsoleColor.White;

                //Line Break
                Console.WriteLine();
            } while (result != " valid ");
            //End loop

            //Line Break
            Console.WriteLine();
            Console.WriteLine();

            //Sending card number, casted purchase total and cash back to check if the cards account has enough funds available
            MoneyRequest(cardNumber.ToString(), ((decimal)total), ((decimal)cBack));

            //Line Break
            Console.WriteLine();
            Console.WriteLine();

            
        }//End cardEntry function
        static string cardType(string number)
        {
            //Variables
            Regex regVisa = new Regex("^4[0-9]{12}(?:[0-9]{3})?$");
            Regex regMaster = new Regex("^5[1-5][0-9]{14}$");
            Regex regExpress = new Regex("^3[47][0-9]{13}$");
            Regex regDiscover = new Regex("^6(?:011|5[0-9]{2})[0-9]{12}$");

            //If/ else statements to identify card type
            if (regVisa.IsMatch(number))
                return "Card_Type:_VISA";

            else if (regMaster.IsMatch(number))
                return "Card_Type:_MASTER";

            else if (regExpress.IsMatch(number))
                return "Card_Type:_AMEX";

            else if (regDiscover.IsMatch(number))
                return "Card_Type:_DISCOVER";

            else
                Console.ForegroundColor = ConsoleColor.Red;
            return "invalid";

        }//End card type function
        static bool isValid(long number)
        {
            //Sending the card number to other functions to check if the card is valid or invalid
            return (getSize(number) >= 13 &&
                      getSize(number) <= 16) &&
                      (prefixMatched(number, 4) ||
                      prefixMatched(number, 5) ||
                      prefixMatched(number, 37) ||
                      prefixMatched(number, 6)) &&
                      ((sumOfDoubleEvenPlace(number) +
                      sumOfOddPlace(number)) % 10 == 0);

        }//End isValid function

        // Get the result from Step 2
        static int sumOfDoubleEvenPlace(long number)
        {
            int sum = 0;
            String num = number + "";
            for (int i = getSize(number) - 2; i >= 0; i -= 2)
                sum += getDigit(int.Parse(num[i] + "") * 2);

            return sum;

        }//End sumOfDoubleEvenPlace function

        // Return this number if it is a
        // single digit, otherwise, return
        // the sum of the two digits
        static int getDigit(int number)
        {
            if (number < 9)
                return number;
            return number / 10 + number % 10;

        }//End getDigit function

        // Return sum of odd-place digits in number
        static int sumOfOddPlace(long number)
        {
            int sum = 0;
            String num = number + "";
            for (int i = getSize(number) - 1; i >= 0; i -= 2)
                sum += int.Parse(num[i] + "");
            return sum;

        }//End sumOfOddPlace function

        // Return true if the digit d
        // is a prefix for number
        static bool prefixMatched(long number, int d)
        {
            return getPrefix(number, getSize(d)) == d;

        }//End prefixMatched function

        // Return the number of digits in d
        static int getSize(long d)
        {
            String num = d + "";
            return num.Length;

        }//End getSize function

        // Return the first k number of digits from
        // number. If the number of digits in number
        // is less than k, return number.
        static long getPrefix(long number, int k)
        {
            if (getSize(number) > k)
            {
                String num = number + "";
                return long.Parse(num.Substring(0, k));
            }
            return number;

        }//End getPrefix function

        static string[] MoneyRequest(string account_number, decimal amount, decimal cashBack)
        {
            //Variables
            Random rnd = new Random();
            //50% CHANCE TRANSACTION PASSES OR FAILS 
            bool pass = rnd.Next(100) < 50;
            //50% CHANCE THAT A FAILED TRANSACTION IS DECLINED 
            bool declined = rnd.Next(100) < 50;
            decimal totalAmount = amount + cashBack;

            //If/ esle staement to check if the card number has enough funds or not
            if (pass)
            {
                //Variable
                string[] blank = new string[] { };
                double tillcheck = (double)cashBack * -1;

                //Set string array
                string[] approved = new string[] { "Card Number: ", account_number, ", Amount Approved $", totalAmount.ToString() };

                //Change text color
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                //Traverse through the string array
                foreach (string money in approved)
                {
                    Console.Write(money);
                }//End foreach loop

                //Line Break
                Console.WriteLine();
                Console.WriteLine();

                //Sending total amount to display and dispense cash back
                cashEntry(tillcheck);

                return blank;

            }//End if statement
            else
            {
                //If/ else statement to diplay if the card account does not have enough money or if it is declined 
                if (!declined)
                {
                    //Set a blank array
                    string[] blank = new string[] { };

                    //Set string array
                    string[] noMoney = new string[] { "Account Number: ", account_number, ", Avialable Balance: $", Math.Round(amount / rnd.Next(2, 6), 2).ToString() };

                    //Change text color
                    Console.ForegroundColor = ConsoleColor.Red;

                    //Traverse through the string array
                    foreach (string money in noMoney)
                    {
                        Console.Write(money);
                    }//End foreach loop

                    //Line Break
                    Console.WriteLine();
                    Console.WriteLine();

                    //Letting user know they do not have enough funds available in that account
                    Console.WriteLine("Not enough funds avialable.");

                    //Line Break
                    Console.WriteLine();

                    Console.WriteLine("Please choose another form of payment.");

                    //Change text color
                    Console.ForegroundColor = ConsoleColor.White;

                    //Line Break
                    Console.WriteLine();

                    Console.WriteLine("Press any key to continue.");

                    //Pause
                    Console.ReadKey();

                    //Clear console
                    Console.Clear();

                    //Sending the user back to payChoice for another form of payment
                    payChoice((double)amount);
                   
                    return blank;

                }//End if statement
                else
                {
                    //Setting a blank array
                    string[] blank = new string[] { };

                    //Setting string array
                    string[] noDough = new string[] { "Card Number: ", account_number, ", declined" };

                    //Change text color
                    Console.ForegroundColor = ConsoleColor.Red;

                    //Traverse through the string array
                    foreach (string money in noDough)
                    {
                        Console.Write(money);
                    }//End foreach loop

                    //Line Break
                    Console.WriteLine();
                    Console.WriteLine();

                    //Asking the user to choose another form of payment
                    Console.WriteLine("Please choose another form of payment.");

                    //Change text color
                    Console.ForegroundColor = ConsoleColor.White;

                    //Line Break
                    Console.WriteLine();

                    Console.WriteLine("Press any key to continue.");

                    //Pause
                    Console.ReadKey();

                    //Clear console
                    Console.Clear();

                    //Sending the user back to payChoice for another form of payment
                    payChoice((double)amount);
                    
                    return blank;

                }//end if
            }//end if    
        }//End of MoneyRequest function
        static void cashEntry(double total)
        {
            //Variables
            double dollarEntry = 0.0;
            double difference = 0.0;

            //Set structure mains
            till bills;
            till change;

            //Set total of each bill amount alone
            bills.Ones = 1;
            bills.Fives = 5;
            bills.Tens = 10;
            bills.Twentys = 20;
            bills.Fiftys = 50;
            bills.Hundreds = 100;

            //Set total of each change amount alone
            change.Pennys = .01;
            change.Nickles = .05;
            change.Dimes = .10;
            change.Quarters = .25;

            //Set total of bills being held for each
            bills.onesAmount = 20;
            bills.fivesAmount = 10;
            bills.tensAmount = 10;
            bills.twentysAmount = 5;
            bills.fiftysAmount = 2;
            bills.hundredsAmount = 1;

            //Set total of change being held for each
            change.pennysAmount = 100;
            change.nicklesAmount = 100;
            change.dimesAmount = 50;
            change.quartersAmount = 40;

            //Change letter color
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("Total Amount: ");

            //Change text color
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.Write("{0:C}", total);

            //Line Break
            Console.WriteLine();
            Console.WriteLine();

            //Change letter color
            Console.ForegroundColor = ConsoleColor.White;

            if (total > 0)
            {
                //Using a do/while loop to recieve payment and add it to the till
                do
                {
                    Console.Write("Please enter a singular bill/coin: ");

                    Console.ForegroundColor = ConsoleColor.Green;

                    dollarEntry = double.Parse(Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.Gray;

                    //$100
                    if (dollarEntry == 100)
                    {
                        bills.Hundreds += 1;
                        bills.hundredsAmount += 1;
                    }
                    //$50
                    if (dollarEntry == 50)
                    {
                        bills.Fiftys += 1;
                        bills.fiftysAmount += 1;
                    }
                    //$20
                    if (dollarEntry == 20)
                    {
                        bills.Twentys += 1;
                        bills.twentysAmount += 1;
                    }
                    //$10
                    if (dollarEntry == 10)
                    {
                        bills.Tens += 1;
                        bills.tensAmount += 1;
                    }
                    //$5
                    if (dollarEntry == 5)
                    {
                        bills.Fives += 1;
                        bills.fivesAmount += 1;
                    }
                    //$1
                    if (dollarEntry == 1)
                    {
                        bills.Ones += 1;
                        bills.onesAmount += 1;
                    }
                    //$0.25
                    if (dollarEntry == .25)
                    {
                        change.Quarters += 1;
                        change.quartersAmount += 1;
                    }
                    //$0.10
                    if (dollarEntry == .10)
                    {
                        change.Dimes += 1;
                        change.dimesAmount += 1;
                    }
                    //$0.05
                    if (dollarEntry == .05)
                    {
                        change.Nickles += 1;
                        change.nicklesAmount += 1;
                    }
                    //$0.01
                    if (dollarEntry == .01)
                    {
                        change.Pennys += 1;
                        change.pennysAmount += 1;
                    }

                    total -= dollarEntry;

                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Your balance is: {0:C}", total);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                //The while loop will set the condition to dispense the change due
                while (total > 0.00);
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Change Due: {0:C}", Math.Abs(total));

                    //Saving the amount of change back after paying cash to be sent to the transaction log
                    trans.changeGiven = total * -1;

                    Console.ForegroundColor = ConsoleColor.Gray;

                    //Do loop will see what change is needed and dispense it from the till
                    do
                    {
                        //Rounding to 2 digits after the decimal
                        Math.Round(total, 2);
                        total = Math.Round(total, 2);

                        //Dispense $100
                        if (total <= -100 && bills.hundredsAmount > 0)
                        {
                            for (double i = 0; i >= total; i -= 100)
                            {
                                total += 100;
                                bills.hundredsAmount--;
                                Console.WriteLine("Dispensing $100");
                            }
                        }
                        //Dispense $50
                        else if (total <= -50 && bills.fiftysAmount > 0)
                        {
                            for (double i = 0; i >= total; i -= 50)
                            {
                                total += 50;
                                bills.fiftysAmount--;
                                Console.WriteLine("Dispensing $50");
                            }
                        }
                        //Dispense $20
                        else if (total <= -20 && bills.twentysAmount > 0)
                        {
                            for (double i = 0; i >= total; i -= 20)
                            {
                                total += 20;
                                bills.twentysAmount--;
                                Console.WriteLine("Dispensing $20");
                            }

                        }
                        //Dispense $10
                        else if (total <= -10 && bills.tensAmount > 0)
                        {
                            for (double i = 0; i >= total; i -= 10)
                            {
                                total += 10;
                                bills.tensAmount--;
                                Console.WriteLine("Dispensing $10");
                            }

                        }
                        //Dispense $5
                        else if (total <= -5 && bills.fivesAmount > 0)
                        {
                            for (double i = 0; i >= total; i -= 5)
                            {
                                total += 5;
                                bills.fivesAmount--;
                                Console.WriteLine("Dispensing $5");
                            }

                        }
                        //Dispense $1
                        else if (total <= -1 && bills.onesAmount > 0)
                        {
                            for (double i = 0; i >= total; i -= 1)
                            {
                                total += 1;
                                bills.onesAmount--;
                                Console.WriteLine("Dispensing $1");
                            }
                        }
                        //Dispense $0.25
                        else if (total <= -0.25 && change.quartersAmount > 0)
                        {
                            for (double i = 0; i >= total; i -= .25)
                            {
                                total += .25;
                                change.quartersAmount--;
                                Console.WriteLine("Dispensing $0.25");
                            }
                        }
                        //Dispense $0.10
                        else if (total <= -0.10 & change.dimesAmount > 0)
                        {
                            for (double i = 0; i >= total; i -= .10)
                            {
                                total += .10;
                                change.dimesAmount--;
                                Console.WriteLine("Dispensing $0.10");
                            }
                        }
                        //Dispense $0.05
                        else if (total <= -0.05 && change.nicklesAmount > 0)
                        {
                            for (double i = 0; i >= total; i -= .05)
                            {
                                total += .05;
                                change.nicklesAmount--;
                                Console.WriteLine("Dispensing $0.05");
                            }
                        }
                        //Dispense $0.01
                        else if (total <= -0.01 && change.pennysAmount > 0)
                        {
                            for (double i = 0; i >= total; i -= 0.01)
                            {
                                total += 0.01;
                                change.pennysAmount--;
                                Console.WriteLine("Dispensing $0.01");
                            }
                        }


                    }
                    while (total < 0.0);
                }
            }
            else
            {
                //Do loop will see what change is needed and dispense it from the till
                do
                {   //round each value to second decimal point to keep the statements flowing properly
                    Math.Round(total, 2);
                   
                    total = Math.Round(total, 2);

                    //Saving the amount of cash back from the card to be sent to the transaction log
                    trans.changeGiven = total * -1;

                    Console.WriteLine();
                    if (total <= -100 && bills.hundredsAmount > 0)
                    {
                        do
                        {
                            total += 100;
                            bills.hundredsAmount--;
                            Console.WriteLine("Dispensing $100\n");

                        } while (total <= -100 && bills.hundredsAmount > 0);
                    }
                    else if (total <= -50 && bills.fiftysAmount > 0)
                    {
                        do
                        {
                            total += 50;
                            bills.fiftysAmount--;
                            Console.WriteLine("Dispensing $50\n");

                        } while (total <= -50 && bills.fiftysAmount > 0);
                    }
                    else if (total <= -20 && bills.twentysAmount > 0)
                    {
                        do
                        {
                            total += 20;
                            bills.twentysAmount--;
                            Console.WriteLine("Dispensing $20\n");

                        } while (total <= -20 && bills.twentysAmount > 0);

                    }
                    else if (total <= -10 && bills.tensAmount > 0)
                    {
                        do
                        {
                            total += 10;
                            bills.tensAmount--;
                            Console.WriteLine("Dispensing $10\n");
                        } while (total <= -10 && bills.tensAmount > 0);

                    }
                    else if (total <= -5 && bills.fivesAmount > 0)
                    {
                        do
                        {
                            total += 5;
                            bills.fivesAmount--;
                            Console.WriteLine("Dispensing $5\n");
                        } while (total <= -5 && bills.fivesAmount > 0);
                    }
                    else if (total <= -1 && bills.onesAmount > 0)
                    {
                        do
                        {
                            total += 1;
                            bills.onesAmount--;
                            Console.WriteLine("Dispensing $1\n");
                        } while (total <= -1 && bills.onesAmount > 0);
                    }
                    else if (total <= -0.25 && change.quartersAmount > 0)
                    {
                        do
                        {
                            total += .25;
                            change.quartersAmount--;
                            Console.WriteLine("Dispensing 0.25\n");
                        } while (total <= -0.25 && change.quartersAmount > 0);
                    }
                    else if (total <= -0.10 && change.dimesAmount > 0)
                    {
                        do
                        {
                            total += .10;
                            change.dimesAmount--;
                            Console.WriteLine("Dispensing 0.10\n");
                        } while (total <= -0.10 && change.dimesAmount > 0);
                    }
                    else if (total <= -0.05 && change.nicklesAmount > 0)
                    {
                        do
                        {
                            total += .05;
                            change.nicklesAmount--;
                            Console.WriteLine("Dispensing 0.05\n");
                        } while (total <= -0.05 && change.nicklesAmount > 0);
                    }
                    else if (total <= -0.01 && change.pennysAmount > 0)
                    {
                        do
                        {
                            total += 0.01;
                            change.pennysAmount--;
                            Console.WriteLine("Dispensing 0.01\n");
                        } while (total <= -0.01 && change.pennysAmount > 0);
                    }


                }//continue the do loop until zero is reached
                while (total < 0.0);
            }//End Looop

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Don't forget your receipt.");
            Console.WriteLine("Thank you for using D & C ChangeBot.");
            Console.ForegroundColor = ConsoleColor.White;

            //Line break
            Console.WriteLine("");
            Console.WriteLine("");

            //Displaying the till
            Console.WriteLine("Till holdings");
            Console.WriteLine("Hundreds: {0}", bills.hundredsAmount);
            Console.WriteLine("Fifties: {0}", bills.fiftysAmount);
            Console.WriteLine("Twenties: {0}", bills.twentysAmount);
            Console.WriteLine("Tens: {0}", bills.tensAmount);
            Console.WriteLine("Fives: {0}", bills.fivesAmount);
            Console.WriteLine("Ones: {0}", bills.onesAmount);
            Console.WriteLine("Quarters: {0}", change.quartersAmount);
            Console.WriteLine("Dimes: {0}", change.dimesAmount);
            Console.WriteLine("Nickles: {0}", change.nicklesAmount);
            Console.WriteLine("Pennies: {0}", change.pennysAmount);
          
        }//End cashEntry Function
        static void transLogging()
        {
            //Set variables
            Random rnd = new Random();
            var tNum = rnd.Next(100, 4000000);

            string tDate = DateTime.Now.ToString("MM/dd/yyyy");
            
            string tTime = DateTime.Now.ToString("hh:mm:ss:tt");

            //Create a string to be processed by the transaction log program
            string output = tNum.ToString() + " "  + tDate + " " + tTime + " $" + trans.cashAmount.ToString() + " " + trans.cardVendor.ToString() + " $" + trans.cardAmount.ToString() + " $" + trans.changeGiven.ToString();

            //Set the location and process to recieve information from the tranaction log
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = "C:\\Users\\jelly\\source\\repos\\ChangeBot Log\\ChangeBot Log\\bin\\Debug\\net6.0\\ChangeBot Log.exe ";

            startInfo.Arguments = output;

            Process.Start(startInfo);

        }//End transLogging function
    }   
}
