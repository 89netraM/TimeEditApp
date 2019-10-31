using MoreTec.TimeEditApp.Views;
using Terminal.Gui;

namespace MoreTec.TimeEditApp
{
	class App : Window
	{
		private const string WindowTitle = "TimeEditApp";

		private readonly Menu menu = new Menu();
		private readonly SearchView searchView = new SearchView();

		public App() : base(WindowTitle)
		{
			X = 0;
			Y = 0;
			Width = Dim.Fill();
			Height = Dim.Fill();

			InitMenu();
			InitSearchView();
		}

		#region View Initialization

		private void InitMenu()
		{
			this.Add(menu);
			menu.Exit += Menu_Exit;
		}

		private void InitSearchView()
		{
			searchView.X = 0;
			searchView.Y = 1;
			searchView.Width = Dim.Fill();
			searchView.Height = Dim.Fill(1);
			this.Add(searchView);
		}

		#endregion View Initialization

		private void Menu_Exit()
		{
			Running = false;
		}
	}
}