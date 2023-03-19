using Org.BouncyCastle.Asn1.X509;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table ("tbPCGroups")]
    public class PCGroups
    {//Incomplete
        public int id { get; set; }
        public int idPC { get; set; }
        public int idGroup { get; set; }
        public Group Group { get; set; }
    }
}
