using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var host = new ServiceHost(typeof(Service.Service.ProjectService));
                host.Open();
                Console.WriteLine("Host is running!!");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
