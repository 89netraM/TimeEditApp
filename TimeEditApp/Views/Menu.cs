using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace MoreTec.TimeEditApp.Views
{
	class Menu : MenuBar
	{
		public event Action Exit;
		public event Action Search;
		public event Action Schedule;

		public Menu() : base(null)
		{
			Menus = new MenuBarItem[]
			{
				new MenuBarItem("_File", new MenuItem[]
				{
					new MenuItem("_Exit", null, () => Exit?.Invoke())
				}),
				new MenuBarItem("_View", new MenuItem[]
				{
					new MenuItem("_Search", "Search for schedules", () => Search?.Invoke()),
					new MenuItem("_Schedule", "Display a schedule", () => Schedule?.Invoke()),
				})
			};
		}
	}
}
