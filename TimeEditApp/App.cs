using MoreTec.TimeEditApp.Views;
using Terminal.Gui;

namespace MoreTec.TimeEditApp
{
	class App : Window
	{
		private const string WindowTitle = "TimeEditApp";

		private readonly Menu menu = new Menu();

		public App() : base(WindowTitle)
		{
			X = 0;
			Y = 0;
			Width = Dim.Fill();
			Height = Dim.Fill();

			InitMenu();
		}

		private void InitMenu()
		{
			this.Add(menu);
			menu.Exit += Menu_Exit;
		}

		private void Menu_Exit()
		{
			Running = false;
		}
	}
}