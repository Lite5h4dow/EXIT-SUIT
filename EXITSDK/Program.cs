// See https://aka.ms/new-console-template for more information
using System.Numerics;

namespace ExitSuit{
  class Joint{
    public Quaternion rotation {get; set;}
    public Vector3 position {get; set;}
    public Joint? parent {get; set;}
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
    public Quaternion rotation {get; set;}
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

  class Program{
    static void main(string[] args){
      Skeleton skeleton = new Skeleton();
      Joint pelvis = new Joint(new JointCalibration(), skeleton);
      skeleton.root = pelvis;

      Joint upperLegLeft= new Joint(new JointCalibration(), skeleton, pelvis);
      Joint upperLegRight = new Joint(new JointCalibration(), skeleton, pelvis);
      Joint lowerLegLeft = new Joint(new JointCalibration(), skeleton, upperLegLeft);
      Joint lowerLegRight = new Joint(new JointCalibration(), skeleton, upperLegRight);
      Joint spine1 = new Joint(new JointCalibration(), skeleton, pelvis);
      Joint spine2 = new Joint(new JointCalibration(), skeleton, spine1);
      Joint spine3 = new Joint(new JointCalibration(), skeleton, spine2);
      Joint upperArmLeft = new Joint(new JointCalibration(), skeleton, spine3);
      Joint upperArmRight = new Joint(new JointCalibration(), skeleton, spine3);
      Joint lowerArmLeft = new Joint(new JointCalibration(), skeleton, upperArmLeft);
      Joint lowerArmRight = new Joint(new JointCalibration(), skeleton, upperArmRight);
      Joint neck = new Joint(new JointCalibration(), skeleton, spine3);

      new JointFeedbackImpulse(lowerLegLeft, 0.5f, 0.5f);
      new JointFeedbackImpulse(lowerLegRight, 0.5f, 0.5f);
      
    }
  }
}
