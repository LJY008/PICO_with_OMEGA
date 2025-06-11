using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ChaiTea
{
    public class ODEgenericbody : GenericObject
    {
        
        private const string DLL_NAME = "ChaiTeaLib";
        protected new IntPtr ptr = IntPtr.Zero;
        public new IntPtr Pointer { get => ptr; }
        public new bool Initialized { get => ptr != IntPtr.Zero; }

        public ODEgenericbody(ODEworld odeWorldObject) : base(IntPtr.Zero)
        {
            Debug.Log("Initializing ODEgenericbody...");

            if (odeWorldObject == null)
            {
                Debug.LogError("ODEworld object is null. Please assign a valid ODEworld instance.");
                return;
            }

            if (odeWorldObject.Pointer == IntPtr.Zero)
            {
                Debug.LogError("ODEworld Pointer is invalid. Ensure the ODEworld object is properly initialized.");
                return;
            }

            this.ptr = ODEGenericBody_Create(odeWorldObject.Pointer);

            if (this.ptr == IntPtr.Zero)
            {
                Debug.LogError("Failed to create ODEgenericbody instance. Check the underlying library implementation.");
            }
            else
            {
                Debug.Log($"ODEgenericbody created successfully with pointer: {ptr}");
            }
        }

        // 设置图像模型
        public void SetImageModel(GenericObject imageModel)
        {
            Debug.Log("Calling SetImageModel...");

            if (imageModel == null || imageModel.Pointer == IntPtr.Zero)
            {
                Debug.LogError("Image model is not initialized or invalid.");
                return;
            }

            if (ptr == IntPtr.Zero)
            {
                Debug.LogError("ODEgenericbody is not initialized.");
                return;
            }

            try
            {
                ODEGenericBody_SetImageModel(ptr, imageModel.Pointer);
                Debug.Log($"SetImageModel called successfully with pointer: {imageModel.Pointer}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to call SetImageModel: {ex.Message}");
            }
        }

        // 设置质量
        public void SetMass(double mass)
        {
            Debug.Log($"Setting mass to {mass}...");
            ODEGenericBody_SetMass(ptr, mass);
            Debug.Log($"Mass set successfully: {mass}");
        }

        // 创建动态盒子
        public void CreateDynamicBox(double sizeX, double sizeY, double sizeZ)
        {
            Debug.Log($"Creating dynamic box with size ({sizeX}, {sizeY}, {sizeZ})...");
            ODEGenericBody_CreateDynamicBox(ptr, sizeX, sizeY, sizeZ);
            Debug.Log($"Dynamic box created successfully.");
        }

        // 创建静态平面
        public void CreateStaticPlane(Vec3 position, Vec3 normal)
        {
            Debug.Log($"Creating static plane at position ({position.x}, {position.y}, {position.z}) with normal ({normal.x}, {normal.y}, {normal.z})...");
            ODEGenericBody_CreateStaticPlane(ptr, position, normal);
            Debug.Log($"Static plane created successfully.");
        }

        // 设置局部位置
        public void ODESetLocalPosition(Vector3 position)
        {
            Debug.Log($"Setting local position to ({position.x}, {position.y}, {position.z})...");
            ODEGenericBody_SetLocalPosition(ptr, position);
            Debug.Log($"Local position set successfully.");
        }

        // 在指定点施加外力
        public void AddExternalForceAtPoint(Vec3 force, Vec3 pos)
        {
            Debug.Log($"Adding external force {force} at position {pos}...");
            ODEGenericBody_AddExternalForceAtPoint(ptr, force, pos);
            Debug.Log($"External force added successfully.");
        }

        public void Updatebody()
        {
            Debug.Log("Updating body...");
            ODEGenericBody_Updatebody(ptr);
            Debug.Log("Body updated successfully.");
        }

        public void EnableDynamic()
        {
            Debug.Log("Enabling dynamic body...");
            ODEGenericBody_EnableDynamic(ptr);
            Debug.Log("Dynamic body enabled successfully.");
        }
        // 定义与DLL中的函数对应的外部方法


        [DllImport("ChaiTeaLib", EntryPoint = "ODEGenericBody_Create")]
        public static extern IntPtr ODEGenericBody_Create(IntPtr body);

        [DllImport("ChaiTeaLib", EntryPoint = "ODEGenericBody_SetImageModel")]
        public static extern void ODEGenericBody_SetImageModel(IntPtr body, IntPtr imageModel);

        [DllImport("ChaiTeaLib", EntryPoint = "ODEGenericBody_SetMass")]
        public static extern void ODEGenericBody_SetMass(IntPtr body, double mass);

        [DllImport("ChaiTeaLib", EntryPoint = "ODEGenericBody_CreateDynamicBox")]
        public static extern void ODEGenericBody_CreateDynamicBox(IntPtr body, double sizeX, double sizeY, double sizeZ);

        [DllImport("ChaiTeaLib", EntryPoint = "ODEGenericBody_CreateStaticPlane")]
        public static extern void ODEGenericBody_CreateStaticPlane(IntPtr body, Vec3 position, Vec3 normal);
                
        [DllImport("ChaiTeaLib", EntryPoint = "ODEGenericBody_SetLocalPosition")]
        public static extern void ODEGenericBody_SetLocalPosition(IntPtr body, Vec3 position);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]        
        public static extern void ODEGenericBody_AddExternalForceAtPoint(IntPtr a_body, Vec3 a_force, Vec3 a_pos);

        [DllImport("ChaiTeaLib", EntryPoint = "ODEGenericBody_Updatebody")]
        public static extern void ODEGenericBody_Updatebody(IntPtr body);

        [DllImport("ChaiTeaLib", EntryPoint = "ODEGenericBody_EnableDynamic")]
        public static extern void ODEGenericBody_EnableDynamic(IntPtr a_body);

    }
}