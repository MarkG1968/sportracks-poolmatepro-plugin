/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 18/09/2011
 * Time: 00:38
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	[TestFixture]
	public class LogFileTest
	{
		[Test]
		public void CanGetAllEntries()
		{
			LogFile subjectUnderTest = new LogFile(TestData.TestPoolMateProFile);
			IList<LogEntry> allEntries = subjectUnderTest.GetAllEntries();
			
			Assert.That(allEntries.Count, Is.EqualTo(168));
		}
		
		[Test]
		public void IsValidFile()
		{
			LogFile subjectUnderTest = new LogFile(TestData.TestPoolMateProFile);
			
			Assert.That(subjectUnderTest.IsFile, Is.True);
		}

		[Test]
		public void IsInvalidFile()
		{
			LogFile subjectUnderTest = new LogFile(null);
			
			Assert.That(subjectUnderTest.IsFile, Is.False);
		}

	}
}
