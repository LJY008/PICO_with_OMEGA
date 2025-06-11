using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using UnityEngine;

namespace ChaiTea
{
    public class ODEworld : GenericObject
    {
        //protected new IntPtr ptr = IntPtr.Zero;
        //public new IntPtr Pointer { get => ptr; }
        //public new bool Initialized { get => ptr != IntPtr.Zero; }


        public ODEworld(World pWorldObject) : base(ODEWorld_Create(pWorldObject.Pointer))
        {
            this.ptr = ODEWorld_Create(pWorldObject.Pointer);
        }

        
        public void SetGravity(Vector3 gravity)
        {
            ODEWorld_SetGravity(ptr,gravity);
        }

        public void SetLinearDamping(double linearDamping)
        {
            ODEWorld_SetLinearDamping(ptr, linearDamping);
        }

        public void SetAngularDamping(double angularDamping)
        {
            ODEWorld_SetAngularDamping(ptr, angularDamping);
        }

        public void UpdateDynamics(double dt)
        {
            ODEWorld_UpdateDynamics(ptr, dt);
        }

        [DllImport("ChaiTeaLib", EntryPoint = "ODEWorld_Create")]
        internal static extern IntPtr ODEWorld_Create(IntPtr pWorldObject);
        [DllImport("ChaiTeaLib", EntryPoint = "ODEWorld_SetGravity")]
        internal static extern void ODEWorld_SetGravity(IntPtr pObject, Vec3 gravity);
        [DllImport("ChaiTeaLib", EntryPoint = "ODEWorld_SetLinearDamping")]
        internal static extern void ODEWorld_SetLinearDamping(IntPtr pObject, double linearDamping);
        [DllImport("ChaiTeaLib", EntryPoint = "ODEWorld_SetAngularDamping")]
        internal static extern void ODEWorld_SetAngularDamping(IntPtr pObject, double angularDamping);
        [DllImport("ChaiTeaLib", EntryPoint = "ODEWorld_UpdateDynamics")]
        internal static extern void ODEWorld_UpdateDynamics(IntPtr pObject, double dt);
    }
}
