using MoreTec.TimeEditApi;
using System;
using System.Collections;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace MoreTec.TimeEditApp.Views
{
	class SearchView : View
	{
		private const string reulstsTitle = "Search Results";

		private readonly TextField searchField = new TextField("");
		private readonly Button searchButton = new Button("Search");
		private readonly FrameView resultsFrame = new FrameView(reulstsTitle);
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
			resultsFrame.X = 1;
			resultsFrame.Y = 3;
			resultsFrame.Width = Dim.Fill(2);
			resultsFrame.Height = Dim.Fill();

			resultsView.CanFocus = true;

			resultsFrame.Add(resultsView);
			this.Add(resultsFrame);
		}

		#endregion View Initialization

		private void Search()
		{
			Task.Run(() => PerformSearch(searchField.Text.ToString()));
		}

		private async Task PerformSearch(string query)
		{
			IImmutableList<SearchItem> searchResults = await TimeEditWrapper.Search(query, 1);
			IList searchList = searchResults.Select(x => $"{x.Name} ({x.Id})").ToList();

			Application.MainLoop.Invoke(() =>
			{
				resultsView.SetSource(searchList);
				resultsFrame.Title = reulstsTitle + " - " + query;
			});
		}
	}
}