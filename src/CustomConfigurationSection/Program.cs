using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConfigurationSection
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateSection();

            GetSection();
            Console.ReadKey();
        }

        static void CreateSection()
        {
            try
            {

                ConnectionsSection customSection;

                // Get the current configuration file.
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Create the section entry  
                // in the <configSections> and the 
                // related target section in <configuration>.
                if (config.Sections["ConnectionsSection"] == null)
                {
                    customSection = new ConnectionsSection();

                    config.Sections.Add("ConnectionsSection", customSection);
                    customSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        static void GetSection()
        {

            try
            {
                var connections = ConfigurationManager.GetSection("ConnectionsSection") as ConnectionsSection;

                if (connections != null)
                { 
                    connections.ToList().ForEach(item =>
                    {
                        Console.WriteLine("Name: {0}", item.Name);
                        Console.WriteLine("Type: {0}", item.Type);
                        Console.WriteLine("Value: {0}", item.Value);
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                    });
                }
                else
                {
                    Console.WriteLine("Failed to load CustomSection.");
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
    }
}
