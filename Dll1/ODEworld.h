#pragma once
#define DllExport   __declspec( dllexport )


#include "CODE.h"
#include "Types.h"
#include <vector>
#include "chai3d.h"
#ifdef __cplusplus
extern "C" {
#endif
	DllExport cODEWorld* ODEWorld_Create(chai3d::cWorld* a_parentWorld);
	DllExport void ODEWorld_SetGravity(cODEWorld* world, Vec3 gravity);
	DllExport void ODEWorld_SetLinearDamping(cODEWorld* world, double linearDamping);
    DllExport void ODEWorld_SetAngularDamping(cODEWorld* world, double angularDamping);
	DllExport void ODEWorld_UpdateDynamics(cODEWorld* world, double dt);
#ifdef __cplusplus
}
#endif