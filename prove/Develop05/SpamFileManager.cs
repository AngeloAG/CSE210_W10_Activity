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
    string SpamFilename = "GoalsAndPoints.txt";
    List<string> SpamLines = System.IO.File.ReadAllLines(SpamFilename);

    // reads the current information in the text document
    foreach (string SpamLine in SpamLines)
    {
      List<string> SpamParts = SpamLine.Split("|");
    }

    return SpamLines;
  }

  public void SpamFileSaver(List<string> SpamGoalList, int SpamPointsTotal)
  {
    string SpamFilename = "GoalsAndPoints.txt";

  // Loads what is currently stored into the txt document
    List<List<string>> SpameLoadFile = SpamFileLoader();

    using (StreamWriter SpamOutputFile = new StreamWriter(SpamFilename))
    {
      
    }
  }
}