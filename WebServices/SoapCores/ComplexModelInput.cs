using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace SoapCores
{
    //[MessageContract(WrapperName = "PingComplexModel", IsWrapped = true)]
    //public class ComplexModelInput
    //{
    //    [MessageBodyMember()]
    //    public string StringProperty { get; set; }

    //    [MessageBodyMember()]
    //    public int IntProperty { get; set; }

    //    [MessageBodyMember()]
    //    public List<string> ListProperty { get; set; }

    //    [MessageBodyMember()]
    //    public DateTime DateTimeOffsetProperty { get; set; }

    //    [MessageBodyMember()]
    //    public List<ComplexObject> ComplexListProperty { get; set; }
    //}

    //[MessageContract]
    //public class ComplexObject
    //{
    //    [MessageBodyMember()]
    //    public string StringProperty { get; set; }

    //    [MessageBodyMember]
    //    public int IntProperty { get; set; }
    //}

    [DataContract()]
    public class ComplexModelInput
    {
        [DataMember()]
        public string StringProperty { get; set; }

        [DataMember()]
        public int IntProperty { get; set; }

        [DataMember()]
        public List<string> ListProperty { get; set; }

        [DataMember()]
        public DateTime DateTimeOffsetProperty { get; set; }

        [DataMember()]
        public List<ComplexObject> ComplexListProperty { get; set; }

        [DataMember]
        public TestEnum TestEnum { get; set; }
    }

    public class ComplexObject
    {
        public string StringProperty { get; set; }

        public int IntProperty { get; set; }
    }
}