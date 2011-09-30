// Copyright (C) 2010 Zone Five Software
// Author: Aaron Averill
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
    public class DeviceConfigurationInfo
    {
    	private const String FILE_LOCATION_NAME = "filelocation";
    	private const String NEW_ONLY_NAME = "newonly";
    	private const String USER_NUMBER_NAME = "usernumber";
   	
    	private const long DEFAULT_USER_NUMBER = 1;

    	private const String IMPORT_ONLY_NEW_TRUE = "1";
    	private const String IMPORT_ONLY_NEW_FALSE = "0";
    	
    	public static DeviceConfigurationInfo Default
        {
        	get { return new DeviceConfigurationInfo(); }
        }

        public static DeviceConfigurationInfo Parse(string configurationInfo)
        {
            DeviceConfigurationInfo configInfo = new DeviceConfigurationInfo();
            if (configurationInfo != null)
            {
                string[] configurationParams = configurationInfo.Split(';');
                foreach (string configurationParam in configurationParams)
                {
                    string[] parts = configurationParam.Split('=');
                    if (parts.Length == 2)
                    {
                        switch (parts[0])
                        {
                            case NEW_ONLY_NAME:
                                configInfo.ImportOnlyNew = parts[1] == IMPORT_ONLY_NEW_TRUE;
                                break;
                            case USER_NUMBER_NAME:
                                long.TryParse(parts[1], out configInfo.UserNumber);
                                break;
                            case FILE_LOCATION_NAME:
                                configInfo.FileLocation = parts[1];
                                break;
                        }
                    }
                }
            }
            
            return configInfo;
        }

        private DeviceConfigurationInfo()
        {
        }

        public override string ToString()
        {
            return NEW_ONLY_NAME + "=" + (ImportOnlyNew ? IMPORT_ONLY_NEW_TRUE : IMPORT_ONLY_NEW_FALSE) +
                ";" + FILE_LOCATION_NAME + "=" + FileLocation.ToString() +
            	";" + USER_NUMBER_NAME + "=" + UserNumber.ToString();
        }

        public bool ImportOnlyNew = true;
        public String FileLocation = "C:\\PoolMatePro";
        public long UserNumber = 1;
    }
}
