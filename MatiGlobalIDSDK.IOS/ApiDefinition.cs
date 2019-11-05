using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;

namespace MatiGlobalIDSDK
{
    // The first step to creating a binding is to add your native library ("libNativeLibrary.a")
    // to the project by right-clicking (or Control-clicking) the folder containing this source
    // file and clicking "Add files..." and then simply select the native library (or libraries)
    // that you want to bind.
    //
    // When you do that, you'll notice that MonoDevelop generates a code-behind file for each
    // native library which will contain a [LinkWith] attribute. VisualStudio auto-detects the
    // architectures that the native library supports and fills in that information for you,
    // however, it cannot auto-detect any Frameworks or other system libraries that the
    // native library may depend on, so you'll need to fill in that information yourself.
    //
    // Once you've done that, you're ready to move on to binding the API...
    //
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, int index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     IntPtr Constructor (ElmoMuppet elmo);
    //
    // For more information, see https://aka.ms/ios-binding
    //

    //[Static]
    //partial interface Constants
    //{
    //    // extern double InAppSDKVersionNumber;
    //    [Field("mati_global_id_sdkVersionNumber", "__Internal")]
    //    double MatiGlobalIdSdkVersionNumber { get; }
    //}


    [BaseType(typeof(NSObject), Name = "_TtC15MatiGlobalIDSDK8LiveChat")]
    interface LiveChat
    {
        [Static, Export("licenseId"), NullAllowed]
        String LicenseId { get; set; }

        [Static, Export("groupId"), NullAllowed]
        String GroupId { get; set; }

        [Static, Export("name"), NullAllowed]
        String Name { get; set; }

        [Static, Export("email"), NullAllowed]
        String Email { get; set; }

        [Static, Export("allCustomVariables"), NullAllowed]
        NSDictionary AllCustomVariables { get; set; }


        [Static, Export("delegate"), NullAllowed]
        LiveChatDelegate Delegate { get; set; }

        [Static, Export("isChatPresented")]
        bool IsChatPresented { get;}

        [Static, Export("unreadMessagesCount")]
        nint unreadMessagesCount { get; }


        [Static, Export("setVariableWithKey:value:")]
        void SetVariableWithKey(String key, String value);

        [Static, Export("presentChatWithAnimated:completion:")]
        void PresentChatWithAnimated(bool animated, Action<bool> completion);

        [Static, Export("dismissChatWithAnimated:completion:")]
        void DismissChatWithAnimated(bool animated, Action<bool> completion);

        [Static, Export("clearSession")]
        void ClearSession();
    }

    [BaseType(typeof(NSObject), Name = "_TtP15MatiGlobalIDSDK16LiveChatDelegate_")]
    [Model, Protocol]
    interface LiveChatDelegate
    {
        [Export("receivedWithMessage:")]
        void ReceivedWithMessage(LiveChatMessage message);

        [Export("handleWithURL:")]
        void HandleWithURL(NSUrl URL);

        [Export("chatPresented")]
        void ChatPresented();

        [Export("chatDismissed")]
        void ChatDismissed();
    }

    [BaseType(typeof(NSObject), Name = "_TtC15MatiGlobalIDSDK15LiveChatMessage")]
    [DisableDefaultCtor]
    interface LiveChatMessage
    {
        [Export("id")]
        String Id { get; }

        [Export("text")]
        String Text { get; }

        [Export("date")]
        NSDate Date { get; }

        [Export("authorName")]
        String AuthorName { get; }

        [Export("rawMessage")]
        NSDictionary RawMessage { get; }
    }

    [BaseType(typeof(NSObject), Name = "_TtC15MatiGlobalIDSDK5MFKYC")]
    [DisableDefaultCtor]
    interface MFKYC
    {
        [Export("delegate"), NullAllowed]
        MFKYCDelegate Delegate { get; set; }

        [Static,Export("instance")]
        MFKYC Instance { get; }

        [Export("metadata"), NullAllowed]
        NSDictionary Metadata { get; set; }

        [Export("identityId"), NullAllowed]
        String IdentityId { get; set; }

        [Static,Export("registerWithClientId:metadata:")]
        void RegisterWithClientId(String clientId, [NullAllowed] NSDictionary metadata);
    }


    [BaseType(typeof(UIButton), Name = "_TtC15MatiGlobalIDSDK11MFKYCButton")]
    interface MFKYCButton
    {
        

        [Export("title"), NullAllowed]
        String Title { get; set; }

        [Export("intrinsicContentSize")]
        CGSize IntrinsicContentSize { get;}

        [Export("layoutSubviews")]
        void layoutSubviews();
    }

    [BaseType(typeof(NSObject), Name = "_TtP15MatiGlobalIDSDK13MFKYCDelegate_")]
    [Model, Protocol]
    interface MFKYCDelegate
    {
        
        [Export("mfKYCLoginSuccessWithIdentityId:")]
        void MFKYCLoginSuccessWithIdentityId(String identityId);

        [Export("mfKYCLoginCancelled")]
        void MFKYCLoginCancelled();
    }

}

