/* Osztály a zeneszámok adatainak tárolására
 * hossz
 * előadó
 * cím
 */


using System;

namespace Beadando
{

	public class Song
	{
		private int length;
		private string band;
		private string title;
		
		public int Length{
			get{
				return this.length;
			}
			set {
				length=value;
			}
		}
		
		public string Band{
			get{
				return this.band;
			}
			set {
				band=value;
			}
		}
		
		
		public string Title{
			get{
				return this.title;
			}
			set {
				title=value;
			}
		}
		
		
		
		public Song(int length, string band, string title)
		{
			this.length=length;
			this.band=band;
			this.title=title;
		}
	}
}
