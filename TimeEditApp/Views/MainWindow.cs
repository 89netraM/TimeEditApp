using MoreTec.TimeEditApi;
using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace MoreTec.TimeEditApp.Views
{
	class MainWindow : Window
	{
		private const string WindowTitle = "TimeEditApp";

		private readonly SearchView searchView = new SearchView();
		private readonly ScheduleView scheduleView = new ScheduleView();

		public MainWindow() : base(WindowTitle)
		{
			InitSearchView();
			InitScheduleView();
		}

		#region View Initialization

		private void InitSearchView()
		{
			searchView.X = 0;
			searchView.Y = 0;
			searchView.Width = Dim.Fill();
			searchView.Height = Dim.Fill();
			searchView.ItemSelected += SearchView_ItemSelected;
			this.Add(searchView);
		}

		private void InitScheduleView()
		{
			scheduleView.X = 0;
			scheduleView.Y = 0;
			scheduleView.Width = Dim.Fill();
			scheduleView.Height = Dim.Fill();
		}

		#endregion View Initialization

		public void ShowSearchView()
		{
			this.RemoveAll();
			this.Add(searchView);
		}

		public void ShowScheduleView()
		{
			this.RemoveAll();
			this.Add(scheduleView);
		}

		private void SearchView_ItemSelected(SearchItem item)
		{
			ShowScheduleView();
			scheduleView.DisplaySchedule(item.Id);
		}
	}
}