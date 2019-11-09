using System;
using Android.App;
using Com.Matilock.Mati_kyc_sdk;

namespace MatiIntegration.Droid
{
    [Application]
    public class MyApplication : Application
    {
        public MyApplication(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Mati.Init(this, "5dc09bd3047ea0001c4b20ba"); //your client ID here
        }
    }
}
