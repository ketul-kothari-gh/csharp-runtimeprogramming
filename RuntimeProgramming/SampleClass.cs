using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimeProgramming
{
    class SampleClass
    {
        private int sampleField;
        public string SampleProperty1 { get; set; }

        public decimal SampleProperty2 { get; set; }

        public ReferencedBySampleClass  SampleProperty3 { get; set; }

        public SampleClass()
        {

        }

        public SampleClass(int sampleField)
        {
            this.sampleField = sampleField;
        }

        public void SampleMethod()
        {
            Console.WriteLine("SampleMethod");
        }
        
        private void PrivateSampleMethod()
        {
            Console.WriteLine("Private Sample method");
        }

    }

    class ReferencedBySampleClass
    {
        public string SampleProperty1 { get; set; }

        public string SampleProperty2 { get; set; }
    }

    class ChildSampleClass : SampleClass
    {
        public string SampleProperty1 { get; set; }
    }
}
