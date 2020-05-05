/* A program belépési pontja.
 * Mivel statikus osztály, egyetlen dolog, ami történik itt, hogy elindítja a példányosított "Program" osztályt, ami majd kezelni fogja a felhasználó inputjait
*/


using System;
using System.Collections.Generic;

namespace Beadando
{
	class ProgramEntry
	{
		public static void Main(string[] args)
		{
				new Program();			
		}
	}
}