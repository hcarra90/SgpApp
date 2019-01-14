using Layer.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layer.Win.Packing
{
    
    public partial class FrmPeso : Form
    {
        private const int BaudRate = 9600;
        SerialPort _serialPort = new SerialPort();

        public FrmPeso()
        {
            InitializeComponent();
           
        }

        private void FrmPeso_Load(object sender, EventArgs e)
        {
            _serialPort.PortName = "COM5";
            _serialPort.BaudRate = 2400;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.DataBits = 7;
            //_serialPort.Handshake = Handshake.None;

            _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortOnDataReceived);
            _serialPort.Open();
            CheckForIllegalCrossThreadCalls = false;
        }

        private delegate void Closure();
        
        private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            if (InvokeRequired)     //<-- Makes sure the function is invoked to work properly in the UI-Thread
                BeginInvoke(new Closure(() => { SerialPortOnDataReceived(sender, serialDataReceivedEventArgs); }));     //<-- Function invokes itself
            else
            {
                int dataLength = _serialPort.BytesToRead;
                byte[] data = new byte[dataLength];
                int nbrDataRead = _serialPort.Read(data, 0, dataLength);
                if (nbrDataRead == 0)
                    return;
                string str = System.Text.Encoding.UTF8.GetString(data);
                
                File.AppendAllText("buffer1.txt", str);
                string strnew = File.ReadLines("buffer1.txt").Last();

                strnew = DataFunctions.PreparaStringPeso(strnew,1);
                txtPeso.Text = strnew;
                
            }
        }
    }
}
