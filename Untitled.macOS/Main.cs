#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;

using AppKit;
using Foundation;

using Hydra;
#endregion

namespace Untitled.macOS
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			NSApplication.Init();

			using (var game = new Game1())
			{
				game.Run();
			}
		}
	}
}
