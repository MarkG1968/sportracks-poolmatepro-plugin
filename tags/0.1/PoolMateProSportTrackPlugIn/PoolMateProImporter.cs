/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 17/09/2011
 * Time: 23:51
 * 
*/
using System;
using System.IO;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.File;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// Description of PoolMateProImporter.
	/// </summary>
	public class PoolMateProImporter
	{
		private DirectoryInfo logFileDirectoryInfo;
		public PoolMateProImporter()
		{
		}
		
		public void OpenDirectory(String logFileDirectory)
		{
			logFileDirectoryInfo = new DirectoryInfo(logFileDirectory);
		}
		
		public LogFile LoadLatestLogFile()
		{
			String searchPattern = @"Log*.csv*";
			
			FileInfo[] files = logFileDirectoryInfo.GetFiles(searchPattern, SearchOption.TopDirectoryOnly);

			FileInfo latestMatchingFile = null;
			
			foreach (FileInfo file in files)
        	{
				DateTime creationTime = file.CreationTimeUtc;
				
				if (latestMatchingFile == null || latestMatchingFile.CreationTimeUtc < creationTime)
				{
					latestMatchingFile = file;
				}
        	}
			
			return new LogFile(latestMatchingFile);
		}
	}
}
