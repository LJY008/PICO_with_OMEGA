#pragma once
#include "Types.h"
#include "Util.h"
#include "Simulation.h"
#include "HapticDevice.h"
#include "ToolGripper.h"
using namespace chai3d;

extern "C" {

    cToolGripper* ToolGripper_Create(cWorld* worldObj,int deviceIndex)
    {   
        cGenericHapticDevicePtr device;
        HapticDevice_GetDevice(device, deviceIndex, false);
        cToolGripper* pTool = new cToolGripper(worldObj);
        pTool->setHapticDevice(device);
        return pTool;
    }

    GripperPose ToolGripper_GetProxyPosition(cToolGripper* tool)
    {
        cVector3d thumpPos = tool->m_hapticPointThumb->getGlobalPosProxy();
        cVector3d fingerPos = tool->m_hapticPointFinger->getGlobalPosProxy();

        return { ConvertXYZToUnity(thumpPos), ConvertXYZToUnity(fingerPos) };
    }

    GripperPose ToolGripper_GetDevicePosition(cToolGripper* tool)
    {
        cVector3d thumpPos = tool->m_hapticPointThumb->getGlobalPosGoal();
        cVector3d fingerPos = tool->m_hapticPointFinger->getGlobalPosGoal();

        return { ConvertXYZToUnity(thumpPos), ConvertXYZToUnity(fingerPos) };
    }

    void ToolGripper_SetGripperWorkspaceScale(cToolGripper* tool, double gripperWorkspaceScale)
    {
        tool->setGripperWorkspaceScale(gripperWorkspaceScale);
    }

    double ToolGripper_GetGripperWorkspaceScale(cToolGripper* tool)
    {
        return tool->getGripperWorskpaceScale();
    }


    Vec4 ToolGripper_GetQuaternion(cToolCursor* tool)
    {
        cQuaternion q;
        q.fromRotMat(tool->getDeviceGlobalRot());
        return ConvertQuaternionToUnity(q);
    }
}