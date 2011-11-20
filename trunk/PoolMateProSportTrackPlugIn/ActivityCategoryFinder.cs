/*
 * Created by SharpDevelop.
 * User: Mark Gravestock
 * Date: 15/10/2011
 * Time: 21:16
 * 
 * User: © Mark Gravestock 
*/
using System;

using System.Collections.Generic;

using ZoneFiveSoftware.Common.Data.Fitness;

namespace MarkGravestock.SportTracks.PlugIns.PoolMatePro
{
	/// <summary>
	/// Description of ActivityCategoryFinder.
	/// </summary>
	public class ActivityCategoryFinder
	{
		private IEnumerable<IActivityCategory> activityCategories;
		
		public ActivityCategoryFinder(IEnumerable<IActivityCategory> activityCategories)
		{
			this.activityCategories = activityCategories;	
		}
		
		public IActivityCategory Find(String activityCategoryName)
		{
			IActivityCategory foundActivityCategory = null;
			FindIn(this.activityCategories, activityCategoryName, ref foundActivityCategory);
			return foundActivityCategory;
		}
		
		private void FindIn(IEnumerable<IActivityCategory> activityCategories, String activityCategoryName, ref IActivityCategory foundActivityCategory)
		{
			foreach (IActivityCategory activityCategory in activityCategories)
			{
				if (foundActivityCategory != null)
				{
					break;
				}
				
				if (activityCategory.Name.Equals(activityCategoryName, StringComparison.InvariantCultureIgnoreCase))
				{
					foundActivityCategory = activityCategory;
					break;
				}
				
				IActivityCategoryList activitySubCategories = activityCategory.SubCategories;
				
				if (activitySubCategories != null)
				{
					FindIn(activitySubCategories, activityCategoryName, ref foundActivityCategory);
				}
			}
			
		}	
	}
}
