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
          //Create new goal
          spamMenu.SPAMsubMenu();
          spamChoice = spamMenu.SPAMsubSelection();
          String spamGoalName = "";
          String spamGoalDesc = "";
          int spamGoalPoints = 0;
          int spamGoalBonus = 0;
          int spamGoalTimesTotal = 0;

          SpamPrintNoBreak("What is the name of the goal? ");
          spamGoalName = SpamRead();
          SpamPrint("");
          SpamPrintNoBreak("What is a short description of it? ");
          spamGoalDesc = SpamRead();
          SpamPrint("");
          SpamPrintNoBreak("What is the amount of points associated with this goal? ");
          spamGoalPoints = int.Parse(SpamRead());
          switch (spamChoice)
          {
            case "1":
              // Simple Goal
              SpamSimpleGoal spamSimpleGoal = new SpamSimpleGoal(spamGoalName, spamGoalDesc, spamGoalPoints);
              spamGoals.Add(spamSimpleGoal);
              break;
            case "2":
              // Eternal Goal
              SpamEternalGoal spamEternalGoal = new SpamEternalGoal(spamGoalName, spamGoalDesc, spamGoalPoints);
              spamGoals.Add(spamEternalGoal);
              break;
            case "3":
              // Checklist Goal
              SpamPrint("");
              SpamPrintNoBreak("How many times does this goal need to be accomplished for a bonus? ");
              spamGoalBonus = int.Parse(SpamRead());
              SpamPrint("");
              SpamPrintNoBreak("What is the bonus for accomplishing it that many times? ");
              spamGoalTimesTotal = int.Parse(SpamRead());

              SpamChecklistGoal spamChecklistGoal = new SpamChecklistGoal(spamGoalName, spamGoalDesc, spamGoalPoints, spamGoalTimesTotal, spamGoalBonus);
              spamGoals.Add(spamChecklistGoal);
              break;
          }
          break;
        case "2":
          // List goals
          SpamPrint("The goals are:");
          foreach (SpamParentGoal spamGoal in spamGoals)
          {
            SpamPrint(spamGoal.SpamToString());
          }
          break;
        case "3":
          // Save Goals
          break;
        case "4":
          // Load Goals
          break;
        case "5":
          // Record Event
          break;
        case "6":
          // Quit
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

  static void SpamPrintNoBreak(String text)
  {
    Console.Write(text);
  }

  static String SpamRead()
  {
    return Console.ReadLine();
  }
}