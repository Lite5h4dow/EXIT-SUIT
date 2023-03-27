using System.Numerics;

namespace ExitSuit{
  class Joint{
    public Quaternion rotation {get; set;}
    public Vector3 position {get; private set;}
    public Joint? parent {get; private set;}
    public List<Joint> children {get; set;}
    public Skeleton skeleton {get; set;}
    public JointCalibration calibration {get; set;}
    public List<JointFeedbackImpulse> jointFeedbackImpulses {get; set;}

    public Joint(JointCalibration calibration, Skeleton skeleton, Joint? parent = null ){
      this.calibration = calibration;
      this.parent = parent;
      this.skeleton = skeleton;
      this.position = Vector3.Zero;
      this.rotation = Quaternion.Zero;
      this.jointFeedbackImpulses = new List<JointFeedbackImpulse>();
      this.children = new List<Joint>();
      skeleton.joints.Add(this);
    }
  }

  class Skeleton{
    public Joint? root {get; set;}
    public List<Joint> joints {get; set;}

    public Skeleton(Joint? root = null){
      this.root = root;
      this.joints = new List<Joint>();
    }
  }

  class JointCalibration{
    public Quaternion rotationOffset {get; set;}
    public Vector3 positionOffset {get; set;}
  }

  class JointFeedbackImpulse{
    public Joint joint {get; set;}
    public float velocity {get; set;}
    public float acceleration {get; set;}
    public float duration {get; set;}

    public JointFeedbackImpulse(Joint joint, float velocity, float acceleration, float duration = 0.0f){
      this.joint = joint;
      this.velocity = velocity;
      this.acceleration = acceleration;

      this.joint.jointFeedbackImpulses.Add(this);
    }
  }

  class HapticFeedbackImpulse{
    public float frequency {get; set;}
    public float amplitude {get; set;}
    public float duration {get; set;}
  }
}
