using Terminal.Gui;

namespace MoreTec.TimeEditApp
{
	class App : Window
	{
		private const string WindowTitle = "TimeEditApp";

		public App() : base(WindowTitle)
		{
			X = 0;
			Y = 1;
			Width = Dim.Fill();
			Height = Dim.Fill();
		}
	}
}