using System;
using Java.Lang;

namespace Com.Matilock.Mati_kyc_sdk.Utils
{
    public partial class WriteBitmapToFileTask : global::Android.OS.AsyncTask
    {
        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            Console.WriteLine("---------------WriteBitmapToFileTask:DoInBackground");
            return DoInBackground((global::Java.Lang.Void[]) @params);
        }
    }
}
