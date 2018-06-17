using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Camera
{
    class PlayCtrl
    {
        #region Const Member Variables
        // #define WINVER 
        // 0x0700 Windows 7
        // 0x0600 Windows Vista
        // 0x0502 Windows 2003 Server
        // 0x0410 Windows XP
        //<0x0400 Windows 98/Windows 2000
        public static readonly int WINVER = 0x0502;

        public static readonly uint WM_USER = 0x0400;
        public static readonly uint WM_FILE_END = WM_USER + 33;
        public static readonly uint WM_ENC_CHANGE = WM_USER + 100;

        public static readonly int COLOR_DEFAULT = 64;
        public static readonly int PLAYER_SLIDER_MAX = 200;
        public static readonly int MAX_DISPLAY_DEVICE = 4;

        public static readonly int WIDTH_PAL = 352;
        public static readonly int HEIGHT_PAL = 288;

        #region Source buffer
        //#define SOURCE_BUF_MAX
        public static readonly uint SOURCE_BUF_MAX = 1024 * 100000;
        //#define SOURCE_BUF_MIN    1024*50
        public static readonly uint SOURCE_BUF_MIN = 1024 * 50;
        #endregion

        #region Frame type
        /// <summary>
        /// 音频数据;采样率16khz，单声道，每个采样点16位表示。
        /// </summary>
        public static readonly int T_AUDIO16 = 101;
        public static readonly int T_AUDIO8 = 100;

        /// <summary>
        /// 视频数据，uyvy格式。“U0-Y0-V0-Y1-U2-Y2-V2-Y3….”，第一个像素位于图像左上角。 
        /// </summary>
        public static readonly int T_UYVY = 1;
        /// <summary>
        /// 视频数据，yv12格式。排列顺序“Y0-Y1-……”，“V0-V1….”，“U0-U1-…..”。 
        /// </summary>
        public static readonly int T_YV12 = 3;
        /// <summary>
        /// 视频数据。每个像素4个字节，排列方式与位图相似，“B-G-R-0 ……”，第一个像素位于图像左下角。 
        /// </summary>
        public static readonly int T_RGB32 = 7;
        #endregion

        #region Stream type
        /// <summary>
        /// 实时模式，适合播放网络实时数据，解码器会立刻解码。
        /// </summary>
        public static readonly int STREAME_REALTIME = 0;
        /// <summary>
        /// 文件模式，适合用户把文件数据用流方式输入。
        /// 注意：当PlayM4_InputData()返回FALSE时，用户要等一下重新输入。
        /// </summary>
        public static readonly int STREAME_FILE = 1;
        #endregion

        #region Error code
        /// <summary>
        /// 没有错误
        /// no error
        /// </summary>
        public static readonly int PlayM4_NOERROR = 0;
        /// <summary>
        /// 输入参数非法
        /// input parameter is invalid;
        /// </summary>
        public static readonly int PlayM4_PARA_OVER = 1;
        /// <summary>
        /// 调用顺序不对
        /// The order of the function to be called is error.
        /// </summary>
        public static readonly int PlayM4_ORDER_ERROR = 2;
        /// <summary>
        /// 多媒体时钟设置失败
        /// Create multimedia clock failed;
        /// </summary>
        public static readonly int PlayM4_TIMER_ERROR = 3;
        /// <summary>
        /// 视频解码失败
        /// Decode video data failed.
        /// </summary>
        public static readonly int PlayM4_DEC_VIDEO_ERROR = 4;
        /// <summary>
        /// 音频解码失败
        /// Decode audio data failed.
        /// </summary>
        public static readonly int PlayM4_DEC_AUDIO_ERROR = 5;
        /// <summary>
        /// 分配内存失败
        /// Allocate memory failed.
        /// </summary>
        public static readonly int PlayM4_ALLOC_MEMORY_ERROR = 6;
        /// <summary>
        /// 文件操作失败
        /// Open the file failed.
        /// </summary>
        public static readonly int PlayM4_OPEN_FILE_ERROR = 7;
        /// <summary>
        /// 创建线程事件等失败
        /// Create thread or event failed.
        /// </summary>
        public static readonly int PlayM4_CREATE_OBJ_ERROR = 8;
        /// <summary>
        /// 创建DirectDraw失败
        /// Create DirectDraw object failed.
        /// </summary>
        public static readonly int PlayM4_CREATE_DDRAW_ERROR = 9;
        /// <summary>
        /// 创建后端缓存失败
        /// Failed when creating off-screen surface.
        /// </summary>
        public static readonly int PlayM4_CREATE_OFFSCREEN_ERROR = 10;
        /// <summary>
        /// 缓冲区满，输入流失败
        /// Buffer is overflow.
        /// </summary>
        public static readonly int PlayM4_BUF_OVER = 11;
        /// <summary>
        /// 创建音频设备失败
        /// Failed when creating audio device.
        /// </summary>
        public static readonly int PlayM4_CREATE_SOUND_ERROR = 12;
        /// <summary>
        /// 设置音量失败
        /// Set volume failed.
        /// </summary>
        public static readonly int PlayM4_SET_VOLUME_ERROR = 13;
        /// <summary>
        /// 只能在播放文件时才能使用此接口
        /// The function only support play file.
        /// </summary>
        public static readonly int PlayM4_SUPPORT_FILE_ONLY = 14;
        /// <summary>
        /// 只能在播放流时才能使用此接口
        /// The function only support play stream.
        /// </summary>
        public static readonly int PlayM4_SUPPORT_STREAM_ONLY = 15;
        /// <summary>
        /// 系统不支持，解码器只能工作在Pentium 3以上
        /// System not support.
        /// </summary>
        public static readonly int PlayM4_SYS_NOT_SUPPORT = 16;
        /// <summary>
        /// 没有文件头
        /// No file header.
        /// </summary>
        public static readonly int PlayM4_FILEHEADER_UNKNOWN = 17;
        /// <summary>
        /// 解码器和编码器版本不对应
        /// The version of decoder and encoder is not adapted.  
        /// </summary>
        public static readonly int PlayM4_VERSION_INCORRECT = 18;
        /// <summary>
        /// 初始化解码器失败
        /// Initialize decoder failed.
        /// </summary>
        public static readonly int HIK_PALYM4_INIT_DECODER_ERROR = 19;
        /// <summary>
        /// 文件太短或码流无法识别
        /// The file data is unknown.
        /// </summary>
        public static readonly int PlayM4_CHECK_FILE_ERROR = 20;
        /// <summary>
        /// 初始化多媒体时钟失败
        /// Initialize multimedia clock failed.
        /// </summary>
        public static readonly int PlayM4_INIT_TIMER_ERROR = 21;
        /// <summary>
        /// 位拷贝失败
        /// Blt failed.
        /// </summary>
        public static readonly int PlayM4_BLT_ERROR = 22;
        /// <summary>
        /// 显示Overlay失败
        /// Update failed.
        /// </summary>
        public static readonly int PlayM4_UPDATE_ERROR = 23;
        /// <summary>
        /// 打开文件错误
        /// Open file error, stream type is multi.
        /// </summary>
        public static readonly int PlayM4_OPEN_FILE_ERROR_MULTI = 24;
        /// <summary>
        /// 打开文件错误
        /// Open file error, stream type is video.
        /// </summary>
        public static readonly int PlayM4_OPEN_FILE_ERROR_VIDEO = 25;
        /// <summary>
        /// JPEG格式压缩错误
        /// JPEG compress error.
        /// </summary>
        public static readonly int PlayM4_JPEG_COMPRESS_ERROR = 26;
        /// <summary>
        /// 不支持此文件的版本
        /// Don't support the version of this file.
        /// </summary>
        public static readonly int PlayM4_EXTRACT_NOT_SUPPORT = 27;
        /// <summary>
        /// 提取视频数据失败
        /// Extract video data failed.
        /// </summary>
        public static readonly int PlayM4_EXTRACT_DATA_ERROR = 28;

        #endregion

        #region Display buffers
        /// <summary>
        /// 播放缓冲最大值
        /// </summary>
        public static readonly int MAX_DIS_FRAMES = 50;
        /// <summary>
        /// 播放缓冲最小值
        /// </summary>
        public static readonly int MIN_DIS_FRAMES = 6;
        #endregion

        #region Locate by
        /// <summary>
        /// 帧号
        /// </summary>
        public static readonly int BY_FRAMENUM = 1;
        /// <summary>
        /// 时间
        /// </summary>
        public static readonly int BY_FRAMETIME = 2;
        #endregion

        #region Display type
        /// <summary>
        /// 正常分辨率数据送显卡显示。
        /// </summary>
        public static readonly int DISPLAY_NORMAL = 1;
        /// <summary>
        /// 1/4分辨率数据送显卡显示。
        /// </summary>
        public static readonly int DISPLAY_QUARTER = 2;
        #endregion

        #region Timer type
        /// <summary>
        /// 一个进程中只能使用16个，定时比较准，画面流畅。
        /// Only 16 timers for every process.Default TIMER;
        /// </summary>
        public static readonly int TIMER_1 = 1;
        /// <summary>
        /// 使用数目没有限制，定时没有TIMER_1准。
        /// Not limit;But the precision less than TIMER_1; 
        /// </summary>
        public static readonly int TIMER_2 = 2;
        #endregion

        #region BUFFER TYPE
        /// <summary>
        /// 视频数据源缓冲区，缓冲解码之前视频数据，只对流模式有效，单位byte。
        /// </summary>
        public static readonly ushort BUF_VIDEO_SRC = 1;
        /// <summary>
        /// 音频数据源缓冲区，缓冲解码之前音频数据，只对流模式有效, 单位byte。 
        /// </summary>
        public static readonly ushort BUF_AUDIO_SRC = 2;
        /// <summary>
        /// 解码后视频数据缓冲区，单位帧数。 
        /// </summary>
        public static readonly ushort BUF_VIDEO_RENDER = 3;
        /// <summary>
        /// 解码后音频数据缓冲区，单位帧数，音频40ms数据定为一帧。 
        /// </summary>
        public static readonly ushort BUF_AUDIO_RENDER = 4;
        #endregion

        #endregion

        #region HikPlayer
        /// <summary>
        /// 1、 BOOL PlayM4_InitDDraw(HWND hWnd);
        /// 初始化DirectDraw表面。在使用vb,delphi开发时请注意，它们生成的对话框具有WS_CLIPCHILDREN
        /// 窗口风格，必须去掉这种风格，否则显示画面会被对话框上的控件覆盖。注意：1.1版以上不需要调用。
        /// </summary>
        /// <param name="hWnd">hWnd 应用程序主窗口的句柄。</param>
        /// <returns></returns>
        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_InitDDraw(IntPtr hWnd);















        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_GetPort(ref Int32 port);

        [DllImport("PlayCtrl.dll")]
        public static extern Int32 PlayM4_GetLastError(Int32 port);

        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_SetStreamOpenMode(Int32 port, Int32 mode);

        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_OpenStream(Int32 port, IntPtr buffer, UInt32 size, Int32 what);

        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_SetOverlayMode(Int32 port, Int32 param1, Int32 param2);

        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_SetDecodeEngineEx(Int32 port, Int32 param1);

        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_SetDecodeFrameType(Int32 port, UInt32 param1);

        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_InputData(Int32 port, IntPtr param1, UInt32 param2);






        /// <summary>
        /// 2、 BOOL PlayM4_RealeseDDraw(); 
        /// 释放directDraw表面；注意：1.1版以上不需要调用。
        /// </summary>
        /// <returns></returns>
        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_RealeseDDraw();

        /// <summary>
        /// 3、 BOOL PlayM4_OpenFile(LONG nPort,LPSTR sFileName); 
        /// 打开播放文件
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="sFileName">文件名，文件不能超过4G或小于4K</param>
        /// <returns></returns>
        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_OpenFile(int nPort, string sFileName);

        /// <summary>
        /// 4、 BOOL PlayM4_CloseFile(LONG nPort); 
        /// 关闭播放文件
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_CloseFile(int nPort);

        /// <summary>
        /// 5、 BOOL PlayM4_Play(LONG nPort, HWND hWnd); 
        /// 播放开始，播放视频画面大小将根据hWnd窗口调整，要全屏显示，只要把hWnd窗口放大到全屏。
        /// 如果已经播放，只是改变当前播放速度为正常速度。 
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="hWnd">hWnd 播放视频的窗口句柄</param>
        /// <returns></returns>
        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_Play(int nPort, IntPtr hWnd);

        /// <summary>
        /// 6、 BOOL PlayM4_Stop(LONG nPort); 
        /// 播放结束
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_Stop(int nPort);

        /// <summary>
        /// 7、 BOOL PlayM4_Pause(LONG nPort,DWORD nPause); 
        /// 播放暂停/恢复
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="nPause">nPause=TRUE暂停，否则恢复</param>
        /// <returns></returns>
        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_Pause(int nPort, bool nPause);

        /// <summary>
        /// 8、 BOOL PlayM4_Fast(LONG nPort); 
        /// 快速播放，每次调用将使当前播放速度加快一倍，最多调用4次；要恢复正常播放调用PlayM4_Play()，
        /// 从当前位置开始正常播放
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_Fast(int nPort);

        /// <summary>
        /// 9、 BOOL PlayM4_Slow(LONG nPort); 
        /// 慢速播放，每次调用将使当前播放速度慢一倍；最多调用4次；要恢复正常播放调用PlayM4_Play()
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_Slow(int nPort);

        /// <summary>
        /// 10、BOOL PlayM4_SetPlayPos(LONG nPort,float fRelativePos); 
        /// 设置文件播放指针的相对位置（百分比）。 
        /// </summary>
        /// <param name="nPort"></param>
        /// <param name="fRelativePos">范围0-100%</param>
        /// <returns></returns>
        [DllImport("PlayCtrl.dll")]
        public static extern bool PlayM4_SetPlayPos(int nPort, float fRelativePos);

        #endregion
    }
}
