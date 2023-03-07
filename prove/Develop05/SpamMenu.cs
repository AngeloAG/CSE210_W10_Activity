/*
Authors: 
  Jeffrey Meldrum
  Jeremiah Powell
	Angelo Arellano Gaona
	Alvaro Nunez
	Logan Clark

Date: 3/7/23

Description:
Responsibilities: Return selected option

Attributes:
_Options
list of options

Behaviors:
Return user selected option
*/
using System;
public class SPAMMenu
{

  public SPAMMenu()
  {

  }

  public void SPAMmenuSelection()
  {
    Console.WriteLine("Menu Options:");
    Console.WriteLine("1).  Create New Goal");
    Console.WriteLine("2).  List Goals");
    Console.WriteLine("3).  Save Goals");
    Console.WriteLine("4).  Load Goals");
    Console.WriteLine("5).  Record Event");
    Console.WriteLine("6).  Quit");
  }


  public string SPAMselection()
  {
    Console.Write("Please select the numerical value of the choice you wish to proceed with: ");
    return Console.ReadLine();
  }
}