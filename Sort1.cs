/*
 * Rendezés - melyik a top 3 előadó, amitől/akitől a legtöbb számot játszották - állomásonként
 */
using System;
using System.Collections.Generic;

namespace Beadando
{
	public class Sort1
	{
		class BandOccurrenceObject
		{
			public string bandName;
			private int occurrence;
			
			public string BandName {
				get {
					return bandName;
				}			
			}
			public int Occurrence {
				get {
					return occurrence;
				}
			}
			
			public BandOccurrenceObject(string bandName, int occurrence)
			{
				this.bandName = bandName;
				this.occurrence = occurrence;
			}
		}
		
		public Sort1(List<Song>[] radioListArray)
		{
			for (int i = 0; i < radioListArray.Length; i++) {
				Console.WriteLine("{0}. rádióadó legtöbbet játszott előadói:", i + 1);
				List<BandOccurrenceObject> bandArray = new List<BandOccurrenceObject>();
				for (int j = 0; j < radioListArray[i].Count; j++) {
					int index = bandArray.FindIndex(x => x.BandName == radioListArray[i][j].Band);
					if (index < 0) {
						bandArray.Add(new BandOccurrenceObject(radioListArray[i][j].Band, 1));
					} else {
						bandArray[index] = new BandOccurrenceObject(bandArray[index].BandName, bandArray[index].Occurrence + 1);
					}
				}
				bandArray.Sort((x, y) => y.Occurrence.CompareTo(x.Occurrence));
				for (int k = 0; k < 3; k++) {
					Console.WriteLine("\t{0}. leggyakrabbi előadó: {1} - {2} db", k + 1, bandArray[k].BandName, bandArray[k].Occurrence);
				}
			}
			Console.WriteLine("Nyomj egy gombot a folytatáshoz!");
			Console.ReadKey();
			Console.Clear();
		}
	}
}
