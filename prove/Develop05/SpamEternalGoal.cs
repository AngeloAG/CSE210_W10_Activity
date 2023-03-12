/*
Authors: 
  Jeffrey Meldrum
  Jeremiah Powell
	Angelo Arellano Gaona
	Alvaro Nunez
	Logan Clark

Date: 3/7/2023

Description:
Responsibilities: Create a Goal that pertains the Religious Goals such as temple attendence, reading scriputres, etc.

Attributes:
Name of Goal
short description
Amount of pints
Times to be accomplished
Amount of points bonus

Behaviors: Track and save religious goals and their respective points associtated with each Goal.

*/

public class SpamEternalGoal : SpamParentGoal
{


  public SpamEternalGoal(string _spamName, string _spamDescription, int _spamPoints) : base(_spamName, _spamDescription, _spamPoints)
  {

  }

  public override string SpamToString()
  {
    if (base.SpamGetIsComplete() == true)
    {
      return string.Format("[x] {0} ({1})", base._spamName, base._spamDescription);
    }
    else
    {
      return string.Format("[ ] {0} ({1})", base._spamName, base._spamDescription);
    }
  }

  public override string SpamGetStringToSave()
  {
    return $"{_spamName}|{_spamDescription}|{_spamPoints}|{_spamIsComplete}|eternal";
  }
}