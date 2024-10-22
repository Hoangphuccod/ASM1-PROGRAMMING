using System;

namespace SE07301ASM1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfCustomer = 3;
            string[] names = new string[sizeOfCustomer];
            double[] cost = new double[sizeOfCustomer];
            string[] customerType = new string[sizeOfCustomer];
            double[] lastMonthMeter = new double[sizeOfCustomer];
            double[] thisMonthMeter = new double[sizeOfCustomer];

            for (int k = 0; k < sizeOfCustomer; k++)
            {
                Console.Write("Enter customer name: ");
                names[k] = Console.ReadLine();

                Console.Write("Last month's water: ");
                while (!double.TryParse(Console.ReadLine(), out lastMonthMeter[k]) || lastMonthMeter[k] < 0)
                {
                    Console.Write("Invalid input. Please enter a valid number for last month's water: ");
                }

                Console.Write("This month's water: ");
                while (!double.TryParse(Console.ReadLine(), out thisMonthMeter[k]) || thisMonthMeter[k] < lastMonthMeter[k])
                {
                    Console.Write("Invalid input. This month's water must be greater than last month's. Try again: ");
                }

                double consumWater = thisMonthMeter[k] - lastMonthMeter[k];

                Console.Write("Enter customer type (household, administrative, production, business): ");
                customerType[k] = Console.ReadLine().ToLower();
                while (customerType[k] != "household" && customerType[k] != "administrative" && customerType[k] != "production" && customerType[k] != "business")
                {
                    Console.Write("Invalid input. Please enter one of the following types (household, administrative, production, business): ");
                    customerType[k] = Console.ReadLine().ToLower();
                }

                if (customerType[k] == "household")
                {
                    Console.Write("Enter number of people in household: ");
                    int numberPerson;
                    while (!int.TryParse(Console.ReadLine(), out numberPerson) || numberPerson <= 0)
                    {
                        Console.Write("Invalid input. Please enter a positive number: ");
                    }

                    double consumWaterPerPerson = consumWater / numberPerson;

                    if (consumWaterPerPerson < 10)
                    {
                        cost[k] = consumWaterPerPerson * (5973 + 597.3);
                    }
                    else if (consumWaterPerPerson < 20)
                    {
                        cost[k] = consumWaterPerPerson * (7052 + 705.2);
                    }
                    else if (consumWaterPerPerson < 30)
                    {
                        cost[k] = consumWaterPerPerson * (8699 + 869.9);
                    }
                    else
                    {
                        cost[k] = consumWaterPerPerson * (15929 + 1592.9);
                    }
                }
                else if (customerType[k] == "administrative")
                {
                    cost[k] = consumWater * (9955 + 995.5);
                }
                else if (customerType[k] == "production")
                {
                    cost[k] = consumWater * (11615 + 1161.5);
                }
                else if (customerType[k] == "business")
                {
                    cost[k] = consumWater * (22068 + 2206.8);
                }

                Console.WriteLine("\nCustomer Information for " + names[k] + ":");
                Console.WriteLine("Last month's water: " + lastMonthMeter[k]);
                Console.WriteLine("This month's water: " + thisMonthMeter[k]);
                Console.WriteLine("Amount of consumption: " + consumWater);
                Console.WriteLine("Total Bill: $" + cost[k].ToString("F2"));
                Console.WriteLine();


                Console.WriteLine("Do you want to find a customer? (yes/no)");
                string conf = Console.ReadLine();
                if (conf.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("====================Finding=============================");
                    Console.WriteLine("Find by customer name:");
                    string keyword = Console.ReadLine();

                    bool found = false;
                    for (int i = 0; i < sizeOfCustomer; i++)
                    {
                        if (names[i].Equals(keyword, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Customer Name: " + names[i]);
                            Console.WriteLine("Last Month Index: " + lastMonthMeter[i]);
                            Console.WriteLine("This Month Index: " + thisMonthMeter[i]);
                            Console.WriteLine("Total Bill: $" + cost[i].ToString("F2"));
                            found = true;
                            break; 
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Customer not found.");
                    }
                }

                Console.WriteLine("Do you want to sort customers? (yes/no)");
                string conf2 = Console.ReadLine();
                if (conf2.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("===================Sorting=============================");
                    for (int i = 0; i < sizeOfCustomer - 1; i++)
                    {
                        for (int j = i + 1; j < sizeOfCustomer; j++)
                        {
                            if (cost[i] < cost[j])
                            {

                                string namesTemp = names[i];
                                names[i] = names[j];
                                names[j] = namesTemp;


                                double costTemp = cost[i];
                                cost[i] = cost[j];
                                cost[j] = costTemp;


                                string customerTypeTemp = customerType[i];
                                customerType[i] = customerType[j];
                                customerType[j] = customerTypeTemp;


                                double lastIndex = lastMonthMeter[i];
                                lastMonthMeter[i] = lastMonthMeter[j];
                                lastMonthMeter[j] = lastIndex;


                                double thisIndex = thisMonthMeter[i];
                                thisMonthMeter[i] = thisMonthMeter[j];
                                thisMonthMeter[j] = thisIndex;
                            }
                        }
                    }

                    Console.WriteLine("Customers sorted by total bill (highest to lowest):");
                    for (int i = 0; i < sizeOfCustomer; i++)
                    {
                        Console.WriteLine($"Customer Name: {names[i]}, Total Bill: ${cost[i].ToString("F2")}");
                    }
                }

            }

            Console.Read();
        }
    }
}
