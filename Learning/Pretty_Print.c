string customerName = "Mr. Jones";

string currentProduct = "Magic Yield";
int currentShares = 2975000;
decimal currentReturn = 0.1275m;
decimal currentProfit = 55000000.0m;

string newProduct = "Glorious Future";
decimal newReturn = 0.13125m;
decimal newProfit = 63000000.0m;

// Your logic here
Console.WriteLine($"Dear {customerName},");
Console.WriteLine($"As a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.");
Console.WriteLine("");
Console.WriteLine($"Currently, you own {currentShares:N2} shares at a return of {currentReturn:P2}");
Console.WriteLine("");
Console.WriteLine($"Our new product, {newProduct} offers a return of {newReturn:P2}. Given your current volume, your potential profit would be {newProfit:C}.");
Console.WriteLine("");
Console.WriteLine("Here's a quick comparison:\n");


string comparrisonMessage = "";
comparrisonMessage += currentProduct.PadRight(20);
comparrisonMessage += $"{currentReturn:P2}".PadRight(10);
comparrisonMessage += $"{currentProfit:C}".PadRight(20);
comparrisonMessage += "\n";
comparrisonMessage += newProduct.PadRight(20);
comparrisonMessage += $"{newReturn:P2}".PadRight(10);
comparrisonMessage += $"{newProfit:C}".PadRight(20);
// Your logic here

Console.WriteLine(comparrisonMessage);

const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

string quantity = "";
string output = "";

// Your work here
int openingPosition = input.IndexOf("<span>");
int closingPosition = input.IndexOf("</span>");
openingPosition += 6;
int length = closingPosition - openingPosition;
quantity = input.Substring(openingPosition,length);

int openingPosition1 = input.IndexOf("<div>");
int closingPosition1 = input.IndexOf("</div>");
openingPosition1 += 5;
int length2 = closingPosition1 - openingPosition1;
output = input.Substring(openingPosition1, length2);
output = output.Replace("&trade", "&reg");

Console.WriteLine(quantity);
Console.WriteLine(output);
