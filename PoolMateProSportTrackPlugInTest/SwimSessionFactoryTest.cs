/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 18/09/2011
 * Time: 01:31
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Domain;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	[TestFixture]
	public class SwimSessionFactoryTest
	{
		[Test]
		public void CanCreateActivities()
		{
			LogFile logFile = new LogFile(TestData.TestPoolMateProFile);

			IList<LogEntry> allEntries = logFile.GetAllEntries();
			
			SwimSessionFactory subjectUnderTest = new SwimSessionFactory();
			
			IList<SwimSession> actualActivities = subjectUnderTest.CreateFrom(allEntries);
			
			Assert.That(actualActivities.Count, Is.EqualTo(22));
			
			SwimSession[] activities = new List<SwimSession>(actualActivities).ToArray();
			
			Assert.That(activities[1].SetCount, Is.EqualTo(7));
			Assert.That(activities[1].StartTime, Is.EqualTo(new DateTime(2011, 04, 11, 15, 3, 0)));
		}
	}
}
