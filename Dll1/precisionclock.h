#pragma once
#define DllExport   __declspec( dllexport )
#include "Types.h"
#include"chai3d.h"


// ÉùÃ÷ cClamp Ä£°åº¯Êý
template<class T>
inline T cClamp(const T& a_value, const T& a_low, const T& a_high)
{
	if (a_value < a_low)  return a_low;
	else if (a_value > a_high) return a_high;
	else                       return a_value;
}


#ifdef __cplusplus
extern "C" {
#endif
	DllExport double cClampDouble(double value, double low, double high);
	DllExport chai3d::cPrecisionClock* PrecisionClock_Create();
	DllExport void PrecisionClock_Start(chai3d::cPrecisionClock* clock);
	DllExport void PrecisionClock_Stop(chai3d::cPrecisionClock* clock);
	DllExport void PrecisionClock_Reset(chai3d::cPrecisionClock* clock);
    DllExport double PrecisionGetCurrentTimeSeconds(chai3d::cPrecisionClock* clock);
#ifdef __cplusplus
}
#endif