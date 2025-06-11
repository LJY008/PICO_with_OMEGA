#include "precisionclock.h"
#include "Types.h"
#include "Util.h"
#include "Simulation.h"
cPrecisionClock* PrecisionClock_Create()
{
    return new cPrecisionClock();
}

void PrecisionClock_Start(cPrecisionClock* clock)
{
    clock->start();
}

void PrecisionClock_Stop(cPrecisionClock* clock)
{
    clock->stop();
}

void PrecisionClock_Reset(cPrecisionClock* clock)
{
    clock->reset();
}

double PrecisionGetCurrentTimeSeconds(cPrecisionClock* clock)
{
    
    return clock->getCurrentTimeSeconds();
}

double cClampDouble(double value, double low, double high)
{
    return chai3d::cClamp(value, low, high);
}