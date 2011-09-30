/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 17/09/2011
 * Time: 21:35
 * 
 */
using System;
using System.Xml;
using System.Collections.Generic;
using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// This is the main entry point of the Pool Mate Pro Plug In For SportTracks application.
	/// </summary>
	public class PlugIn : IPlugin
	{
		private IApplication application;
		
        private static PlugIn instance = null;

        public PlugIn()
        {
        	instance = this;
        }
        
        public static PlugIn Instance
        {
            get { return instance; }
        }
		
		public Guid Id
		{
			get { return new Guid("729304BB-539F-4FC1-9008-8DBE4BFB86E9"); } 
		}

		public string Name
		{
			get { return "Pool-Mate Pro Plugin"; } 
		}
		
		public string Version
		{
			get { return GetType().Assembly.GetName().Version.ToString(3); } 
		}
		
		public IApplication Application
        {
            get { return application; }
            set { application = value; }
        }
		
		public void ReadOptions(XmlDocument xmlDoc, XmlNamespaceManager nsmgr, XmlElement pluginNode)
        {
        }

        public void WriteOptions(XmlDocument xmlDoc, XmlElement pluginNode)
        {
        }

	}
}