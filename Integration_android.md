# Mati Xamarin iOS SDK documentation

![alt text](https://github.com/MatiFace/mati-global-id-sdk/blob/master/Group%2011-1.png)

## Project configurations

Create a Xamarin IOS native or Xamarin forms.
Add a reference to MatiGlobalIDSDK.IOS bidding project.
If you are using xamarin forms a custom render will be required to display the KYC Button.

## AppDelegate - Mati KYC Initialisation

Make the following changes in your AppDelegate.cs file

### c

    using MatiGlobalIDSDK;

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // Override point for customization after application launch.
        // If not required for your application you can safely delete this method
        NSDictionary metadata = null;
        MFKYC.RegisterWithClientId("{custom_token}", metadata);
        return true;
    }


## Mati KYC Button Placement (UI)

You now need to place the Mati KYC button inside your App. You have 2 options for that (interface builder vs. code):

You can include `MFKYCButton` into your view using XCode interface builder under the class name `_TtC15MatiGlobalIDSDK11MFKYCButton`
Or
Add using C#

### c

    MFKYC.Instance.Metadata = NSDictionary.FromObjectAndKey((NSString)"key", (NSString)"value");
    MFKYCButton matiButton = new MFKYCButton
    {
        Frame = new CGRect(0, 50, 320, 60),//you can change position,width and height
        Title = "Custom Title"
    };
    View.Add(matiButton);

## Mati KYC Delegate

Use the delegate functions below in order to handle the success / failure of each verification.

### c

    //Assign the controller of your choice to be the Mati button delegate
    MFKYC.Instance.Delegate = new MyMFKYCDelegate();

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

## Enabling Camera and Photo permissions

The following permissions are needed to capture video and access the photo gallery.

### Info.plist

    <key>NSCameraUsageDescription</key>
    <string>Mati needs access to your Camera</string>
    <key>NSPhotoLibraryUsageDescription</key>
    <string>Mati needs access to your media library</string>

### Requirements

    iOS 9.0
    Xcode 10.2
    Swift 5.0

For Xcode 10.1 and below, use [Version 2.3.13](https://github.com/MatiFace/mati-global-id-sdk/releases/tag/2.3.13)

## Mati iOS SDK integration video

[![Mati SDK integration demo video](https://img.youtube.com/vi/sPS7_QoFhpY/0.jpg)](https://www.youtube.com/watch?v=sPS7_QoFhpY)
