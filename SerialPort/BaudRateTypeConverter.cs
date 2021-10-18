using System.ComponentModel;

namespace SerialPort
{
    class BaudRateTypeConverter : Int32Converter
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
            int[] list = { 110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 74880, 115200, 128000, 256000 };
            return new StandardValuesCollection(list);
        }
    }
}
