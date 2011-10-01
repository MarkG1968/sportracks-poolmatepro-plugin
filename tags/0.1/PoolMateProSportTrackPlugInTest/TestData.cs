/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 24/09/2011
 * Time: 20:49
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.IO;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// Description of TestData.
	/// </summary>
	public class TestData
	{
		private const String TEST_DIRECTORY_PATH = @".\Data\";
		private const String TEST_FILE_PATH = TEST_DIRECTORY_PATH + "Log1.CSV1781149DONE";
		
		public static DirectoryInfo TestDirectory { get { return new DirectoryInfo(TestDirectoryPath); } }
		public static FileInfo TestPoolMateProFile { get { return new FileInfo(TEST_FILE_PATH); } }
		public static String TestDirectoryPath { get { return TEST_DIRECTORY_PATH; } }
	}
}
