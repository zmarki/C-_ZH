/*
 * Szűrés - Két választott időpont között milyen számokat kezdtek el játszani
 */
using System;
using System.Collections.Generic;

namespace Beadando
{
	public class Filter1
	{
		TimeSpan ts;
		TimeSpan ts2;
		
		public Filter1(List<Song>[] radioListArray)
		{
			int startTime = 0;
			int endTime = 0;
			
			Console.Clear();
			
			bool error = false;
			do {
				try {
					Console.Write("Kezdés - óra: ");
					startTime = int.Parse(Console.ReadLine()) * 3600;
					Console.Write("Kezdés - perc: ");
					startTime += int.Parse(Console.ReadLine()) * 60;
					Console.Write("Kezdés - másodperc: ");
					startTime += int.Parse(Console.ReadLine());
					if (startTime < 0) {
						throw new FormatException();
					}
			
					Console.Write("Vége - óra: ");
					endTime = int.Parse(Console.ReadLine()) * 3600;
					Console.Write("Vége - perc: ");
					endTime += int.Parse(Console.ReadLine()) * 60;
					Console.Write("Vége - másodperc: ");
					endTime += int.Parse(Console.ReadLine());
					error = false;
					if (endTime < 0) {
						throw new FormatException();
					}
				} catch (FormatException) {
					error = true;
					Console.WriteLine("Helytelen beírás!");
				}
			} while (error);
			
			Console.WriteLine(startTime);
			Console.WriteLine(endTime);
			
			for (int i = 0; i < radioListArray.Length; i++) {
				Console.WriteLine("{0}. állomáson:", i + 1);
				int actualTime = 0;
				int index = 0;
				while (actualTime < startTime && index < radioListArray[i].Count) {
					actualTime += radioListArray[i][index].Length;
					index++;
				}
				for (int k = index; k < radioListArray[i].Count; k++) {
					int songIndex = radioListArray[i].FindIndex(x => x == radioListArray[i][k]);
                    
					int songStartTime = 0;
					for (int l = 0; l < songIndex; l++) {
						songStartTime += radioListArray[i][l].Length;
					}
					ts = TimeSpan.FromMilliseconds(radioListArray[i][k].Length * 1000);
					ts2 = TimeSpan.FromMilliseconds(songStartTime * 1000);
					Console.WriteLine("{0}:{1} - {2}, kezdési idő: {3}", radioListArray[i][k].Band, radioListArray[i][k].Title, ts.ToString(@"mm\:ss"), ts2.ToString(@"hh\:mm\:ss"));
					actualTime += radioListArray[i][k].Length;
					if (actualTime > endTime) {
						break;
					}
				}			
			}
			Console.WriteLine("Nyomj egy gombot a folytatáshoz!");
			Console.ReadKey();
			Console.Clear();
		}
	}
}
