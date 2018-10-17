//----------------------------------------------------------------------------
//  Copyright (C) 2004-2018 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------
#if !(NETFX_CORE || NETSTANDARD1_4)
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using System.Diagnostics;

namespace Emgu.CV.Dnn
{

    public partial class Layer : SharedPtrObject
    {
        internal Layer(IntPtr sharedPtr, IntPtr ptr)
        {
            _sharedPtr = sharedPtr;
            _ptr = ptr;
        }

        public VectorOfMat Blobs
        {
            get
            {
                return new VectorOfMat(DnnInvoke.cveDnnLayerGetBlobs(_ptr), false);
            }
        }

        protected override void DisposeObject()
        {
            if (!IntPtr.Zero.Equals(_sharedPtr))
            {
                DnnInvoke.cveDnnLayerRelease(ref _sharedPtr);
            }
        }
    }

    public static partial class DnnInvoke
    {
        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern void  cveDnnLayerRelease(ref IntPtr layerPtr);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern IntPtr cveDnnLayerGetBlobs(IntPtr layer);

    }
}
#endif