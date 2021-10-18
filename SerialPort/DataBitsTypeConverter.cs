using System.ComponentModel;

namespace SerialPort
{
    class DataBitsTypeConverter : Int32Converter
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
            int[] list = { 5, 6, 7, 8 };
            return new StandardValuesCollection(list);
        }
    }
}
