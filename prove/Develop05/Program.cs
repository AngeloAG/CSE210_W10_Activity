/*
Authors: 
  Jeffrey Meldrum
  Jeremiah Powell
	Angelo Arellano Gaona
	Alvaro Nunez
	Logan Clark

Date:

Description:
Responsibilities:


Attributes:


Behaviors:

*/

using System;

class Program
{
  static void Main(string[] args)
  {
    Console.Clear();
    int spamPoints = 0;
    List<SpamParentGoal> spamGoals = new List<SpamParentGoal>();
    SPAMMenu spamMenu = new SPAMMenu();
    bool spamKeepRunning = true;

    while (spamKeepRunning)
    {
      Console.Clear();
      SpamPrint("SPAM Goal Tracker");
      SpamPrint("");
      spamMenu.SPAMmenuSelection();
      String spamChoice = spamMenu.SPAMselection();
      switch (spamChoice)
      {
        case "1":
          break;
        case "2":
          break;
        case "3":
          break;
        case "4":
          break;
        case "5":
          break;
        case "6":
          spamKeepRunning = false;
          break;
        default:
          SpamPrint("Invalid input. Please select one of the options");
          break;
      }
    }
    Console.Clear();
    SpamPrint("Thanks for using this program");

  }

  static void SpamPrint(String text)
  {
    Console.WriteLine(text);
  }

  static String SpamRead()
  {
    return Console.ReadLine();
  }
}