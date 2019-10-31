using MoreTec.TimeEditApi;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace MoreTec.TimeEditApp
{
	static class TimeEditWrapper
	{
		private static readonly TimeEdit instance = new TimeEdit("https://cloud.timeedit.net/chalmers/web/public/");

		public static Task<IImmutableList<ScheduleType>> GetScheduleTypes()
		{
			return instance.GetScheduleTypes();
		}

		public static Task<IImmutableList<SearchItem>> Search(string query, params int[] types)
		{
			return instance.Search(query, types);
		}

		public static Task<Schedule> GetSchedule(int scheduleId)
		{
			return instance.GetSchedule(scheduleId);
		}
	}
}