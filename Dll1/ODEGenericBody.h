#pragma once
#define DllExport   __declspec( dllexport )


#include "CODE.h"
#include "Types.h"
#include <vector>
#include "chai3d.h"
#ifdef __cplusplus
extern "C" {
#endif
	DllExport cODEGenericBody* ODEGenericBody_Create(cODEWorld* a_parentWorld);
	DllExport void ODEGenericBody_SetImageModel(cODEGenericBody* a_body, chai3d::cGenericObject* a_imageModel);
	DllExport void ODEGenericBody_SetMass(cODEGenericBody* a_body, double a_mass);
	DllExport void ODEGenericBody_CreateDynamicBox(cODEGenericBody* a_body, double a_sizeX, double a_sizeY, double a_sizeZ);
	DllExport void ODEGenericBody_CreateStaticPlane(cODEGenericBody* a_body, Vec3 a_position, Vec3 a_normal);
	DllExport void ODEGenericBody_SetLocalPosition(cODEGenericBody* a_body, Vec3 a_position);
	DllExport void ODEGenericBody_AddExternalForceAtPoint(cODEGenericBody* a_body, Vec3 a_force, Vec3 a_pos);
	DllExport void ODEGenericBody_Updatebody(cODEGenericBody* a_body);
	DllExport void ODEGenericBody_EnableDynamic(cODEGenericBody* a_body);
#ifdef __cplusplus
}
#endif