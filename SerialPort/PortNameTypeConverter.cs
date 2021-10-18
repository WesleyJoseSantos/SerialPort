using System.ComponentModel;

namespace SerialPort
{
    class PortNameTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var list = System.IO.Ports.SerialPort.GetPortNames();
            return new StandardValuesCollection(list);
        }
    }
}
