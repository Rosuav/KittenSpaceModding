//> path: ~/KSA/linux64
//> path: ~/KSA/StarMap
//> -target:library
//> -nostdlib+
//> import: StarMap.API
//> import: KSA
//> import: System.Private.CoreLib
//> import: System.Runtime
//> import: 0Harmony
//> import: Brutal.Glfw
//> import: Planet.Render.Core
using StarMap.API;
using KSA;
using System;
using System.IO;
using System.Text;
using HarmonyLib;
using Brutal.GlfwApi;

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

		[StarMapAllModsLoaded]
		public void fullyLoaded() {Patcher.patch();}
		[StarMapUnload]
		public void unload() {Patcher.unload();}
	}

	[HarmonyPatch]
	internal static class Patcher
	{
		private static Harmony m_harmony = new Harmony("RosuavKSAMod");
		public static void patch() {
			m_harmony?.PatchAll(typeof(Patcher).Assembly);
		}

		public static void unload() {
			m_harmony?.UnpatchAll("SimpleMod");
			m_harmony = null;
		}

		static void log(string msg) {
			using (FileStream fs = File.Open("rosuav.log", FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) {
				Byte[] data = new UTF8Encoding(true).GetBytes(msg);
				fs.Write(data, 0, data.Length);
				Byte[] nl = {10};
				fs.Write(nl, 0, 1);
			}
		}

		[HarmonyPatch(typeof(Vehicle), nameof(Vehicle.OnKey))]
		[HarmonyPrefix]
		public static bool onKey(Vehicle __instance, RenderCore.Input.GlfwKeyEvent keyEvent) {
			log("GOT A KEYBOARD");
			return true;
		}
	}
}
