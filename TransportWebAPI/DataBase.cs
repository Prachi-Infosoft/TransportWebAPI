using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Xml.Serialization;

namespace TransportWebAPI
{
    public class DataBase
    {
    }
    [XmlRoot("TDDUSER")]
    public class TDDUser
    {

        [XmlElement("ID")]
        public int id { get; set; }
        [XmlElement("NAME")]
        public string name { get; set; }
        [XmlElement("ISADMIN")]
        public bool isadmin { get; set; }
        [XmlElement("PASSCREDENTIAL")]
        public string passcredential { get; set; }
        [XmlElement("RIGHTS.LIST")]
        public List<Rights> rights { get; set; }

        public bool isvaliduser { get; set; }

        public bool isdeleted { get; set; }

        public static TDDUser UserWithRights(string pname, string ppw)
        {
            return new TDDUser(pname,ppw);
        }
        public TDDUser() { }

        public TDDUser(string name, string passcredential)
        {
            this.name = name;
            this.passcredential = passcredential;
        }
    }
    public class Rights
    {
        [XmlElement("ACTION")]
        public string action { get; set; }
        [XmlElement("TARGET")]
        public string target { get; set; }
        public Rights() { }
    }

    public class MultiLR
    {
        [BsonId]
        public ObjectId id { get; set; }
        [BsonElement("masterid")]
        public int masterid { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("date")]
        public DateTime date { get; set; }

        [BsonElement("multilrdetails")]
        public List<MultiLRDetails> multilrdetails { get; set; }
        public MultiLR() { multilrdetails = new List<MultiLRDetails>(); }
    }
    public class MultiLRDetails
    {

        public string loryno { get; set; }
        public string destinition { get; set; }
        public string source { get; set; }
        public string description { get; set; }
        public long opkm { get; set; }
        public MultiLRDetails() { }

    }
    public class Lorry
    {
        [BsonId]
        public ObjectId id { get; set; }
        [BsonElement("name")]
        public string name { get; set;}
        [BsonElement("prvkm")]
        public long prvkm { get; set; }
    }
}
