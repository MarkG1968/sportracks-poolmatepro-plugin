/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 17/09/2011
 * Time: 23:52
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

using FileHelpers;

using MarkGravestock.SportTracks.PlugIns.PoolMatePro.Utilities;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro.File
{
	/// <summary>
	/// Description of LogFile.
	/// </summary>
	public class LogFile
	{
		private FileInfo logFileInfo;
		
		public LogFile(FileInfo logFileFileInfo)
		{
			this.logFileInfo = logFileFileInfo;
		}

		public IList<LogEntry> GetAllEntries()
		{
			FileHelperEngine<LogEntry> engine = new FileHelperEngine<LogEntry>();
			engine.Options.IgnoreFirstLines = 1;
			engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;

			using(new ScopedLocaleSwitcher(CultureInfo.GetCultureInfoByIetfLanguageTag("en-GB")))
			{
				return engine.ReadFile(logFileInfo.FullName);
			}
		}
		
		public bool IsFile
		{
			get
			{
				return logFileInfo != null;
			}
		}
	}
}
