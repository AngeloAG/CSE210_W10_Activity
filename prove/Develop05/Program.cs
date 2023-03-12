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
    List<String> spamLevels = new List<String>() { "Recruit", "Ninja", "Knight", "Samurai" };
    string spamCurrentLevel = spamLevels[0];
    int spamCurrentPoints = 0;
    List<SpamParentGoal> spamGoals = new List<SpamParentGoal>();
    SPAMMenu spamMenu = new SPAMMenu();
    SpamFileManager spamFileManager = new SpamFileManager();
    bool spamKeepRunning = true;

    while (spamKeepRunning)
    {
      if (spamCurrentPoints > 800)
      {
        spamCurrentLevel = spamLevels[3];
      }
      else if (spamCurrentPoints > 500)
      {
        spamCurrentLevel = spamLevels[2];
      }
      else if (spamCurrentPoints > 300)
      {
        spamCurrentLevel = spamLevels[1];
      }
      Console.Clear();
      SpamPrint("SPAM Goal Tracker");
      SpamPrint("");
      SpamPrint($"You have {spamCurrentPoints} points");
      SpamPrint("");
      SpamPrint($"You are a {spamCurrentLevel}");
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
              spamGoalTimesTotal = int.Parse(SpamRead());
              SpamPrint("");
              SpamPrintNoBreak("What is the bonus for accomplishing it that many times? ");
              spamGoalBonus = int.Parse(SpamRead());

              SpamChecklistGoal spamChecklistGoal = new SpamChecklistGoal(spamGoalName, spamGoalDesc, spamGoalPoints, spamGoalTimesTotal, spamGoalBonus);
              spamGoals.Add(spamChecklistGoal);
              break;
          }
          break;
        case "2":
          // List goals
          SpamPrint("The goals are:");
          int spamCounter = 1;
          foreach (SpamParentGoal spamGoal in spamGoals)
          {
            SpamPrint($"{spamCounter}. {spamGoal.SpamToString()}");
            spamCounter++;
          }
          SpamPrint("Press Enter to continue");
          SpamRead();
          break;
        case "3":
          // Save Goals
          SpamPrint("Saving Goals...");
          List<String> spamGoalsAsStrings = new List<String>();

          foreach (SpamParentGoal goal in spamGoals)
          {
            spamGoalsAsStrings.Add(goal.SpamGetStringToSave());
          }

          spamFileManager.SpamFileSaver(spamGoalsAsStrings, spamCurrentPoints);

          SpamPrint("File Saved!");
          SpamPrint("Press Enter to continue");
          SpamRead();
          break;
        case "4":
          // Load Goals
          SpamPrint("Loading Goals...");
          List<List<string>> spamLoadedGoalsStrings = spamFileManager.SpamFileLoader();

          spamGoals.Clear();

          spamCurrentPoints = int.Parse(spamLoadedGoalsStrings[0][0]);
          spamLoadedGoalsStrings.RemoveAt(0);

          foreach (List<String> record in spamLoadedGoalsStrings)
          {
            switch (record[4])
            {
              case "simple":
                SpamSimpleGoal loadedSimpleGoal = new SpamSimpleGoal(record[0], record[1], int.Parse(record[2]));
                if (record[3] == "True")
                {
                  loadedSimpleGoal.SpamRecordEvent();
                }
                spamGoals.Add(loadedSimpleGoal);
                break;
              case "checklist":
                SpamChecklistGoal loadedChecklistGoal = new SpamChecklistGoal(record[0], record[1], int.Parse(record[2]), int.Parse(record[5]), int.Parse(record[6]));

                for (int i = 0; i < int.Parse(record[6]); i++)
                {
                  loadedChecklistGoal.SpamRecordEvent();
                }

                spamGoals.Add(loadedChecklistGoal);
                break;
              case "eternal":
                SpamEternalGoal loadedEternalGoal = new SpamEternalGoal(record[0], record[1], int.Parse(record[2]));
                if (record[3] == "True")
                {
                  loadedEternalGoal.SpamRecordEvent();
                }
                spamGoals.Add(loadedEternalGoal);
                break;
            }
          }
          SpamPrint("File loaded");
          SpamPrint("Press Enter to continue");
          SpamRead();
          break;
        case "5":
          // Record Event
          SpamPrint("The goals are:");
          int spamCounter2 = 1;
          foreach (SpamParentGoal spamGoal in spamGoals)
          {
            SpamPrint($"{spamCounter2}. {spamGoal.SpamToString()}");
            spamCounter2++;
          }
          SpamPrintNoBreak("Which goal did you accomplish? ");
          int spamCompltGoal = int.Parse(SpamRead());
          int spamEarnedPoints = 0;
          if (spamGoals[spamCompltGoal - 1].SpamGetIsComplete())
          {
            SpamPrint("The goal is already complete.");
          }
          else
          {
            spamEarnedPoints = spamGoals[spamCompltGoal - 1].SpamRecordEvent();
          }

          SpamPrint("");
          SpamPrint($"Congratulations! You have earned {spamEarnedPoints} points!");
          spamCurrentPoints += spamEarnedPoints;
          SpamPrint($"You now have {spamCurrentPoints} points");
          SpamPrint("Press enter to continue");
          SpamRead();
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