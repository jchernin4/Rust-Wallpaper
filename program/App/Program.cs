using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace App {
	public class Program {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;

        public static void SetWallpaper(String path) {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public static void Main(string[] args) {
            int lastUpdatedHour = -1;

            while (true) {
                try {

                    int curHour = DateTime.Now.Hour;

                    if (lastUpdatedHour != curHour) {
                        Console.WriteLine("Updating wallpaper. Hour: " + curHour);

                        String imgPath = "D:\\Desktop\\RustWallpaper\\" + curHour + ".PNG";
                        Console.WriteLine("Path: " + imgPath);

                        SetWallpaper(imgPath);

                        lastUpdatedHour = curHour;
                    }
                    Thread.Sleep(10000);

                } catch {
                }
            }
        }
	}
}