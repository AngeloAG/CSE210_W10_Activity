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
Keeps track of the goals and the information. 

Attributes:
_Name
_Description
_Points
_IsComplete

Behaviors:
ToString
RecordEvent(virtual)
*/

public abstract class SpamParentGoal
{
  protected String _spamName;
  protected String _spamDescription;
  protected int _spamPoints;
  protected bool _spamIsComplete;

  public SpamParentGoal(String spamName, String spamDescription, int spamPoints)
  {
    _spamName = spamName;
    _spamDescription = spamDescription;
    _spamPoints = spamPoints;
    _spamIsComplete = false;
  }

  public abstract String SpamToString();

  public virtual int SpamRecordEvent()
  {
    /*Returns the amount of points for completing the goal*/
    _spamIsComplete = true;
    return _spamPoints;
  }

  public bool SpamGetIsComplete()
  {
    return _spamIsComplete;
  }
}