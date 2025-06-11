using ChaiTea;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChaiTea
{
    public class odeclock
    {
        // DLL名称
        private const string DLL_NAME = "ChaiTeaLib";

        // 指向C++ PrecisionClock对象的指针
        private IntPtr _clockHandle;

        // 导入DLL函数
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PrecisionClock_Create();

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern void PrecisionClock_Start(IntPtr clock);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern void PrecisionClock_Stop(IntPtr clock);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern void PrecisionClock_Reset(IntPtr clock);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern double PrecisionGetCurrentTimeSeconds(IntPtr clock);
        // 导入 cClampDouble 函数
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern double cClampDouble(double value, double low, double high);

        // 提供一个公共方法来调用 cClampDouble
        public double Clamp(double value, double low, double high)
        {
            return cClampDouble(value, low, high);
        }

        // 构造函数
        public odeclock()
        {
            // 创建C++ PrecisionClock对象并获取其指针
            _clockHandle = PrecisionClock_Create();
            if (_clockHandle == IntPtr.Zero)
            {
                throw new Exception("Failed to create PrecisionClock instance.");
            }
        }

        // 开始计时
        public void Start()
        {
            if (_clockHandle != IntPtr.Zero)
            {
                PrecisionClock_Start(_clockHandle);
            }
            else
            {
                throw new ObjectDisposedException("Clock", "Clock object has been disposed.");
            }
        }

        // 停止计时
        public void Stop()
        {
            if (_clockHandle != IntPtr.Zero)
            {
                PrecisionClock_Stop(_clockHandle);
            }
            else
            {
                throw new ObjectDisposedException("Clock", "Clock object has been disposed.");
            }
        }

        // 重置计时器
        public void Reset()
        {
            if (_clockHandle != IntPtr.Zero)
            {
                PrecisionClock_Reset(_clockHandle);
            }
            else
            {
                throw new ObjectDisposedException("Clock", "Clock object has been disposed.");
            }
        }

        public double GetCurrentTimeSeconds()
        {
            if (_clockHandle != IntPtr.Zero)
            {
                return PrecisionGetCurrentTimeSeconds(_clockHandle);
            }
            else
            {
                throw new ObjectDisposedException("Clock", "Clock object has been disposed.");
            }
        }

    }
}
