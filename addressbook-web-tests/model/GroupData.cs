using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using addressbook_web_tests.model;

namespace addressbook_web_tests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData(string name)
        {
            Name = name;
        }

        public GroupData()
        {
        }

        [Column(Name = "group_name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }

        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
            //or 
            //return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\n header=" + Header + "\n footer=" + Footer;
        }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            } 
        }
    }
}
