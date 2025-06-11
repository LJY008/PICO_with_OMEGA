#pragma once

#include "Types.h"
#include "Util.h"
#include "Simulation.h"
#include "HapticDevice.h"
#include "ODEworld.h"

cODEWorld* ODEWorld_Create(chai3d::cWorld* a_parentWorld)
{    
    cODEWorld* p_world = new cODEWorld(a_parentWorld);
    return p_world;
}

void ODEWorld_SetGravity(cODEWorld* world, Vec3 gravity)
{
    world->setGravity(ConvertXYZToCHAI3D(gravity));
}

void ODEWorld_SetLinearDamping(cODEWorld* world, double linearDamping)
{
    world->setLinearDamping(linearDamping);
}

void ODEWorld_SetAngularDamping(cODEWorld* world, double angularDamping)
{
    world->setAngularDamping(angularDamping);
}

void ODEWorld_UpdateDynamics(cODEWorld* world, double dt)
{
    world->updateDynamics(dt);
}
