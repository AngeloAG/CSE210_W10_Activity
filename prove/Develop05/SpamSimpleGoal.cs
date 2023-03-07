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
Accomplish Goals that pertain to basic everyday tasks. Example: Do the dishes.

Attributes:
Name of Goal
Short description
AmountofScore

Behaviors:
Tracks and stores a simple goal of everyday life and then saves it with the points it is worth.

*/

public class SpamSimpleGoal: SpamParentGoal
{
  public SpamSimpleGoal(string _SpamName, string _SpamDescription, int _SpamScore ):base (_SpamName, _SpamDescription, _SpamScore)
  {

  }

  public override string SpamToString(){
    if ( base.SpamGetIsComplete() == true){
      return $"[X] {base._spamName} ({base._spamDescription})";
    } 
    
    else{
      return $"[] {base._spamName} ({base._spamDescription})";
    }
  }

}