using OVRSharp;

namespace ExitSuit{
  public class ExitUI:Overlay{
    public ExitUI():base("ExitUI","ExitUI"){
      TrackedDevice = TrackedDeviceRole.Hmd;
    }
  }
}
