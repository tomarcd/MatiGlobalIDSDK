# Mati Android SDK documentation

Our SDK requires Android v5.0 (API v21) or above.

![alt text](https://github.com/MatiFace/mati-global-id-sdk-android/blob/master/Group%2011.png?raw=true)

## Project configurations

Create a Xamarin Android native or Xamarin forms.
Your MainActivity should implement AppCompatActivity for native or FormsAppCompatActivity for forms.
Add a reference to MatiGlobalIDSDK.Droid bidding project.
If you are using xamarin forms a custom render will be required to display the KYC Button.

## Androidx Support Libraries

Mati Android SDK requires Androidx Support libraries, legacy version of the support library will have to be migrated to the new version via bytecode replacement. This can be done by add "Xamarin.AndroidX.Migration" using nuget, currently this feature is in preview, if you don't see a listing please select "Show pre-release packages". After this, the first execution of the app should return a list of additional packages needed to transition to Androidx.

For more detail about Androidx migration please refer to the link below.
![alt text](https://devblogs.microsoft.com/xamarin/androidx-for-xamarin/)

## Mati SDK initialization

In the onCreate() method of your application class, initialize Mati by calling the following line of code:

    [Application]
    public class MyApplication : Application
    {
        public MyApplication(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Mati.Init(this, "your client ID here");
        }
    }

## Mati KYC Button Placement (UI)

You now need to place the Mati KYC button inside your App. Add it to your layout XML file:

    <com.matilock.mati_kyc_sdk.MatiLoginButton
                    android:layout_width="match_parent"
                    android:layout_height="wrap_content"
                    app:text="Custom"/>

## Metadata

Choose what kind of metadata you want to receive as shown in example below.

     Metadata metadata = new Metadata.Builder()
                .With("userId", "your client ID here")
                .With("type", 2)
                .Build();

    Mati.Instance.SetMetadata(metadata);

## Callback Registration

In order to handle login responses create a callback manager by calling following code:

    private MatiCallbackManager mCallbackManager = MatiCallbackManager.CreateNew();

Now register callback to handle callback responses

    //this can be the AppCompatActivity that implement IMatiCallback
    //or
    //any c# class that inherit from a descendant of Java.Lang.Object and that implement IMatiCallback
    MatiLoginManager.Instance.RegisterCallback(mCallbackManager, this);

And in your onActivityResult method, call mCallbackManager.onActivityResult to pass the login results to the MatiLoginManger

    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        mCallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
    }

## Mati Android SDK integration video

[![Mati SDK integration demo video](https://img.youtube.com/vi/qDBjiBwyVF8/0.jpg)](https://www.youtube.com/watch?v=qDBjiBwyVF8)
