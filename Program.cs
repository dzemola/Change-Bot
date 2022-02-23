//Variables and path
string month = DateTime.Now.ToString("MM");
string day = DateTime.Now.ToString("dd");
string year = DateTime.Now.ToString("yyyy");
string file = @"C:\Users\jelly\OneDrive\Desktop\transactions-" + month + "-" + day + "-" + year + ".txt";

//Create a file
StreamWriter fileCheck;
fileCheck = File.AppendText(file);
fileCheck.Close();

//Appending the file
string data = File.ReadAllText(file);
StreamWriter Transactions;
Transactions = File.AppendText(file); 

//Writing to the .txt file
if(data == "")
{
    Transactions.Write("Transaction  | Transaction   |  Transaction   | Cash |        Card         |   Card  |  Cash\n");
    Transactions.Write("  Number     |    Date       |     Time       | Paid |       Vendor        |   Paid  |  Back \n\n");           
}

//Writing the info sent from the mother file to the .txt file
for(int i = 0; i < args.Length; i++)
{
    Transactions.Write(args[i] + "  \t");
}

Transactions.WriteLine();
Transactions.Close();

//Confirming the file is written or appending the file
if (File.Exists(file))
{
    File.AppendText(file);
    Console.WriteLine("Appended to File: " + file);
}
else
{
    //insert statement that attempts to write a text file and confirm success, advise of failure
    try
    {
        File.WriteAllText(file, Transactions.ToString());
        Console.WriteLine("File written: " + file);
    }
    catch (Exception error)
    {
        Console.WriteLine(error.Message);
    }
}




