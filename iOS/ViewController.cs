using System;
using CoreGraphics;
using Foundation;
using MatiGlobalIDSDK;
using UIKit;

namespace MatiIntegration.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            MFKYC.Instance.Metadata = NSDictionary.FromObjectAndKey((NSString)"key", (NSString)"value");
            MFKYC.Instance.Delegate = new MyMFKYCDelegate();

            StoryboardButton.Title = "From StoryBoard";

            MFKYCButton matiButton = new MFKYCButton
            {
                Frame = new CGRect(0, 50, 320, 60),//you can change position,width and height
                Title = "From Code"
            };
           
            View.Add(matiButton);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        class MyMFKYCDelegate : MFKYCDelegate
        {
            public override void MFKYCLoginSuccessWithIdentityId(string identityId)
            {
                Console.WriteLine("Mati Login Success");
            }

            public override void MFKYCLoginCancelled()
            {
                Console.WriteLine("Mati Login Failed");
            }
        }

        
    }
}
