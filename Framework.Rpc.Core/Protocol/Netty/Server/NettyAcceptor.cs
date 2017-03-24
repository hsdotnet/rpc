using System;
using System.Threading.Tasks;
using System.Net;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Serializer;

using DotNetty.Transport.Channels;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels.Sockets;

namespace Framework.Rpc.Core.Protocol.Netty.Server
{
    public class NettyAcceptor : IAcceptor
    {
        private readonly ServerCacheContainer serverCacheContainer;

        private readonly ISerializer serializer;

        public NettyAcceptor(ServerCacheContainer serverCacheContainer, ISerializer serializer)
        {
            this.serverCacheContainer = serverCacheContainer;

            this.serializer = serializer;
        }

        private async Task RunServer()
        {
            IEventLoopGroup bossGroup = new MultithreadEventLoopGroup(1);
            IEventLoopGroup workerGroup = new MultithreadEventLoopGroup();
            try
            {
                ServerBootstrap bootstrap = new ServerBootstrap();//服务启动器
                bootstrap.Group(bossGroup, workerGroup);
                bootstrap.Channel<TcpServerSocketChannel>();
                bootstrap.Option(ChannelOption.SoBacklog, 100);//接受的客户端最大连接数
                bootstrap.ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
                {
                    IChannelPipeline pipeline = channel.Pipeline;
                    pipeline.AddLast(new NettyAcceptorHandler(serverCacheContainer, serializer));
                }));

                IPEndPoint point = new IPEndPoint(IPAddress.Parse(serverCacheContainer.Application.Host), serverCacheContainer.Application.Port);

                var bootstrapChannel = await bootstrap.BindAsync(point);

                //while (true)
                //{
                //    var line = Console.ReadLine();
                //    if (line == "exit")
                //    {
                //        await bootstrapChannel.CloseAsync();
                //        break;
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //Task.WaitAll(bossGroup.ShutdownGracefullyAsync(), workerGroup.ShutdownGracefullyAsync());
            }
        }

        public void Stop()
        {

        }

        public void Start()
        {
            Task.Run(() => RunServer()).Wait();
        }
    }
}