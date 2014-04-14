/*
 * Created by SharpDevelop.
 * User: Ndaru
 * Date: 11/05/2013
 * Time: 16:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace caesarChipherEncryptDanDecrypt
{
	/// <summary>
	/// Description of caesarChipher.
	/// </summary>
	public class caesarChipher
	{
		private string [] alfabet;
		private int kunci=0;
		private string [] dataE;
		private string [] dataD;
		private string [] updateAlfaKanan = new string[26];
		private string plainORchip = "";
		private string pilih="";
		private string inp ="";
		
		
		public void SetAlfabet(){
			alfabet = new string[26] ;
			int n=0;
			for (char i='A'; i<='Z'; i++) {				
				alfabet[n]=i.ToString();
				n++;
			}
			
		}
		public void InputKunci(){
			bool erorr = true;
			
			while (erorr) {
				try {
					Console.Write("set Kunci = ");
					kunci = Convert.ToInt32(Console.ReadLine());
					if (kunci<26 && kunci >= 0) {
						erorr = false;
					}
					else{
						Console.WriteLine("minimal 0 dan maksimal 25 broo!!!!!!!");
					}
				} catch (Exception) {
					Console.WriteLine("harus angka bro\nminimal 0 dan maksimal 25!!!!!!!");
				}			
			}					
			
		}
		public void SetKunciKanan(){
			int n=0;
			for (int i=kunci; i<(26); i++) {				
				updateAlfaKanan[n] =alfabet[i];    
			//	Console.Write(updateAlfaKanan[n]+" , ");
				n++;
			}
			for (int i=0; i<kunci; i++) {
				updateAlfaKanan[n] = alfabet[i];
			//	Console.Write(updateAlfaKanan[n]+" , ");
				n++;
			}
		}
		public void Input(){
			bool error = true;
			while (error) {
				try {
					Console.Write("Encrypt or Decrypt [E|D] ? ");
					pilih = Convert.ToString(Console.ReadLine());
					pilih = pilih.ToUpper();
					if (pilih=="E") {
						Console.Write("set Plaintext = ");
						Input2();
						ProsesEncryptDeecrypt(pilih);
						error = false;
					}
					else if (pilih=="D") {
						Console.Write("set ChipherText = ");
						Input2();
						ProsesEncryptDeecrypt(pilih);
						error = false;
					}
					else{
						Console.WriteLine("tekan E or D bro!!!!!!");
					}
				} catch (Exception) {
					Console.WriteLine("harus E or D bro!!!!!!");
				}
			
			}
			
		}
		private void Input2(){
			string temp = Convert.ToString(Console.ReadLine());
			plainORchip = temp.Replace(" ",string.Empty);
			plainORchip = plainORchip.ToUpper();
			dataE = new string[plainORchip.Length] ;
			dataD = new string[plainORchip.Length] ;
		}
		private void ProsesEncryptDeecrypt(string a){
			bool error;
			for (int i=0; i<plainORchip.Length; i++) {
				string pecah = plainORchip.Substring(i,1);
				
				error = true;
				for (int j=0; j<26; j++) {
					if (a=="E") {
						if (alfabet[j].Equals(pecah)) {
						dataE[i]=updateAlfaKanan[j];						
						error = false;
						}
					}
					else if (a=="D") {
						if (updateAlfaKanan[j].Equals(pecah)) {
						dataD[i]=alfabet[j];						
						error = false;
						}
					}
					else{
						Console.WriteLine("salah pada bagian ProsesEncryptDeecrypt");
					}
				}
				if (error) {
					Console.WriteLine(pecah+ " => else ");
					Console.WriteLine("harus huruf bro !!!!!!!");
					Input();
					
					break;
				}
			}			
		}
		public void ResumePinCin(){
			
			Console.WriteLine();
			Console.Write("Pi => ");
			for (int i=0; i<26; i++) {
				Console.Write(alfabet[i]+" | ");
			}
			Console.WriteLine("\n");
			Console.Write("Ci => ");
			for (int i=0; i<26; i++) {
			
				Console.Write(updateAlfaKanan[i]+" | ");
			}
			
			Console.WriteLine();
		}
		
		public void ResumePoutCout(){
			
			for (int i=0; i<plainORchip.Length; i++) {
				string temp = plainORchip.Substring(i,1);
				inp += temp + " | ";
			}
			
			
			Console.WriteLine("______________________________________________________________\n");
			if (pilih == "E") {
				Console.WriteLine("PlainText   = "+inp);
				Console.Write("ChipherText = ");
				for (int i=0; i<plainORchip.Length; i++) {
					Console.Write(dataE[i]+" | ");
				}
				Console.WriteLine();				
			}
			else if (pilih == "D") {
				Console.Write("PlainText = ");
				for (int i=0; i<plainORchip.Length; i++) {
					Console.Write(dataD[i]+" | ");
				}
				Console.WriteLine();
				Console.WriteLine("ChipherText = "+inp);
			}
			else{
				Console.WriteLine("salah pada bagian ResumePoutCout() bro!!!");
			}
			Console.WriteLine();
		}
	}
}
