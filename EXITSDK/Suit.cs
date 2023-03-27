using System.IO.Ports;

namespace ExitSuit{
  class Platform{
    private SerialPort serialPort;

    public Platform(string portName){
      this.serialPort = new SerialPort(portName);
      this.serialPort.Open();
      this.serialPort.DataReceived += new SerialDataReceivedEventHandler(this.SerialPortRecieve);
    }

    public void SerialPortSend(string message){
      this.serialPort.Write(message);
    }

    private void SerialPortRecieve(object sender, SerialDataReceivedEventArgs e){
      Console.WriteLine(e.ToString());
    }
  }
}
