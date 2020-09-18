﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp
{
	class Examples
	{
		// I/O is a side effect
		// Create separate functions for all I/O work

		// example. OpenFile, UpdateFile
		// use pure function to perform computations on the file contents.

		private const string RobotFileName = "RobotNames.xml";
		public void DoWork()
		{
		
			var robots = GetRobots();
			int total = GetTotalWeight(robots);

			var redRobots = ImmutableList.Create(robots.Where(x => x.TeamName == "Red").ToArray());
			Console.WriteLine(GetTotalWeight(redRobots));

			//var blueRobots = ImmutableList.Create(robots.Where(x => x.TeamName == "Blue").ToArray());
			//int blueTeamTotal = GetTotalWeight(blueRobots);
		}

		public int GetTotalWeight(ImmutableList<Robot> robots)
		{
			int total = 0;
			foreach (Robot robot in robots)
			{
				total += robot.Weight;
			}
			return total;
		}
		public ImmutableList<Robot> GetRobots()
		{
			var xmlDoc = XDocument.Load(RobotFileName);
			var robots = xmlDoc.Root.Elements("Robot")
								.Select(x=> new Robot {RobotName= x.Element("RobotName").Value,
																				TeamName = x.Element("TeamName").Value,
																				Weight = (int)x.Element("Weight")
								}).ToArray();
			return ImmutableList.Create(robots);
		}

		public string SaveToFile()
		{
			return null;

		
		}

	}
}
