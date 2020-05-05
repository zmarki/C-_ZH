/* Osztály a megadott fájl beolvasására
 * A konstruktorban megadjuk a fájl nevét, majd az osztály getRadioSongsArray metódusával kinyerhetjük a három rádióadó teljes napi játszási listáját egy tömbben (0. elem - 1. állomás; 1. elem - 2. állomás; 2. elem - 3. állomás adatai).
 * A getSongCount metódus visszaadja, hogy aznap hány számot játszottak összesen, adótól függetlenül
*/



using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Beadando
{
	public class FileProcesser
	{
		private int songCount;
		//Az aznapi összes lejátszott számot egy külön változóban tároljuk, hogy ez is lekérhető legyen
		
		private readonly List<Song> radio1List = new List<Song>();
		private readonly List<Song> radio2List = new List<Song>();
		private readonly List<Song> radio3List = new List<Song>();
		
		private List<Song>[] radioCollection = new List<Song>[3]; //Ez a tömb fogja tartalmazni az összes rádióadó által lejátszott számot, állomás sorszáma szerint indexelve
		
		public List<Song> this[int index]{
			get {
				return radioCollection[index];
			}
		}
		
		public FileProcesser(string fileName)
		{
			StreamReader sourceFile = new StreamReader(fileName);
			
			string line;
			int i = 0;
			
			while ((line = sourceFile.ReadLine()) != null) {
				i++;
				if (i == 1) {  //Az az eset, mikor a legelső sort olvassuk be.
					songCount = int.Parse(line);
					continue;
				}
				String[] rowData = line.Split(' '); //Szóközönként szétbontjuk a sorokat
				int j = 3;
				StringBuilder sb = new StringBuilder("", 50); //Ebbe a változóba újra összerakjuk a hossz utáni stringeket, hogy ':' segítségével szét tudjuk választani
				while (j != rowData.Length) { //az előadót és a szám címét
					sb.Append(rowData[j] + " ");
					j++;
				}
				string[] song = sb.ToString().Split(':');
			
				
				switch (int.Parse((rowData[0]))) {
					case 1:
						radio1List.Add(new Song(int.Parse(rowData[1]) * 60 + int.Parse(rowData[2]), song[0], song[1]));
						break;
					case 2:
						radio2List.Add(new Song(int.Parse(rowData[1]) * 60 + int.Parse(rowData[2]), song[0], song[1]));
						break;
					case 3:
						radio3List.Add(new Song(int.Parse(rowData[1]) * 60 + int.Parse(rowData[2]), song[0], song[1]));
						break;						
					default:
						break;
				}				
			}
			radioCollection[0] = radio1List;
			radioCollection[1] = radio2List;
			radioCollection[2] = radio3List;
		}
		
			
		public List<Song>[] getRadioSongsArray()
		{
			return radioCollection;
		}
		
		public int getSongCount()
		{
			return songCount;
		}
		
	}
}
