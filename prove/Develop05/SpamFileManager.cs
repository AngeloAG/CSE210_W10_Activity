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
save and load goals to a txt document

Attributes:


Behaviors:

*/
using System;
using System.IO;

public class SpamFileManager
{
  public SpamFileManager()
  {

  }

  public List<List<string>> SpamFileLoader()
  {
    List<List<string>> SpamLines = new List<List<string>>();
    string SpamFilename = "GoalsAndPoints.txt";
    string[] SpamLinesArray = System.IO.File.ReadAllLines(SpamFilename);

    // converts array into a list
    foreach (string SpamLineArray in SpamLinesArray)
    {
      List<string> SpamParts = new List<string>();
      string[] SpamPartsArray = SpamLineArray.Split("|");

      // splits the line into seperate parts then saves it into a list
      foreach (string SpamPartArray in SpamPartsArray)
      {
        SpamParts.Add(SpamPartArray);
      }
      
      // adds the part list to the lines list
      SpamLines.Add(SpamParts);
    }
    return SpamLines;
  }

  public void SpamFileSaver(List<string> SpamGoalList, int SpamPointsTotal)
  {
    // reads the text document and converts it into a list
    string SpamFilename = "GoalsAndPoints.txt";
    string[] SpamLinesArray = System.IO.File.ReadAllLines(SpamFilename);
    List<string> SpamLines = new List<string>();
    foreach (string SpamLineArray in SpamLinesArray)
    {
      SpamLines.Add(SpamLineArray);
    }

    // Loads what is currently stored into the txt document
    string SpamPointsTotalString = SpamPointsTotal.ToString();

    // updates the point total
    SpamLines[0] = SpamPointsTotalString;

    // adds on to the previously made goals
    foreach (string SpamGoal in SpamGoalList)
    {
      SpamLines.Add(SpamGoal);
    }

// clears the text document
    TextWriter SpamClear = new StreamWriter(SpamFilename, false);
    SpamClear.Write(string.Empty);
    SpamClear.Close();

// writes the goals on the txt document
    using (StreamWriter SpamOutputFile = new StreamWriter(SpamFilename))
    {
      foreach (string SpamLine in SpamLines)
      {
        SpamOutputFile.WriteLine($"{SpamLine}");
      }
    }
  }
}