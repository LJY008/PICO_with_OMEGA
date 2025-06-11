#pragma once

#include "Types.h"
#include "Util.h"
#include "Simulation.h"
#include "ODEGenericBody.h"
#include "HapticDevice.h"

cODEGenericBody* ODEGenericBody_Create(cODEWorld* a_parentWorld)
{
	cODEGenericBody* p_body = new cODEGenericBody(a_parentWorld);
	return p_body;
}

void ODEGenericBody_SetImageModel(cODEGenericBody* a_body,chai3d::cGenericObject* a_imageModel)
{
	a_body->setImageModel(a_imageModel);
}

void ODEGenericBody_SetMass(cODEGenericBody* a_body,double a_mass)
{
	a_body->setMass(a_mass);
}

void ODEGenericBody_CreateDynamicBox(cODEGenericBody* a_body,double a_sizeX,double a_sizeY,double a_sizeZ)
{
	a_body->createDynamicBox(a_sizeX,a_sizeY,a_sizeZ);
}

void ODEGenericBody_CreateStaticPlane(cODEGenericBody* a_body,Vec3 a_position,Vec3 a_normal)
{
	a_body->createStaticPlane(ConvertXYZToCHAI3D(a_position), ConvertXYZToCHAI3D(a_normal));
}

void ODEGenericBody_SetLocalPosition(cODEGenericBody* a_body,Vec3 a_position)
{
	a_body->setLocalPos(ConvertXYZToCHAI3D(a_position));
}

void ODEGenericBody_AddExternalForceAtPoint(cODEGenericBody* a_body,  Vec3 a_force, Vec3 a_pos)
{
	a_body->addExternalForceAtPoint(ConvertXYZToCHAI3D(a_force), ConvertXYZToCHAI3D(a_pos));
}

void ODEGenericBody_EnableDynamic(cODEGenericBody* a_body)
{
	a_body->enableDynamics();
}

void ODEGenericBody_Updatebody(cODEGenericBody* a_body)
{
	a_body->updateBodyPosition();
}