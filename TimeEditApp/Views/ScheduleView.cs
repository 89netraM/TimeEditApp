using MoreTec.TimeEditApi;
using System;
using System.Collections;
using System.Collections.Generic;
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
		private readonly IList dateList;

		private readonly FrameView timeFrame = new FrameView("Time");
		private readonly ListView timeListView = new ListView();
		private readonly IList timeList;

		private readonly FrameView infoFrame = new FrameView("Info");
		private readonly ListView infoListView = new ListView();
		private readonly IList infoList;

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

		}
	}
}