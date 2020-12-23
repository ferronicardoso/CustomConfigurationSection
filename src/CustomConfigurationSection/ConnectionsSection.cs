using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CustomConfigurationSection
{
    public class ConnectionsSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public ConnectionsInstanceCollection Instances
        {
            get { return (ConnectionsInstanceCollection)this[""]; }
            set { this[""] = value; }
        }

        public List<ConnectionsInstanceElement> ToList()
        {
            var list = new List<ConnectionsInstanceElement>();
            foreach (ConnectionsInstanceElement item in this.Instances)
            {
                list.Add(item);
            }
            return list;
        }
    }

    public class ConnectionsInstanceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionsInstanceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConnectionsInstanceElement)element).Name;
        }
    }

    public class ConnectionsInstanceElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string @Value
        {
            get { return (string)base["value"]; }
            set { base["value"] = value; }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public DataSource @Type
        {
            get { return (DataSource)base["type"]; }
            set { base["type"] = value; }
        }
    }

    public enum DataSource
    {
        Firebird,
        MySql,
        Oracle,
        PostgreSql,
        Progress,
        Protheus,
        Sap,
        SqlLite,
        SqlServer
    }
}
