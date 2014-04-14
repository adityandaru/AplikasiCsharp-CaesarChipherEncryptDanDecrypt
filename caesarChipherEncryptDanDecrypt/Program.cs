/*
 * Created by SharpDevelop.
 * User: Ndaru
 * Date: 11/05/2013
 * Time: 15:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace caesarChipherEncryptDanDecrypt
{
	class Program
	{
		public static void Main(string[] args)
		{
			string ulang = "Y" ; 
			do
			{
			//Console.Clear();
			Console.WriteLine("Hello Ndaru!");
			Console.WriteLine("contoh Caesar");
			
			caesarChipher cd = new caesarChipher();
			cd.SetAlfabet();
			cd.InputKunci();
			cd.SetKunciKanan();
			cd.Input();
			cd.ResumePinCin();
			cd.ResumePoutCout();
			
			Console.WriteLine();
			Console.Write("ulang program ?[Y|T] ");
			ulang = Convert.ToString(Console.ReadLine());
			ulang = ulang.ToUpper();
					
			} while (ulang=="Y") ;
			Console.ReadKey(true);
		}
	}
}