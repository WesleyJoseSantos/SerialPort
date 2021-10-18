using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Timers;

namespace SerialPort
{
    public partial class Serial : Component
    {
        protected System.IO.Ports.SerialPort serialPort = new System.IO.Ports.SerialPort();

        [Category("Serial")]
        [DisplayName("Port")]
        [Description("Serial port name that should be used.")]
        [TypeConverter(typeof(PortNameTypeConverter))]
        public string Port { get => serialPort.PortName; set => serialPort.PortName = value; }

        [Category("Serial")]
        [DisplayName("Baud rate")]
        [Description("Baud rate of COM Port.")]
        [TypeConverter(typeof(BaudRateTypeConverter))]
        public int BaudRate { get => serialPort.BaudRate; set => serialPort.BaudRate = value; }

        [Category("Serial")]
        [DisplayName("Data bits")]
        [Description("The number of data bits on the serial port.")]
        [TypeConverter(typeof(DataBitsTypeConverter))]
        public int DataBits { get => serialPort.DataBits; set => serialPort.DataBits = value; }

        [Category("Serial")]
        [DisplayName("Stop bits")]
        [Description("The number of stop bits on the serial port.")]
        public StopBits StopBits { get => serialPort.StopBits; set => serialPort.StopBits = value; }

        [Category("Serial")]
        [DisplayName("Parity")]
        [Description("The parity mode on the serial port.")]
        public Parity Parity { get => serialPort.Parity; set => serialPort.Parity = value; }

        [Category("Serial")]
        [DisplayName("Terminator")]
        [Description("String used to detect end of line.")]
        public string Terminator { get => serialPort.NewLine; set => serialPort.NewLine = value; }

        [Category("Serial")]
        [DisplayName("Connected")]
        [Description("Flag that signs if serial port is connected.")]
        public bool Running { get => serialPort.IsOpen; }

        private int bacc, bps;
        private Timer t1s;

        public Serial()
        {
            InitializeComponent();
        }

        public Serial(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void Init()
        {
            t1s = new Timer();
            serialPort.ReadTimeout = 2000;
            serialPort.WriteTimeout = 2000;
            t1s.Interval = 1000;
            t1s.Elapsed += T1s_Tick;
            t1s.Start();
        }

        private void T1s_Tick(object sender, EventArgs e)
        {
            bps = bacc;
            bacc = 0;
        }

        public void Open()
        {
            serialPort.Open();
        }

        public void Close()
        {
            serialPort.Close();
        }

        public void SendData(string data)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(data + '\n');
                bacc += data.Length * 8;
            }
        }

        public void SendData(byte[] bytes)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(bytes, 0, bytes.Length);
                bacc += bytes.Length * 8;
            }
        }
    }
}
