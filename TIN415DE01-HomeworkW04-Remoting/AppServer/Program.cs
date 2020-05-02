using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace AppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpChannel(1234), false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ArtBUS), "artBUS", WellKnownObjectMode.SingleCall);
            Console.WriteLine("SERVER started ... ");

            Console.Read(); //make sure server is not disconnected
        }
    }
}
