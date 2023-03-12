/*
Authors: 
  Jeffrey Meldrum
  Jeremiah Powell
	Angelo Arellano Gaona
	Alvaro Nunez
	Logan Clark

Date: 3/7/23

Description:
Responsibilities:


Attributes:


Behaviors:

*/
using System;
public class SpamChecklistGoal : SpamParentGoal
{
  private int _SPAMtimesTotal;
  private int _SPAMbonus;
  private int _SPAMtimesDone;
  public SpamChecklistGoal(string _SpamName, string _SpamDescription, int _SpamScore, int SPAMtimesTotal, int SPAMbonus) : base(_SpamName, _SpamDescription, _SpamScore)
  {
    _SPAMtimesTotal = SPAMtimesTotal;
    _SPAMbonus = SPAMbonus;
    _SPAMtimesDone = 0;
  }

  public override string SpamToString()
  {
    if (base.SpamGetIsComplete() == true)
    {
      return $"[X] {base._spamName} ({base._spamDescription} -- Currently Completed: {_SPAMtimesDone}/{_SPAMtimesTotal})";
    }

    else
    {
      return $"[] {base._spamName} ({base._spamDescription}  -- Currently Completed: {_SPAMtimesDone}/{_SPAMtimesTotal})";
    }
  }

  public override int SpamRecordEvent()
  {
    _SPAMtimesDone += 1;
    if (_SPAMtimesDone == _SPAMtimesTotal)
    {
      base._spamIsComplete = true;
      return _SPAMbonus;
    }
    else
    {
      return base._spamPoints;
    }
  }

  public override String SpamGetStringToSave()
  {
    return $"{base._spamName}|{base._spamDescription}|{base._spamPoints}|{base._spamIsComplete}|checklist|{_SPAMtimesTotal}|{_SPAMbonus}|{_SPAMtimesDone}";
  }
}