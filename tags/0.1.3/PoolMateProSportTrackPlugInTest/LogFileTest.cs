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
using System.Globalization;
using NUnit.Framework;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Utilities;

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
		
		[Test, Combinatorial]
		public void CanGetAllEntriesUnderNonEnglishLocale([Values("de-DE", "fr-CA", "nl")]String ietfLanguageTag)
		{
			LogFile subjectUnderTest = new LogFile(TestData.TestPoolMateProFile);
			IList<LogEntry> allEntries = new List<LogEntry>();
				
			using(new ScopedLocaleSwitcher(CultureInfo.GetCultureInfoByIetfLanguageTag(ietfLanguageTag)))
			{
				allEntries = subjectUnderTest.GetAllEntries();
			}
			
			Assert.That(allEntries.Count, Is.EqualTo(168));
		}		
	}
}
