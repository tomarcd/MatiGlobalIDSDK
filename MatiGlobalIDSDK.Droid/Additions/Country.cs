using System;
using Java.Lang;

namespace Com.Matilock.Mati_kyc_sdk.Models
{
    public partial class Country : global::Java.Lang.Object, global::Java.IO.ISerializable, global::Java.Lang.IComparable
    {
        public int CompareTo(Java.Lang.Object o)
        {
            Console.WriteLine("---------------Country:CompareTo");
            if (o is global::Com.Matilock.Mati_kyc_sdk.Models.Country)
            {
                return CompareTo((global::Com.Matilock.Mati_kyc_sdk.Models.Country)o);
            }
            else
            {
                return this.GetHashCode() - o.GetHashCode();
            }
            
        }
    }
}
