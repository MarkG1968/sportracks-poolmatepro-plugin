/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 28/09/2011
 * Time: 19:38
 * 
 * User: © Mark Gravestock 
*/
using System;
using System.IO;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// Description of DirectoryValidationEvent.
	/// </summary>
	public class DirectoryValidationEvent
	{
		private DirectoryInfo directoryToValidate;
		private ValidationStatus validationStatus;
		
		public DirectoryValidationEvent(DirectoryInfo directory)
		{
			this.directoryToValidate = directory;
			this.ValidationStatus = ValidationStatus.NotValidated;
		}
		
		public ValidationStatus ValidationStatus
		{
			get { return validationStatus; }
			set { validationStatus = value; }
		}
		
		public DirectoryInfo DirectoryToValidate
		{
			get { return directoryToValidate; }
		}
	}
}
