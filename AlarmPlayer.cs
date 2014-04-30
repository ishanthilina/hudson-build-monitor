using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hudson_build_monitor
{
    class AlarmPlayer

        
    {

        //settings
        private static String soundFileLocation = Application.StartupPath + "\\sounds\\warning.mp3";

        public static Boolean isAlarmEnabled = false;
        public static Boolean isAlarmPlaying = false;

        //sound player
        private static WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();


        /***
         * Starts playing the alarm
         */
        public static void Play_Alarm()
        {
            //if the alarm is enabled and if it is not already playing
            if (isAlarmEnabled && !isAlarmPlaying)
            {
                player.URL = soundFileLocation;
                player.settings.setMode("loop", true);
                player.controls.play();
                //indicate that alarm is playing
                isAlarmPlaying = true;
            }
        }

        /***
         * Stops playing the alarm
         */
        public static void Stop_Alarm()
        {
            player.controls.stop();
            isAlarmPlaying = false;
        }
    }
}
