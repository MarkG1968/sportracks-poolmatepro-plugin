﻿/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 18/09/2011
 * Time: 00:14
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.IO;
using NUnit.Framework;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro;
using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	[TestFixture]
	public class PoolMateProImporterTest 
	{
		[Test]
		public void CanLoadLatestLogFile()
		{
			PoolMateProImporter subjectUnderTest = new PoolMateProImporter();
			subjectUnderTest.OpenDirectory(TestData.TestDirectoryPath);
			LogFile latestLogFile = subjectUnderTest.LoadLatestLogFile();
			
			Assert.That(latestLogFile, Is.Not.Null);
		}

		[Test]
		public void ThrowsWithInvalidDirectory()
		{
			PoolMateProImporter subjectUnderTest = new PoolMateProImporter();
			subjectUnderTest.OpenDirectory("WONT_EXIST");
			
			Assert.Throws<DirectoryNotFoundException>(delegate { subjectUnderTest.LoadLatestLogFile(); });
		}
	}
}
