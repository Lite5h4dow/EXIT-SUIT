namespace ExitSuit{
  

  class Program{
    static void main(string[] args){
      Skeleton skeleton = new Skeleton();
      Joint pelvis = new Joint(new JointCalibration(), skeleton);
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
