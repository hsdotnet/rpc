﻿using System;
using System.Threading.Tasks;

using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Consumer
{
    public interface IConsumer
    {
        Task Send(RpcRequest request);

        event EventHandler<RecievedMessageEventArgs> Recieved;
    }
}