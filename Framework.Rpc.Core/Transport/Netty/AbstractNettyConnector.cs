using System;

using DotNetty.Transport.Channels;
using DotNetty.Transport.Bootstrapping;

namespace Framework.Rpc.Core.Transport.Netty
{
    public abstract class AbstractNettyConnector : IConnector
    {
        protected readonly Bootstrap bootstrap;

        private IEventLoopGroup group;

        public AbstractNettyConnector()
        {
            bootstrap = new Bootstrap();
        }

        protected void Init()
        {
            group = new MultithreadEventLoopGroup();

            bootstrap.Group(group);

            DoInit();
        }

        public IChannel Connect(string host, int port)
        {
            return DoConnect(host, port);
        }

        public void Processor(IProviderProcessor processor)
        {
            DoProcessor(processor);
        }

        public void ShutdownGracefully()
        {
            try
            {
                if (group != null)
                {
                    group.ShutdownGracefullyAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected abstract void DoInit();

        protected abstract IChannel DoConnect(string host, int port);

        protected abstract void DoProcessor(IProviderProcessor processor);
    }
}
