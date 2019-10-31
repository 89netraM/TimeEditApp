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

		public MainWindow() : base(WindowTitle)
		{
			InitSearchView();
		}

		#region View Initialization

		private void InitSearchView()
		{
			searchView.X = 0;
			searchView.Y = 0;
			searchView.Width = Dim.Fill();
			searchView.Height = Dim.Fill();
			this.Add(searchView);
		}

		#endregion View Initialization
	}
}