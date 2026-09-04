//> path: ~/KSA/linux64
//> path: ~/KSA/StarMap
//> -target:library
//> -nostdlib+
//> import: StarMap.API
//> import: KSA
//> import: System.Private.CoreLib
//> import: System.Runtime
using StarMap.API;
using KSA;
using System;
using System.IO;
using System.Text;

namespace RosuavKSAMod {
	[StarMapMod]
	public class RosuavKSAMod {
		void log(string msg) {
			using (FileStream fs = File.Open("rosuav.log", FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) {
				Byte[] data = new UTF8Encoding(true).GetBytes(msg);
				fs.Write(data, 0, data.Length);
				Byte[] nl = {10};
				fs.Write(nl, 0, 1);
			}
		}

		[StarMapImmediateLoad]
		public void Init(Mod definingMod) {
			log("Hello, world");
		}
	}
}
