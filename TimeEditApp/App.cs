using MoreTec.TimeEditApp.Views;
using Terminal.Gui;

namespace MoreTec.TimeEditApp
{
	class App : Toplevel
	{
		private readonly Menu menu = new Menu();
		private readonly MainWindow mainWindow = new MainWindow();

		public App()
		{
			X = 0;
			Y = 0;
			Width = Dim.Fill();
			Height = Dim.Fill();

			InitMenu();
			InitMainWindow();
		}

		#region View Initialization

		private void InitMenu()
		{
			this.Add(menu);
			menu.Exit += Menu_Exit;
			menu.Search += Menu_Search;
			menu.Schedule += Menu_Schedule;
		}

		private void InitMainWindow()
		{
			mainWindow.X = 0;
			mainWindow.Y = 1;
			mainWindow.Width = Dim.Fill();
			mainWindow.Height = Dim.Fill(1);
			this.Add(mainWindow);
		}

		#endregion View Initialization

		private void Menu_Exit()
		{
			Running = false;
		}

		private void Menu_Search()
		{
			mainWindow.ShowSearchView();
		}

		private void Menu_Schedule()
		{
			mainWindow.ShowScheduleView();
		}
	}
}