using System;
using Java.Lang;

namespace Com.Matilock.Mati_kyc_sdk.Utils
{
    public partial class AreaComparator : global::Java.Lang.Object, global::Java.Util.IComparator
    {
        public int Compare(Java.Lang.Object o1, Java.Lang.Object o2)
        {
            Console.WriteLine("---------------AreaComparator:Compare");
            if (o1 is global::Android.Util.Size)
            {
                return Compare((global::Android.Util.Size)o1, (global::Android.Util.Size)o2);
            }
            else
            {
                return o1.GetHashCode() - o2.GetHashCode();
            }
            
        }
    }
}
