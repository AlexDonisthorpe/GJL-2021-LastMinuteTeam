#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class AkDynamicSequenceItemCallbackInfo : AkCallbackInfo {
  private global::System.IntPtr swigCPtr;

  internal AkDynamicSequenceItemCallbackInfo(global::System.IntPtr cPtr, bool cMemoryOwn) : base(AkSoundEnginePINVOKE.CSharp_AkDynamicSequenceItemCallbackInfo_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(AkDynamicSequenceItemCallbackInfo obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  internal override void setCPtr(global::System.IntPtr cPtr) {
    base.setCPtr(AkSoundEnginePINVOKE.CSharp_AkDynamicSequenceItemCallbackInfo_SWIGUpcast(cPtr));
    swigCPtr = cPtr;
  }

  ~AkDynamicSequenceItemCallbackInfo() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkDynamicSequenceItemCallbackInfo(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public uint playingID { get { return AkSoundEnginePINVOKE.CSharp_AkDynamicSequenceItemCallbackInfo_playingID_get(swigCPtr); } 
  }

  public uint audioNodeID { get { return AkSoundEnginePINVOKE.CSharp_AkDynamicSequenceItemCallbackInfo_audioNodeID_get(swigCPtr); } 
  }

  public global::System.IntPtr pCustomInfo { get { return AkSoundEnginePINVOKE.CSharp_AkDynamicSequenceItemCallbackInfo_pCustomInfo_get(swigCPtr); }
  }

  public AkDynamicSequenceItemCallbackInfo() : this(AkSoundEnginePINVOKE.CSharp_new_AkDynamicSequenceItemCallbackInfo(), true) {
  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.