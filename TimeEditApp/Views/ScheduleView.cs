using MoreTec.TimeEditApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace MoreTec.TimeEditApp.Views
{
	class ScheduleView : View
	{
		private readonly TextField idField = new TextField("");
		private readonly Button fetchButton = new Button("Fetch");

		private readonly FrameView dateFrame = new FrameView("Date");
		private readonly ListView dateListView = new ListView();

		private readonly FrameView timeFrame = new FrameView("Time");
		private readonly ListView timeListView = new ListView();

		private readonly FrameView infoFrame = new FrameView("Info");
		private readonly ListView infoListView = new ListView();

		private Schedule? schedule;
		private int selectedDate = -1;

		public ScheduleView()
		{
			InitSearchField();
			InitSearchButton();

			InitDate();
			InitTime();
			InitInfo();
		}

		#region View Initialization

		private void InitSearchField()
		{
			idField.X = 1;
			idField.Y = 1;
			idField.Width = Dim.Fill(11);
			this.Add(idField);
		}

		private void InitSearchButton()
		{
			fetchButton.X = Pos.AnchorEnd(10);
			fetchButton.Y = 1;
			fetchButton.Width = 9;
			fetchButton.Clicked = Fetch;
			this.Add(fetchButton);
		}

		private void InitDate()
		{
			dateFrame.X = 0;
			dateFrame.Y = 3;
			dateFrame.Width = Dim.Percent(30);
			dateFrame.Height = Dim.Fill();

			dateListView.CanFocus = true;
			dateListView.AllowsMarking = true;

			dateFrame.Add(dateListView);
			this.Add(dateFrame);
		}

		private void InitTime()
		{
			timeFrame.X = Pos.Percent(30);
			timeFrame.Y = 3;
			timeFrame.Width = Dim.Percent(43);
			timeFrame.Height = Dim.Fill();

			timeListView.CanFocus = true;

			timeFrame.Add(timeListView);
			this.Add(timeFrame);
		}

		private void InitInfo()
		{
			infoFrame.X = Pos.Percent(60);
			infoFrame.Y = 3;
			infoFrame.Width = Dim.Fill();
			infoFrame.Height = Dim.Fill();

			infoListView.CanFocus = true;
			infoListView.AllowsMarking = true;

			infoFrame.Add(infoListView);
			this.Add(infoFrame);
		}

		#endregion View Initialization

		private void Fetch()
		{
			if (int.TryParse(idField.Text.ToString(), out int scheduleId))
			{
				DisplaySchedule(scheduleId);
			}
			else
			{
				ShowErrorBox("Schedule ID must be a number.");
			}
		}

		public void DisplaySchedule(int scheduleId)
		{
			Task.Run(() => DoFetch(scheduleId));
		}

		private async Task DoFetch(int scheduleId)
		{
			Schedule schedule = await TimeEditWrapper.GetSchedule(scheduleId);

			Application.MainLoop.Invoke(() =>
			{
				if (schedule.Entries.Count > 0)
				{
					this.schedule = schedule;

					IList<DateTime> dates = GetDates();
					SelectDate(dates);
				}
				else
				{
					this.schedule = null;
					ShowErrorBox("Could not find any schedule.");
				}
			});
		}

		private IList<DateTime> GetDates() => schedule?.Entries.Select(x => x.StartTime.Date).Distinct().ToList();
		private IList<ValueTuple<DateTime, DateTime>> GetTimes(DateTime date)
		{
			return schedule?.Entries.Where(x => x.StartTime.Date == date).Select(x => (x.StartTime, x.EndTime)).Distinct().ToList();
		}
		private ScheduleEntry? GetInfo(ValueTuple<DateTime, DateTime> startEndTime)
		{
			return schedule?.Entries.FirstOrDefault(x => x.StartTime == startEndTime.Item1 && x.EndTime == startEndTime.Item2);
		}

		private void SelectDate(IList<DateTime> dates)
		{
			dateListView.SetSource(dates.Select(x => x.ToShortDateString()).ToList());
			selectedDate = 0;

			IList<ValueTuple<DateTime, DateTime>> times = GetTimes(dates[selectedDate]);
			SelectTime(times);
		}
		private void SelectTime(IList<ValueTuple<DateTime, DateTime>> times)
		{
			timeListView.SetSource(times.Select(x => $"{x.Item1.ToShortTimeString()} - {x.Item2.ToShortTimeString()}").ToList());

			ScheduleEntry? scheduleEntry = GetInfo(times[0]);
			SelectInfo(scheduleEntry);
		}
		private void SelectInfo(ScheduleEntry? scheduleEntry)
		{
			infoListView.SetSource(scheduleEntry?.Columns.Select(x => x.Key + ": " + String.Join(", ", x.Value)).ToList());
		}

		private void ShowErrorBox(string message)
		{
			MessageBox.ErrorQuery(50, 7, "Error", message, "OK");
		}

		public override bool ProcessColdKey(KeyEvent keyEvent)
		{
			if (keyEvent.Key == Key.Enter && schedule != null)
			{
				IList<DateTime> dates = GetDates();
				if (dateListView.HasFocus && dateListView.SelectedItem >= 0 && dateListView.SelectedItem < dates.Count)
				{
					selectedDate = dateListView.SelectedItem;
					SelectTime(GetTimes(dates[selectedDate]));

					return true;
				}
				else
				{

					if (timeListView.HasFocus && selectedDate != -1)
					{
						IList<ValueTuple<DateTime, DateTime>> times = GetTimes(dates[selectedDate]);

						if (timeListView.SelectedItem >= 0 && timeListView.SelectedItem < times.Count)
						{
							SelectInfo(GetInfo(times[timeListView.SelectedItem]));

							return true;
						}
					}
				}
			}

			return base.ProcessColdKey(keyEvent);
		}
	}
}