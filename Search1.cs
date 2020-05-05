/*
 * Játszották-e a megadott számot (előadó vagy cím alapján) és ha igen, hány órakor és melyik rádión
 */
using System;
using System.Collections.Generic;

namespace Beadando
{
	public class Search1
	{
		TimeSpan ts;
		TimeSpan ts2;
		
		public Search1(List<Song>[] radioListArray)
		{
			Console.Clear();
			Console.WriteLine("Melyik számot keressük (kulcsszó előadó v. címmezőből)?");
			string keyword = Console.ReadLine();
			for (int i = 0; i < radioListArray.Length; i++) {
				List<Song> foundItems = radioListArray[i].FindAll(x => x.Title.Contains(keyword) || x.Band.Contains(keyword));
				Console.WriteLine("{0}. rádióállomás:", i + 1);
				foreach (Song song in foundItems) {
					int songIndex = radioListArray[i].FindIndex(x => x == song);
					int startTime = 0;
					for (int k = 0; k < songIndex; k++) {
						startTime += radioListArray[i][k].Length;
					}
					ts = TimeSpan.FromMilliseconds(song.Length * 1000);
					ts2 = TimeSpan.FromMilliseconds(startTime * 1000);
					Console.WriteLine("{0}:{1} - {2}, kezdési idő: {3}", song.Band, song.Title, ts.ToString(@"mm\:ss"), ts2.ToString(@"hh\:mm\:ss"));
				}
			}
			Console.WriteLine("Nyomj meg egy gombot a folytatáshoz!");
			Console.ReadKey();
			Console.Clear();
		}
		
	}
}
