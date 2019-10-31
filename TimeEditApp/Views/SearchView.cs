using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Terminal.Gui;

namespace MoreTec.TimeEditApp.Views
{
	class SearchView : View
	{
		private readonly TextField searchField = new TextField("");
		private readonly Button searchButton = new Button("Search");
		private readonly ListView resultsView = new ListView();

		public SearchView()
		{
			InitSearchField();
			InitSearchButton();
			InitResultsView();
		}

		#region View Initialization

		private void InitSearchField()
		{
			searchField.X = 1;
			searchField.Y = 1;
			searchField.Width = Dim.Fill(13);
			this.Add(searchField);
		}

		private void InitSearchButton()
		{
			searchButton.X = Pos.AnchorEnd(11);
			searchButton.Y = 1;
			searchButton.Width = 10;
			searchButton.Clicked = Search;
			this.Add(searchButton);
		}

		private void InitResultsView()
		{
			resultsView.X = 1;
			resultsView.Y = 3;
			resultsView.Width = Dim.Fill(2);
			resultsView.Height = Dim.Fill(7);
			this.Add(resultsView);
		}

		#endregion View Initialization

		private void Search()
		{

		}
	}
}