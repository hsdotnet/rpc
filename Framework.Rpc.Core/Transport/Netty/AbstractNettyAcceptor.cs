using System.Net;

using DotNetty.Transport.Channels;
using DotNetty.Transport.Bootstrapping;

namespace Framework.Rpc.Core.Transport.Netty
{
    public abstract class AbstractNettyAcceptor : IAcceptor
    {
        protected readonly ServerBootstrap bootstrap;

        private IEventLoopGroup bossGroup;
        private IEventLoopGroup workerGroup;

        public AbstractNettyAcceptor()
        {
            bootstrap = new ServerBootstrap();
        }

        protected void Init()
        {
            bossGroup = new MultithreadEventLoopGroup(1);
            workerGroup = new MultithreadEventLoopGroup();
            bootstrap.Group(bossGroup, workerGroup);

            DoInit();
        }

        public IChannel Bind(string host, int port)
        {
            return DoBind(host, port);
        }

        protected abstract void DoInit();

        protected abstract IChannel DoBind(string host, int port);
    }
}