using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
public delegate int TaskonTAudioCastEvent(int eventMsg, string parstr);

namespace testBroadCast
{
    class audio
    {
        [DllImport("CAudioCast.dll", EntryPoint = "Audio_OpenAudioCast", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Audio_OpenAudioCast(string IpAddr, int Port);
        public static int audio_OpenAudioCast(string ipaddr, int port)
        {
            return Audio_OpenAudioCast(ipaddr, port);
        }

        [DllImport("CAudioCast.dll")]
        private static extern int Audio_CloseAudioCast();
        public static int audio_CloseAudioCast()
        {
            return Audio_CloseAudioCast();
        }

        [DllImport("CAudioCast.dll", EntryPoint = "Audio_CheckPWD", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Audio_CheckPWD(string Userstr, string Pwdstr);
        public static string audio_CheckPWD(string userstr, string pwdstr)
        {
            return Marshal.PtrToStringAnsi(Audio_CheckPWD(userstr, pwdstr));
        }


        [DllImport("CAudioCast.dll")]
        private static extern string Audio_GetClientList();
        public static string audio_GetClientList()
        {
            return (Audio_GetClientList());
        }

        [DllImport("CAudioCast.dll", EntryPoint = "Audio_StartTask", CallingConvention = CallingConvention.Cdecl)]
        private static extern string Audio_GetTaskList();
        public static string audio_GetTaskList()
        {
            return (Audio_GetTaskList());
        }

         [DllImport("CAudioCast.dll", EntryPoint = "Audio_StartTask", CallingConvention = CallingConvention.Cdecl)]
        private static extern string Audio_StartTask(int id);
        public static string audio_StartTask(int id)
        {
            return (Audio_StartTask(id));
        }

          [DllImport("CAudioCast.dll", EntryPoint = "Audio_StopTask", CallingConvention = CallingConvention.Cdecl)]
        private static extern string Audio_StopTask(int t_s);
        public static string audio_StopTask(int task_s)
        {
            return (Audio_StopTask(task_s));
        }

        [DllImport("CAudioCast.dll", EntryPoint = "Audio_SetVolume", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Audio_SetVolume(int t_s, int vmm);
        public static int audio_SetVolume(int v_s, int v_l)
        {
            return (Audio_SetVolume(v_s, v_l));
        }


        [DllImport("CAudioCast.dll", EntryPoint = "Audio_SetEvenFunc", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Audio_SetEvenFunc(int EnumEvent, TaskonTAudioCastEvent Func);

        static TaskonTAudioCastEvent ponTAudioCastEvent;//防止被GC回收
        public static int audio_SetEventFunc(int EnumEvent, TaskonTAudioCastEvent Func)
        {
            ponTAudioCastEvent = new TaskonTAudioCastEvent(Func);
            GC.KeepAlive(Func);
            GC.KeepAlive(ponTAudioCastEvent);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            return Audio_SetEvenFunc(EnumEvent, Func);
        }


        [DllImport("CAudioCast.dll", EntryPoint = "Audio_Get_Mic_ClientStatus", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Audio_Get_Mic_ClientStatus();

        public static string audio_GetMicClientStatus()
        {
            return Marshal.PtrToStringAnsi(Audio_Get_Mic_ClientStatus());
        }


     
    }
}
